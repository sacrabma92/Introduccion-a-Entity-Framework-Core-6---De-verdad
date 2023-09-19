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
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
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
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(actores);
        }
    }
}
