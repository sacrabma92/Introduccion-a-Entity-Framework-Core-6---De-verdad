using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        //[Unicode(false)]
        public string PosterURL { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
        public HashSet<GeneroPelicula> GenerosPeliculas { get; set; }
        public HashSet<PeliculaSalaDeCine> PeliculasSalaDeCine { get; set; }
    }
}
