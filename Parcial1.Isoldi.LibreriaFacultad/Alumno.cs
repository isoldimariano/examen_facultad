using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad
{
    public abstract class Alumno: Persona
    {
        private int _registro;

        public Alumno(string nombre, string apellido, int registro): base(nombre, apellido)
        {
            this._registro = registro;
        }

        public override string ToString()
        {
            return $"{this._nombre}({this._registro})";
        }
        public override string Display()
        {
            return this.ToString();
        }
    }
}
