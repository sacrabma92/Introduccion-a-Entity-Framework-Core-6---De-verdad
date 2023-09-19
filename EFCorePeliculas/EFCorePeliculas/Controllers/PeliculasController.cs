using AutoMapper;
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
        /// </summary>
        /// <param name="id">Id a buscar</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetPorId(int id)
        {
            var peliculas = await _context.Peliculas
                .Include(p => p.Generos)
                .Include(p => p.SalasDeCine)
                // LO que realiza ThenInclude es entrar a la entidad cine que se 
                // encuentra en la clase SalasDeCine para traer los datos
                    .ThenInclude(s => s.Cine)
                .Include(p => p.PeliculasActores)
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
    }
}
