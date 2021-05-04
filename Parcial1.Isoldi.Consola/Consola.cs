using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Isoldi.Consola
{
    class Consola
    {
        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public string IngresarString()
        {
            return Console.ReadLine();
        }

        public string IngresarOpcion(List<string> opciones)
        {
            string opcion;
            do
            {
                opcion = Console.ReadLine();

                if (!opciones.Contains(opcion))
                {
                    Console.WriteLine("Opcion incorrecta, ingrese una opcion valida:");
                }
            } while (!opciones.Contains(opcion));

            return opcion;
        }
            

        public int IngresarInt()
        {
            int entradaUsuario = 0;
            try
            {
                Console.WriteLine("solo se admiten numeros enteros");
                entradaUsuario = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("El dato ingresado no es del formato adecuado");
                IngresarInt();
            }

            return entradaUsuario;
        }

        public double IngresarDouble()
        {
            double entradaUsuario = 0.0;
            try
            {
                Console.WriteLine("solo se admiten numeros");
                entradaUsuario = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("El dato ingresado no es del formato adecuado");
                IngresarDouble();
            }

            return entradaUsuario;
        }

        public DateTime IngresarTiempo()
        {
            DateTime entradaUsuario = new DateTime();
            try
            {
                Console.WriteLine("Ingresar Fecha en formato dd/mm/aaaa");
                entradaUsuario = DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("El dato ingresado no es del formato adecuado");
                IngresarTiempo();
            }

            return entradaUsuario;
        }

        public void PresentarMenu(string[] opciones)
        {
            Console.WriteLine("\nPresione enter para desplegar el menu principal.");
            Console.ReadLine();
            Console.WriteLine("\n    --------------\n    Menu Principal\n    --------------\n");
            Console.WriteLine("Ingrese el numero de la accion que se quiere realizar:");
            foreach (string opcion in opciones)
            {
                Console.WriteLine(opcion);
            }

        }
    }
}
