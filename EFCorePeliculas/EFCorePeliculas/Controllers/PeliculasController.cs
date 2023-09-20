using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [Route("api/peliculas")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// v46-47 Traer data relacionada con Eager Loading
        /// Se corrige el problema de traer un campo tipo Point de la clase Cine
        /// v48 Se organiza el genero de forma Descendente.
        /// v48 Se optiene los actores mayores a 1980
        /// </summary>
        /// <param name="id">Id a buscar</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetPorInclude(int id)
        {
            var peliculas = await _context.Peliculas
                .Include(p => p.Generos.OrderByDescending(g => g.Nombre))
                .Include(p => p.SalasDeCine)
                // LO que realiza ThenInclude es entrar a la entidad cine que se 
                // encuentra en la clase SalasDeCine para traer los datos
                    .ThenInclude(s => s.Cine)
                .Include(p => p.PeliculasActores.Where(pa => pa.Actor.FechaNacimiento.Value.Year >= 1980 ))
                    .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(peliculas == null)
            {
                return NotFound();
            }

            var peliculaDTO = _mapper.Map<PeliculaDTO>(peliculas);

            peliculaDTO.Cines = peliculaDTO.Cines.DistinctBy(x => x.Id).ToList();

            return Ok(peliculaDTO);
        }

        /// <summary>
        /// v49 Se usa ProjectTo para carga de datos.
        /// Tambien toca configurar el AutoMapper para que pueda funcionar
        /// </summary>
        /// <param name="id">Id a buscar</param>
        /// <returns></returns>
        [HttpGet("conprojectto/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetProjectTo(int id)
        {
            var peliculas = await _context.Peliculas
                .ProjectTo<PeliculaDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (peliculas == null)
            {
                return NotFound();
            }

            peliculas.Cines = peliculas.Cines.DistinctBy(x => x.Id).ToList();

            return Ok(peliculas);
        }

        /// <summary>
        /// v50 Obtener valores por metodo Select
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("cargadoselectivo/{id:int}")]
        public async Task<ActionResult> GetSelectivo(int id)
        {
            var pelicula = await _context.Peliculas.Select(p =>
            new
            {
                Id = p.Id,
                Titulos = p.Titulo,
                // Trae los generos ordenados de forma ascendente y trae solo el nombre omite el id
                Generos = p.Generos.OrderByDescending(g => g.Nombre).Select(g => g.Nombre).ToList(),
                // Cantidad de actores asociados a esa pelicula
                CantidadActores = p.PeliculasActores.Count(),
                // Hace un conteno de Cines. Cuantos cines se encuentra esta pelicula
                CantidadCines = p.SalasDeCine.Select( s => s.CineId).Distinct().Count(),
            }).FirstOrDefaultAsync(x => x.Id == id);

            if(pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        /// <summary>
        /// Carga de forma explicita
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("explicitloading/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetExplicito(int id)
        {
            var pelicula = await _context.Peliculas.AsTracking().FirstOrDefaultAsync( p => p.Id == id);
            
            //Carga los generos de forma explicita
            await _context.Entry(pelicula).Collection(p => p.Generos).LoadAsync();

            // Carga la cantidad de data de generos de la pelicula
            var cantidadGeneros = await _context.Entry(pelicula).Collection(p => p.Generos).Query().CountAsync();

            if( pelicula == null)
            {
                return NotFound();
            }

            var peliculaDTO = _mapper.Map<PeliculaDTO>(pelicula);

            return Ok(peliculaDTO);
        }

        /// <summary>
        /// Agrupadas si estan en carteleraa o no
        /// </summary>
        /// <returns></returns>
        [HttpGet("agrupadasPorEstreno")]
        public async Task<ActionResult> GetAgrupadasPorCarteleras()
        {
            var peliculasAgrupadas = await _context.Peliculas.GroupBy(p => p.EnCartelera)
                .Select( g => new
                {
                    EnCartelero = g.Key,
                    Conteo = g.Count(),
                    Peliculas = g.ToList(),
                })
                .ToListAsync();

            return Ok(peliculasAgrupadas);
        }

        /// <summary>
        /// v54 Agrupadas por cantidad de generos
        /// </summary>
        /// <returns></returns>
        [HttpGet("agrupadaporcantidaddegeneros")]
        public async Task<ActionResult> GetAgrupadasPorCantidadDeGeneros()
        {
            var peliculasAgrupadas = await _context.Peliculas.GroupBy( g => g.Generos.Count())
                                        .Select(g => new
                                        {
                                            Conteo = g.Key,
                                            Titulos = g.Select(x => x.Titulo),
                                            Generos = g.Select(p => p.Generos)
                                                .SelectMany( gen => gen )
                                                .Select(gen => gen.Nombre)
                                                .Distinct()
                                        }).ToListAsync();
            return Ok(peliculasAgrupadas);
        }
    }
}
