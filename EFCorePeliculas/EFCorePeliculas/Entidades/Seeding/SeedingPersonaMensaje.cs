using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades.Seeding
{
    public static class SeedingPersonaMensaje
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var carlos = new Persona() { Id = 1, Nombre = "Carlos" };
            var angelica = new Persona() { Id = 2, Nombre = "Angelica" };

            var mensaje1 = new Mensaje() { Id = 1, Contenido = "Hola, Angelica!", EmisorId = carlos.Id, ReceptorId = angelica.Id };
            var mensaje2 = new Mensaje() { Id = 2, Contenido = "Hola, Carlos, ¿Cómo te va?", EmisorId = angelica.Id, ReceptorId = carlos.Id };
            var mensaje3 = new Mensaje() { Id = 3, Contenido = "Todo bien, ¿Y tú?", EmisorId = carlos.Id, ReceptorId = angelica.Id };
            var mensaje4 = new Mensaje() { Id = 4, Contenido = "Muy bien", EmisorId = angelica.Id, ReceptorId = carlos.Id };

            modelBuilder.Entity<Persona>().HasData((carlos, angelica));
            modelBuilder.Entity<Mensaje>().HasData(mensaje1, mensaje2, mensaje3, mensaje4);
        }
    }
}
