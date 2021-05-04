using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad
{
    class AlumnoOyente: Alumno
    {

        public AlumnoOyente(int registro, string apellido, string nombre): base(nombre, apellido, registro)
        {
        }
    }
}
