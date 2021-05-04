using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1.Isoldi.LibreriaFacultad;
using Parcial1.Isoldi.LibreriaFacultad.Excepciones;
namespace Parcial1.Isoldi.Consola
{
    public class Program
    {
        private static Presentismo _presentismo;
        private static Consola _consola;

        static Program()
        {
            _consola = new Consola();
            _presentismo = new Presentismo();
        }
        static void Main(string[] args)
        {
            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();
            string opcionMenu = "";

            do{
                try
                {
                    DesplegarOpcionesMenu();
                    opcionMenu = _consola.IngresarOpcion(new List<string> { "1", "2", "X"});
                    switch (opcionMenu)
                    {
                        case "1":
                            TomarAsistencia(preceptorActivo);
                            break;
                        case "2":
                            MostrarAsistencia();
                            break;
                        case "X":
                            // SALIR
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _consola.MostrarMensaje("error");
                    _consola.MostrarMensaje(Convert.ToString(ex));
                }
            } while (opcionMenu != "X");
        }
        static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("_____________________");
            Console.WriteLine("1) Tomar Asistencia");
            Console.WriteLine("2) Mostrar Asistencia");
            Console.WriteLine("X: Terminar");
            Console.WriteLine("_____________________");
        }
        static void TomarAsistencia(Preceptor p)
        {
            List<Asistencia> listaAsistencia = new List<Asistencia>();

            // entrada y validacion de datos
            DateTime fechaReal = _consola.IngresarTiempo();
            string fechaAsistencia = Convert.ToString(fechaReal);

            bool yaRegistrada = _presentismo.AsistenciaRegistrada(fechaAsistencia);
            if(yaRegistrada)
            {
                throw new AsistenciaExistenteEseDiaException($"ya existen asistencias con esta fecha {fechaAsistencia}.");
            }

            List <Alumno> listaAlumnos = _presentismo.GetListaAlumnos();
            if (listaAlumnos.Count() == 0)
            {
                throw new SinAlumnosRegistradosException("no existen alumnos registrados para tomar asistencia.");
            }

            // generacion de asistencia por cada alumno en la lista
            foreach (Alumno alumno in listaAlumnos)
            {
                _consola.MostrarMensaje($"esta presente el alumno {alumno.Display()}? (si / no)");

                string respuesta = _consola.IngresarOpcion(new List<string> {"si", "no"});
                bool presente = respuesta == "si";
                
                Asistencia nuevaAsistencia = new Asistencia(fechaAsistencia, fechaReal, p, alumno, presente);

                listaAsistencia.Add(nuevaAsistencia);
            }
            _presentismo.AgregarAsistencia(listaAsistencia);
        }
        static void MostrarAsistencia()
        {
            DateTime fechaReal = _consola.IngresarTiempo();
            string fechaAsistencia = Convert.ToString(fechaReal);

            List<Asistencia> asistencias = _presentismo.GetAsistenciasPorFecha(fechaAsistencia);
            if (asistencias.Count() == 0)
            {
                _consola.MostrarMensaje($"No hay asistencias en la fecha {fechaAsistencia}.");
            }
            
            foreach (Asistencia asistencia in asistencias)
            {
                _consola.MostrarMensaje(asistencia.Display());
            }
        }
    }

}
