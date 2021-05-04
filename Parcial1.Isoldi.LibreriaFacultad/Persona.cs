using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad
{
    public abstract class Persona
    {
        protected string _nombre;
        protected string _apellido;

        public Persona(string nombre, string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public abstract string Display();
    }
}
