using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        // v90 Dos propiedades de navegacion en la misma entidad
        [InverseProperty("Emisor")]
        public List<Mensaje> MensajesEnviados { get; set; }
        [InverseProperty("Receptor")]
        public List<Mensaje> MensajesRecibidos { get; set; }
    }
}
