using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad.Excepciones
{
    public class AsistenciaExistenteEseDiaException: Exception
    {
        public AsistenciaExistenteEseDiaException(string mensaje): base(mensaje) {}
    }
}
