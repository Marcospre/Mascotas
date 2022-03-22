using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;
using Modelos;


namespace Data{
    public class DataMascotaCVS : IData<Mascota>
    {
       string _file = "../../datoMascota.csv";

       public void Guardar(List<Mascota> mascotas){
           List<string> data = new(){ };
           mascotas.ForEach(Mascota =>
           {
               var str = $"{Mascota.nombre},{Mascota.especie},{Mascota.edad},{Mascota.idSocio}";
               data.Add(str);
           });
           File.WriteAllLines(_file, data);
        
       }

       public List<Mascota> Leer()
        {
            List<Mascota> mascotas = new();
            var data = File.ReadAllLines(_file).ToList();
            data.ForEach(row =>
            {
                var campos = row.Split(",");
                var mascota = new Mascota
                {
                    nombre = campos[0],
                    especie =  campos[1],
                    edad = Int32.Parse(campos[2]),
                    idSocio = campos[3]
                };
                mascotas.Add(mascota);
            });
            return mascotas;
        }




    }
}