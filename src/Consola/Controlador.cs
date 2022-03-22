using System;
using Modelos;
using System.Collections.Generic;
using System.Linq;
using App;

namespace Consola
{
    class Controlador
    {
        private Vista _vista;
        private GestorDeSocios sistema_socios;
        private GestorDeMascota sistema_mascotas;
        private Dictionary<String, Action> _casosDeUso;
        public Controlador(Vista vista, GestorDeMascota gesMascotas, GestorDeSocios gesSocios)
        {
            _vista = vista;
            sistema_socios = gesSocios;
            sistema_mascotas = gesMascotas;
            _casosDeUso = new Dictionary<string, Action>()
            {
                {"Registrar nuevo Socio", RegistrarSocio},
                {"Registrar nueva Mascota",RegistrarMascota},
                {"Eliminar Socio",EliminarSocio},
                {"Eliminar Mascota",EliminarMascota},
                {"Comprar Mascota",compraMascota},
                {"Mostrar Mascotas ordenadas",ordenarMascotas},
                {"Mostrar Socios",MostrarSocios}
            };
        }

        public void Run()
        {
            _vista.LimpiarPantalla();
            var menu = _casosDeUso.Keys.ToList<String>();

            while(true)
            try{
                _vista.LimpiarPantalla();
                var key = _vista.TryObtenerElementoDeLista("Menu de Usuario", menu, "Selecciona una opcion");
                _vista.Mostrar("");
                _casosDeUso[key].Invoke();
                _vista.MostrarYReturn("Pulsa <Return> para continuar");
            }
            catch {return;}
        }

        // Casos de Uso

        private void RegistrarSocio()
        {
            try
            {
                var id = _vista.TryObtenerDatoDeTipo<string>("ID Socio");
                var nom = _vista.TryObtenerDatoDeTipo<string>("Nombre");
                var sx = _vista.TryObtenerDatoDeTipo<string>("Sexo");

                Socio nuevoSocio = new Socio
                {
                    idSocio = id,
                    nombre = nom,
                    sexo = sx
                };
                sistema_socios.NuevoSocio(nuevoSocio);
            }catch(Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }   
        }

        private void RegistrarMascota()
        {
            try
            {
                var id_mas = _vista.TryObtenerDatoDeTipo<string>("IDMascota");
                var nom = _vista.TryObtenerDatoDeTipo<string>("Nombre");
                var es = _vista.TryObtenerDatoDeTipo<string>("Especie");
                var ed = _vista.TryObtenerDatoDeTipo<int>("Edad");
                var ids = _vista.TryObtenerDatoDeTipo<string>("IDSocio");

                Mascota nuevaMascota = new Mascota
                {
                    idMascosta = id_mas,
                    nombre = nom,
                    especie = es,
                    edad = ed,
                    idSocio = ids
                    
                };
                if(existeSocio(ids,nuevaMascota)){
                    sistema_mascotas.NuevaMascota(nuevaMascota);
                }else{
                    _vista.Mostrar($"No existe el socio al que se le asigna esta mascota");
                }
            }catch(Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }   
        }

        private bool existeSocio(string id, Mascota masco)
        {   
            bool dev = false;
            foreach(Socio elem in sistema_socios.Socios)
            {
                if(elem.idSocio == id) 
                    masco.nombre_socio = elem.nombre;
                    dev = true;
            } 
            return dev;
        }

        private void EliminarSocio()
        {
            try
            {
                //Mostramos Lista de socios
                MostrarSocios();
                //Seleccionamos socio
                var idx = _vista.TryObtenerValorEnRangoInt(1, sistema_socios.Socios.Count, "Socio a eliminar");
                var so = sistema_socios.Socios[idx - 1];
                //Ejecucion
                sistema_socios.EliminarSocio(so);
                //Info
                _vista.Mostrar($"Informe baja entregado a {so.idSocio} de nombre {so.nombre}");
            }catch(Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }
        }

        private void EliminarMascota()
        {
            try
            {
                //Mostramos Lista de Mascotas
                MostrarMascotas();
                //Seleccionamos Mascota
                var idx = _vista.TryObtenerValorEnRangoInt(1, sistema_mascotas.Mascotas.Count, "Mascota a eliminar");
                var mas = sistema_mascotas.Mascotas[idx - 1];
                //Ejecucion
                sistema_mascotas.EliminarMascota(mas);
                //Info
                _vista.Mostrar($"Informe de baja entregado a {mas.idMascosta} de nombre {mas.nombre}");
            }catch(Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }
        }

        private void compraMascota(){
            MostrarSocios();
            var idcomprador = _vista.TryObtenerValorEnRangoInt(1,sistema_socios.Socios.Count, "Socio que va realizar la compra");
            var comprador = sistema_socios.Socios[idcomprador-1];
            MostrarMascotas();
            var id_masco_comprar = _vista.TryObtenerValorEnRangoInt(1,sistema_mascotas.Mascotas.Count, "Mascota a comprar");
            var masco = sistema_mascotas.Mascotas[id_masco_comprar-1];
            if(comprador.idSocio != masco.idSocio){
                sistema_mascotas.CambiarSocio(masco.idMascosta,comprador.idSocio);
                _vista.Mostrar($"La mascota con id {masco.idMascosta} pertenece al comprador con id {comprador.idSocio} de nombre {comprador.nombre}");
            }else{
                _vista.Mostrar("No se puede vender una mascota al mismo vendedor");
            }

        }

        public void ordenarMascotas()
        {
            string op = _vista.obtenerEspecieEdad();
            String mensaje = null;

            if(op.Equals("e")){
                mensaje = "Edad";
                sistema_mascotas.Mascotas.Sort(delegate(Mascota x, Mascota y){
                    return x.edad.CompareTo(y.edad);
                });
            }else{
                mensaje = "Especie";
                sistema_mascotas.Mascotas.Sort(delegate(Mascota x, Mascota y){
                    return x.especie.CompareTo(y.especie);
                });
            }
            _vista.MostrarListaEnumerada<Mascota>($"Ordenados por {mensaje}",sistema_mascotas.Mascotas);
        }

        private void MostrarSocios()
        {
            _vista.MostrarListaEnumerada<Socio>("Socios",sistema_socios.Socios);

        }
        private void MostrarMascotas()
        {
            _vista.MostrarListaEnumerada<Mascota>("Mascotas",sistema_mascotas.Mascotas);

        }

    }   
}