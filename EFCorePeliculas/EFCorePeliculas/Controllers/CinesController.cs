using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Controllers
{
    [Route("api/cines")]
    [ApiController]
    public class CinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CinesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// v44 Configurando la Latitud y Longitud para poder visualizarlo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CineDTO>> Get()
        {
            var cines = await _context.Cines.
                ProjectTo<CineDTO>(_mapper.ConfigurationProvider).ToListAsync();
            
            return cines;
        }

        /// <summary>
        /// v45 Buscamos los cines mas cercanos segun parametros de latitud y longitud..
        /// A la distancia mas corta de 2km
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <returns></returns>
        [HttpGet("cercanos")]
        public async Task<ActionResult> GetCercano(double latitud, double longitud)
        {
            var geometryFactory = NtsGeometryServices.Instance
                .CreateGeometryFactory(srid: 4326);

            var miUbicacion = geometryFactory
                .CreatePoint(new Coordinate(longitud, latitud));
            var distanciaMaximaEnMetros = 2000;

            var cines = await _context.Cines
                .OrderBy(x => x.Ubicacion.Distance(miUbicacion))
                .Where(x => x.Ubicacion.IsWithinDistance(miUbicacion, distanciaMaximaEnMetros))
                .Select(c => new
                {
                    Nombre = c.Nombre,
                    Distancia = Math.Round(c.Ubicacion.Distance(miUbicacion))
                }).ToListAsync();
            return Ok(cines);
        }

        /// <summary>
        /// Insertando registro con data relacionada quemada
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostCineCineOferta()
        {
            var geometryFactory = NtsGeometryServices.Instance
                .CreateGeometryFactory(srid: 4326);

            var ubicacionCine = geometryFactory
                .CreatePoint(new Coordinate(-69.896979, 18.476276));
            var distanciaMaximaEnMetros = 2000;

            var cin = new Cine()
            {
                Nombre = "Mi cine",
                Ubicacion = ubicacionCine,
                CineOferta = new CineOferta()
                {
                    PorcentajeDescuento = 5,
                    FechaInicio = DateTime.Today,
                    FechaFin = DateTime.Today.AddDays(7)
                },
                SalaDeCine = new HashSet<SalaDeCine>()
                {
                    new SalaDeCine()
                    {
                        Precio = 200,
                        TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
                    },
                    new SalaDeCine()
                    {
                        Precio = 350,
                        TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
                    }
                }
            };

            _context.Add(cin);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        /// <summary>
        /// v62 Inserccion de datos en multiples tablas relacionadas
        /// </summary>
        /// <param name="cineCreacionDTO"></param>
        /// <returns></returns>
        [HttpPost("conDTO")]
        public async Task<ActionResult> Post( CineCreacionDTO cineCreacionDTO)
        {
            var cine = _mapper.Map<Cine>(cineCreacionDTO);

            _context.Add(cine);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
