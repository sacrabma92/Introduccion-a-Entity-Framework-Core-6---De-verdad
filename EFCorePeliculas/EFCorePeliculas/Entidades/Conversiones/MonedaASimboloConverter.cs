using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCorePeliculas.Entidades.Conversiones
{
    public class MonedaASimboloConverter : ValueConverter<Moneda, string>
    {
        public MonedaASimboloConverter() 
            :base(
                valor => MapeoMonedaString(valor),
                valor => MapeoStringMoneda(valor)
            )
        {
            
        }

        // v79 Mapear de la moneda al simobolo
        private static string MapeoMonedaString(Moneda valor)
        {
            return valor switch
            {
                Moneda.PesoDominicado => "RD$",
                Moneda.DolarEstadoUnidense => "$",
                Moneda.Euro => "€",
                _ => ""
            };
        }

        // v79 Mapear de String a Moneda
        private static Moneda MapeoStringMoneda(string valor)
        {
            return valor switch
            {
                "RD$" => Moneda.PesoDominicado,
                "$" => Moneda.DolarEstadoUnidense,
                "€" => Moneda.Euro,
                _ => Moneda.Desconocida
            };
        }
    }
}
