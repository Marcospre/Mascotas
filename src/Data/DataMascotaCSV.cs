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
               var str = $"{Mascota.idMascosta},{Mascota.nombre},{Mascota.especie},{Mascota.edad},{Mascota.idSocio},{Mascota.nombre_socio}";
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
                    idMascosta = campos[0],
                    nombre = campos[1],
                    especie =  (especie)Enum.Parse(typeof(especie), campos[2]),
                    edad = Int32.Parse(campos[3]),
                    idSocio = campos[4],
                    nombre_socio = campos[5]
                    
                    
                };
                mascotas.Add(mascota);
            });
            return mascotas;
        }




    }
}