using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [Route("api/Generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Trae todos los generos
        /// <summary>
        /// Trae todos los Generos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await _context.Generos.ToListAsync();
        }

        /// <summary>
        /// Trae el genero por el id
        /// </summary>
        /// <param name="id">Id del genero a buscar</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> GetGeneroPorId(int id)
        {
            var genero = await _context.Generos.FirstOrDefaultAsync(x => x.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            return Ok(genero);
        }

        /// <summary>
        /// Buscamos generos que contengan la palabra o letra ingresada.
        /// Ordenados por Nombre Ascendente
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpGet("filtrarPorNombre")]
        public async Task<IEnumerable<Genero>> Filtrar(string nombre)
        {
            var filtro = await _context.Generos
                .Where(x => x.Nombre.Contains(nombre))
                .OrderBy(g => g.Nombre)
                .ToListAsync();

            return filtro;
        }

        /// <summary>
        /// Paginando con Take v41
        /// </summary>
        /// <returns></returns>
        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion( int pagina = 1)
        {
            var registrosPorPagina = 2;
            var generos = await _context.Generos
                .Skip((pagina -1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToListAsync();

            return Ok(generos);
        }


        /// <summary>
        /// Genero que empieza con la letra ingresada
        /// </summary>
        /// <param name="letra"></param>
        /// <returns></returns>
        [HttpGet("empiezaCon")]
        public async Task<ActionResult<Genero>> GetEmpiezaCon(string letra)
        {
            var empiezaCon = await _context.Generos.FirstOrDefaultAsync(x => x.Nombre.StartsWith(letra));

            if (empiezaCon is null)
            {
                return NotFound();
            }

            return Ok(empiezaCon);
        }

        /// <summary>
        /// Genero que finaliza con la letra ingresada
        /// </summary>
        /// <param name="letra"></param>
        /// <returns></returns>
        [HttpGet("finalizaCon")]
        public async Task<ActionResult<Genero>> GetFinalizaCon(string letra)
        {
            var finalizaCon = await _context.Generos.FirstOrDefaultAsync(x => x.Nombre.EndsWith(letra));

            if (finalizaCon is null)
            {
                return NotFound();
            }

            return Ok(finalizaCon);
        }
    }
}
