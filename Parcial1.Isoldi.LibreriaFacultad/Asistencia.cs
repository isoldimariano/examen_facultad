using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.LibreriaFacultad
{
    public class Asistencia
    {
        private string _fechaAsistencia;
        private DateTime _fechaHoraReal;
        private Preceptor _preceptor;
        private Alumno _alumno;
        private bool _estaPresente;

        public Asistencia(string fechaAsistencia, DateTime fechaHoraReal, Preceptor preceptor, Alumno alumno, bool estaPresente)
        {
            this._fechaAsistencia = fechaAsistencia;
            this._fechaHoraReal = fechaHoraReal;
            this._preceptor = preceptor;
            this._alumno = alumno;
            this._estaPresente = estaPresente;
    }

        public string FechaAsistencia { get => _fechaAsistencia; set => _fechaAsistencia = value; }
        public override string ToString()
        {
            string presente = "NO";
            string alumn = this._alumno.Display();
            string precep = this._preceptor.Display();
            string fechaHora = this._fechaHoraReal.ToString("yyyy - MM - dd");

            if (this._estaPresente)
            {
                presente = "SI";
            }

            return $"FECHAREFERENCIA {alumn} está presente: {presente}, por {precep} registrado el {fechaHora}";
        }
        public string Display()
        {
            return this.ToString();
        }
    }
}
