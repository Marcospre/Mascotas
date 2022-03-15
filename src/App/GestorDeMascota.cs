using System;
using Data;
using Modelos;
using System.Collections.Generic;

namespace App
{
    public class GestorDeMascota{

        IData<Mascota> RepoMascota;
        public List<Mascota> Mascotas;
        public GestorDeMascota(IData<Mascota> repo){
            RepoMascota = repo;
            Mascotas = RepoMascota.Leer();
        }

        public void NuevaMascota(Mascota nueva){
            Mascotas.Add(nueva);
            RepoMascota.Guardar(Mascotas);
        }
        public void EliminarMascota(Mascota elimi){
            Mascotas.Remove(elimi);
            RepoMascota.Guardar(Mascotas);
        }



    }
}