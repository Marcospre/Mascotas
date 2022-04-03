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

        public void CambiarSocio(string id_masco, string id_SocioNuevo, string nombre_SocioNuveo)
        {
            foreach(Mascota elem in Mascotas)
            {
                if(elem.idMascosta == id_masco){
                    if(elem.idSocio != id_SocioNuevo){
                         elem.idSocio = id_SocioNuevo;
                         elem.nombre_socio = nombre_SocioNuveo;
                    }
                }
                
            }
            RepoMascota.Guardar(Mascotas);
        }

        public void BorrarSocio(Mascota masco){
            masco.idSocio = null;
            masco.nombre_socio = null;
            RepoMascota.Guardar(Mascotas);
        }


    }
}