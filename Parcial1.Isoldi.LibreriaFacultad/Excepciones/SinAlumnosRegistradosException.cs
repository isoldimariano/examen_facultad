using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad.Excepciones
{
    public class SinAlumnosRegistradosException : Exception
    {
        public SinAlumnosRegistradosException(string mensaje): base(mensaje) {}
    }
}
