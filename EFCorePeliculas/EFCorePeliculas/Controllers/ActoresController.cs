using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using EFCorePeliculas.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Usamos la condicion Select para traer solo los campos requeridos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSelect")]
        public async Task<ActionResult<Actor>> GetSelect()
        {
            var actores = await _context.Actores
                .Select(a => new { Id = a.Id, Nombre = a.Nombre })
                .ToListAsync();

            return Ok(actores);
        }

        /// <summary>
        /// Usamos Autommaper para mappear la clase ActorDTO a Actor 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAutommapper")]
        public async Task<ActionResult<ActorDTO>> GetAutoMapper()
        {
            var actores = await _context.Actores
                .ProjectTo<ActorDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(actores);
        }

        /// <summary>
        /// Creacion de actor con la primera letra del nombre en Mayuscula
        /// </summary>
        /// <param name="actorCreacionDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var  actor = _mapper.Map<Actor>(actorCreacionDTO);
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// v65 Actualizacion con Modelo Conectado. Permite actualizar de forma parcial
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actorCreacionDTO"></param>
        /// <returns></returns>
        [HttpPut("modeloConectado/{id:int}")]
        public async Task<ActionResult> PutConectado(int id, ActorCreacionDTO actorCreacionDTO)
        {
            var actorDB = await _context.Actores.AsTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (actorDB is null)
            {
                return NotFound();
            }

            actorDB = _mapper.Map(actorCreacionDTO, actorDB);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// v66 Actualizacion con Modelo Desconectado. No sabe que ha cambiado y trata de actualizarlo todo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actorCreacionDTO"></param>
        /// <returns></returns>
        [HttpPut("modeloDesconectado/{id:int}")]
        public async Task<ActionResult> PutDesconectado(int id, ActorCreacionDTO actorCreacionDTO)
        {
            var existeActor = await _context.Actores.AnyAsync(x => x.Id == id);

            if (!existeActor)
            {
                return NotFound();
            }

            var actor = _mapper.Map<Actor>(actorCreacionDTO);
            actor.Id = id;

            _context.Update(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //[HttpGet("Enums")]
        //public ActionResult GetEnums()
        //{
        //    return Ok(Enums.MessageExist);
        //}
    }
}
