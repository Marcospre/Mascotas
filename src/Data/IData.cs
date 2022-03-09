using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace Data
{
    public interface IData
    {
        void Guardar(List<InfoVacPaciente> ingresados);
        List<InfoVacPaciente> Leer();
    }

}