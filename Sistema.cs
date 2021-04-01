using System;
using System.Collections.Generic;

namespace ParqueDiversiones
{
    class Sistema
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenidos al Sistema");
            List<Persona> personas = new List<Persona>();
            List<Atraccion> atracciones = new List<Atraccion>();
            List<ReporteCostos> reporteCostos = new List<ReporteCostos>();

            int opcion = default;
            do
            {
                try
                {
                    Menu();

                    switch (opcion = int.Parse(Console.ReadLine()))
                    {

                        case 1:
                            
                            break;
                       
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Error: " + e.Message);
                }
            } while (opcion != 0);
        }
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("");
            Console.WriteLine("==[Menu]=================================");
            Console.WriteLine("[1] Crear Proyecto");
            Console.WriteLine("[2] Añadir integrantes");
            Console.WriteLine("[3] Ver lista de proyectos");
            Console.WriteLine("[0] Salir");
            Console.WriteLine("=========================================");
        }

        static void GenerarReporte()
            {

            }

            static void ResgistrarEmpleado(string nombre, long docID, DateTime fechaNacimiento, int edad)
            {

            }

            static void GenerarManilla(double saldo)
            {

            }

            static void RegistrarUsuario(string nombre, long docID, DateTime fechaNacimiento, int edad, double estatura, Manilla dueño)
            {

            }

            static void RegistrarAtraccion(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion, bool operando)
            {

            }

            static void ConsutarInfoAtraccion(Atraccion atraccion)
            {

            }

            static void ConsultarInfoPersona(Persona persona)
            {

            }
        }
    }
}
