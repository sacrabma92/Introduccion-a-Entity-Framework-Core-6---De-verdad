using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.Entidades
{
    public class Genero
    {
        //[Key]
        public int Identificador { get; set; }
        //[MaxLength(100)]
        //[StringLength(100)]
        //[Required]
        public string Nombre { get; set; }
        public HashSet<GeneroPelicula> GenerosPeliculas { get; set; }
    }
}
