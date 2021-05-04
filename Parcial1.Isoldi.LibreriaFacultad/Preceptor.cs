using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad
{
    public class Preceptor: Persona
    {
        private int _legajo;
        private bool _activo;

        public Preceptor(int legajo, string nombre, string apellido, bool activo): base(nombre, apellido)
        {
            this._legajo = legajo;
            this._activo = activo;
        }

        public bool Activo { get => _activo;}

        public override string ToString()
        {

            return $"{this._apellido} - {this._legajo}";
        }
        public override string Display()
        {
            return this.ToString();
        }
    }
}
