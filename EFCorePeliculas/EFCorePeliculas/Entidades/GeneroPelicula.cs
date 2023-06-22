using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades
{
    public class GeneroPelicula
    {
        public int GeneroId { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
        public Genero Genero { get; set; }
    }
}
