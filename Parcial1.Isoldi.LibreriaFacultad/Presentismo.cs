using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1.Isoldi.LibreriaFacultad.Excepciones;

namespace Parcial1.Isoldi.LibreriaFacultad
{
    public class Presentismo
    {
        private List<Preceptor> _preceptores;
        private List<Alumno> _alumnos;
        private List<Asistencia> _asistencias;

        public Presentismo()
        {
            _alumnos = new List<Alumno>();
            _asistencias = new List<Asistencia>();
            _preceptores = new List<Preceptor>();

            _preceptores.Add(new Preceptor(5, "Jorgelina", "Ramos", true));
            _preceptores.Add(new Preceptor(6, "Juan", "Gutierrez", false));

            _alumnos.Add(new AlumnoRegular(123, "Carlos", "Juárez", "cj@gmail.com"));
            _alumnos.Add(new AlumnoRegular(124, "Carla", "Jaime", "carla@gmail.com"));
            _alumnos.Add(new AlumnoOyente(320, "Ramona", "Vals"));
            _alumnos.Add(new AlumnoOyente(321, "Alejandro", "Medina"));
        }

        public bool AsistenciaRegistrada(string fecha)
        {
            bool registrada = false;
            Asistencia asistencia = this._asistencias.FirstOrDefault(o => o.FechaAsistencia == fecha);

            if(!(asistencia is null))
            {
                registrada = true;
            }
            //bool registrada = false;
            //foreach(Asistencia asist in _asistencias)
            //{
            //    if (asist.FechaAsistencia == fecha)
            //    {
            //        registrada = true;
            //        break;
            //    }
            //}
            return registrada;
        }

        private int GetCantidadAlumnosRegulares()
        {
            return this._alumnos.Where(o => o is AlumnoRegular).Count();

            // int cantidad = 0;

            // foreach(Alumno alum in _alumnos)
            // {
            //     if(alum is AlumnoRegular)
            //     {
            //         cantidad += 1;
            //     }
            // }

            // return cantidad;

        }

        public Preceptor GetPreceptorActivo()
        {   
            Preceptor preceptorActivo = this._preceptores.FirstOrDefault(o => o.Activo == true);

            return preceptorActivo;
        }

        public List<Alumno> GetListaAlumnos()
        {
            List<Alumno> alumnos = this._alumnos.FindAll(o => o is AlumnoRegular);
            return alumnos;
        }

        public void AgregarAsistencia(List<Asistencia> asistencias)
        {
            int cantAsist = asistencias.Count;
            int cantReg = GetCantidadAlumnosRegulares();

            if (cantAsist != cantReg)
            {
                throw new AsistenciaInconsistenteException($"cantidad de asistencias: {cantAsist}, cantidad alumnos regulares: {cantReg}.");
            }
            this._asistencias.AddRange(asistencias);
        }

        public List<Asistencia> GetAsistenciasPorFecha(string fecha)
        {
            List<Asistencia> asistencias = this._asistencias.FindAll(o => o.FechaAsistencia == fecha);

            return asistencias;

            // List <Asistencia> asistencias = new List<Asistencia>();

            // foreach (Asistencia asist in _asistencias)
            // {
            // if (asist.FechaAsistencia == fecha)
            // {
            // asistencias.Add(asist);
            // }
            // }
            // return asistencias;
        }
    }
}
