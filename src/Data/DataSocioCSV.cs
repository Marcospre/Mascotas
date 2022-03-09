using System;
using Modelos;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace Data{
    public class DataSocioCVS : IData
    {
       string _file = "../../dataSocio.csv";

       public void guardarSocio(List<Socio> socios){
           List<string> data = new(){ };
           socios.ForEach(Socio =>
           {
               var str = $"{Socio.idsocio},{Socio.nombre},{Socio.sexo}";
               data.Add(str);
           });
           File.WriteAllLines(_file, data);
        
       }


    }
}