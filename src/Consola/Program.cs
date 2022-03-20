using System;
using Modelos;
using App;
using System.Collections.Generic;
using Consola;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo_socio = new Data.DataSocioCVS();
            var repo_mascota = new Data.DataMascotaCVS();
            var view = new Vista();
            var sis_socio = new GestorDeSocios(repo_socio);
            var sis_mascota = new GestorDeMascota(repo_mascota);
            var controlador = new Controlador(view,sis_mascota, sis_socio);
            controlador.Run();
        }
    }
}
