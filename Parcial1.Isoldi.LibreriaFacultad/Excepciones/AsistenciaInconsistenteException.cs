using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad.Excepciones
{
    public class AsistenciaInconsistenteException: Exception
    {
        public AsistenciaInconsistenteException(string mensaje) : base(mensaje) {}
    }
}
