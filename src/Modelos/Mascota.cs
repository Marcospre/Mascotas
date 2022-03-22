using System;

namespace Modelos
{
    public class Mascota{
        public string idMascosta{get; set;}
        public string nombre{get; set;}
        public string especie{get; set;}
        public int edad{get; set;}
        public string idSocio{get; set;}
        public string nombre_socio{get; set;}

        public override string ToString()
        {
            return $"idMascota:{idMascosta} nombre:{nombre} especie:{especie} edad:{edad} idSocio:{idSocio} ({nombre_socio})";
        }
    }
}