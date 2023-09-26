using AutoMapper;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// v90 Uso de InverseProperty
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            return await _context.Personas
                .Include(x => x.MensajesEnviados)
                .Include(x => x.MensajesRecibidos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
