using AutoMapper;
using EFCorePeliculas.DTOs;
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
        private readonly IMapper _mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        //Trae todos los generos
        /// <summary>
        /// Trae todos los Generos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            _context.Logs.Add(new Log
            {
                Mensaje = "Ejecutando el método GenerosController.Get"
            });
            await _context.SaveChangesAsync();
            return await _context.Generos
                //.Where(g => !g.EstaBorrado)
                .ToListAsync();
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

        /// <summary>
        /// v58 Como funciona el estado desde codigo
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = _mapper.Map<Genero>(generoCreacionDTO);

            var exitesGeneroConNombre = await _context.Generos.AnyAsync(g => g.Nombre == genero.Nombre);

            if(exitesGeneroConNombre)
            {
                return BadRequest("Ya existe un género con ese nombre: " + genero.Nombre);
            }

            _context.Add(genero);
            await _context.SaveChangesAsync();

            return Ok();
        }



        /// <summary>
        /// v 61 Insertar varios registros al mismo tiempo
        /// </summary>
        /// <param name="generos"></param>
        /// <returns></returns>
        /// 
        //Forma de enviar varaios en el arreglo
        //    [
        //        {
        //          "nombre": "Biografia 1"
        //        },
        //        {
        //          "nombre": "Biografia 2"
        //        }
        //    ]
        [HttpPost("varios")]
        public async Task<ActionResult> Post(Genero[] generos)
        {
            _context.AddRange(generos);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Borrado normal de la tabla
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genero = _context.Generos.FirstOrDefaultAsync(x => x.Identificador == id);

            if(genero is null)
            {
                return NotFound();
            }

            _context.Remove(genero);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// v69 Borrado suave - Desactivar estado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("desactivarestado/{id:int}")]
        public async Task<ActionResult> DeleteSuave(int id)
        {
            var genero = await _context.Generos.AsTracking().FirstOrDefaultAsync(x => x.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = true;
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// v70 Restaura el registro que se encuentra inactivo lo casa a estar activo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Restaurar/{id:int}")]
        public async Task<ActionResult> Restaurar(int id)
        {
            var genero = await _context.Generos
                .IgnoreQueryFilters()
                .AsTracking().
                FirstOrDefaultAsync(x => x.Identificador == id);

            if (genero is null)
            {
                return NotFound();
            }

            genero.EstaBorrado = false;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(GeneroCreacionDTO generoCreacionDTO)
        {
            _context.Update(generoCreacionDTO);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
