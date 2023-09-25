using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades.SinLLaves
{
    // v80 Entidad sin llaves
    //[Keyless]
    public class CineSinUbicacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
