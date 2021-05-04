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
        // modificar lo que corresponda para que solo finalice el
        // programa si el usuario presiona X en el menú
        static void Main(string[] args)
        {
            Preceptor preceptorActivo = _presentismo.GetPreceptorActivo();
            string opcionMenu = ""; // pedir el valor

            do{
                try
                {
                    DesplegarOpcionesMenu();
                    opcionMenu = _consola.IngresarString(new List<string> { "1", "2", "X"});
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
            Console.WriteLine("1) Tomar Asistencia");
            Console.WriteLine("2) Mostrar Asistencia");
            Console.WriteLine("X: Terminar");
        }
        static void TomarAsistencia(Preceptor p)
        {
            List<Asistencia> listaAsistencia = new List<Asistencia>();

            DateTime fechaReal = _consola.IngresarTiempo();
            string fechaAsistencia = Convert.ToString(fechaReal);
            bool yaRegistrada = _presentismo.AsistenciaRegistrada(fechaAsistencia);

            if(yaRegistrada)
            {
                throw new AsistenciaExistenteEseDiaException($"ya existen asistencias con esta fecha {fechaAsistencia}.");
            }

            List <Alumno> listaAlumnos = _presentismo.GetListaAlumnos();

            foreach (Alumno alumno in listaAlumnos)
            {
                _consola.MostrarMensaje($"esta presente el alumno {alumno.Display()}?");

                string respuesta = _consola.IngresarString(new List<string> {"si", "no"});
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

            foreach (Asistencia asistencia in asistencias)
            {
                _consola.MostrarMensaje(asistencia.Display());
            }
            // ingreso fecha
            // muestro el toString de cada asistencia
        }
    }

}
