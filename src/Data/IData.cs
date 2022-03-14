using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;

using Modelos;
namespace Data
{
    public interface IData
    {
        void Guardar(List<Object> elem );
        List<Object> Leer();
    }

}