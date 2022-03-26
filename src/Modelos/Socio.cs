using System;

namespace Modelos
{
    public enum sexo{
        Hombre,
        Mujer,
    }
    public class Socio{
        public string idSocio{get; set;}
        public string nombre{get; set;}
        public sexo sexo{get; set;}

        public override string ToString()
        {
            return $"idSocio:{idSocio} nombre:{nombre} sexo:{sexo}";
        }
    }
}