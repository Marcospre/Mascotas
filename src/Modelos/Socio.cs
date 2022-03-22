using System;

namespace Modelos
{
    public class Socio{
        public string idSocio{get; set;}
        public string nombre{get; set;}
        public string sexo{get; set;}

        public override string ToString()
        {
            return $"idSocio:{idSocio} nombre:{nombre} sexo:{sexo}";
        }
    }
}