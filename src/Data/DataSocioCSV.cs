using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;

using Modelos;

namespace Data{
    public class DataSocioCVS : IData<Socio>
    {
       string _file = "C:/Users/Marcos/Documents/DAW/ED/Mascotas/dataSocio.csv";

       public void Guardar(List<Socio> socios){
           List<string> data = new(){ };
           socios.ForEach(Socio =>
           {
               var str = $"{Socio.idSocio},{Socio.nombre},{Socio.sexo}";
               data.Add(str);
           });
           File.WriteAllLines(_file, data);
        
       }

       public List<Socio> Leer()
        {
            List<Socio> socios = new();
            var data = File.ReadAllLines(_file).ToList();
            data.ForEach(row =>
            {
                var campos = row.Split(",");
                var socio = new Socio
                {
                    idSocio = campos[0],
                    nombre =  campos[1],
                    sexo = campos[2],
                };
                socios.Add(socio);
            });
            return socios;
        }




    }
}