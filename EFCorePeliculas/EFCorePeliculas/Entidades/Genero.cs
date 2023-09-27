using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entidades 
{
    // v76 configuracion de indice en una tabla
    //[Index(nameof(Nombre), IsUnique = true)]
    public class Genero : EntidadAuditable
    {
        //[Key]
        public int Identificador { get; set; }
        //Configuracion para que tenga un tamaño fijo. Se puede colocar tambien en el API Fluente
        //[StringLength(150)]
        //[MaxLength(150)]
        public string Nombre { get; set; }
        public bool EstaBorrado { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
