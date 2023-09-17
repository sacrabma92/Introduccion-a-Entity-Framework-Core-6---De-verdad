using System.Drawing;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //[Precision(precision:9, scale:2)]
        public NetTopologySuite.Geometries.Point Ubicacion { get; set; }

        // Propiedad de navegacion
        //Mecanismo que nos permiten navegar entre entidades de una relacion
        public CineOferta CineOferta { get; set; }

        // Relacion de SalaDeCine
        public HashSet<SalaDeCine> SalaDeCine { get; set; }
    }
}
