using System;
using Data;
using Modelos;
using System.Collections.Generic;

namespace App
{
    public class GestorDeSocios
    {
        IData<Socio> Reposocio;
        public List<Socio> Socios{get; set;} = new();

        public GestorDeSocios(IData<Socio> repo){
            Reposocio = repo;
            Socios = Reposocio.Leer();

        }

        public void NuevoSocio(Socio nuevo){
            Socios.Add(nuevo);
            Reposocio.Guardar(Socios);
        }
        
        public void EliminarSocio(Socio eliminar){
            Socios.Remove(eliminar);
            Reposocio.Guardar(Socios);
        }

    }
}
