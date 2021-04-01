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
                            GenerarReporte();
                            break;

                        case 2:
                            RegistrarEmpleado();
                            break;

                        case 3:
                            RegistrarUsuario();
                            break;

                        case 4:
                            GenerarManilla();
                            break;

                        case 5:
                            RegistrarAtraccion();
                            break;

                        case 6:
                            ConsutarInfoAtraccion();
                            break;

                        case 7:
                            ConsultarInfoPersona();
                            break;

                        case 8:
                            
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
            Console.WriteLine("[1] Generar reporte");
            Console.WriteLine("[2] Registrar empleado");
            Console.WriteLine("[3] Registrar usuario");
            Console.WriteLine("[4] Generar manilla");
            Console.WriteLine("[5] Registrar atracción");
            Console.WriteLine("[6] Consultar información atracción");
            Console.WriteLine("[7] Consultar información persona");   
            Console.WriteLine("[8] Asignar atracción a un empleado");
            Console.WriteLine("[0] Salir");
            Console.WriteLine("=========================================");
        }

        static void GenerarReporte()
        {

        }
       
        static void RegistrarEmpleado(string nombre, long docID, DateTime fechaNacimiento, int edad)
        {

        }

        static void RegistrarUsuario(string nombre, long docID, DateTime fechaNacimiento, int edad, double estatura, Manilla dueño)
        {
        
        }

        static void GenerarManilla(double saldo)
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
