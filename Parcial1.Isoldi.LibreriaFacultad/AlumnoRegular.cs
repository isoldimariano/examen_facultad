﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad
{
    class AlumnoRegular: Alumno
    {
        private string _email;

        public AlumnoRegular(int registro, string nombre, string apellido, string email): base(nombre, apellido, registro)
        {
            this._email = email;
        }

    }
}
