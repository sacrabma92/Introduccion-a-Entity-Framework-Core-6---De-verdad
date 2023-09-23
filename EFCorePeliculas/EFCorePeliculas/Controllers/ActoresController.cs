using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
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
    }
}
