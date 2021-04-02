using System;
using System.Collections.Generic;
using System.IO;

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
                            Console.WriteLine("Por favor, ingrese su nombre");
                            string nombre = Console.ReadLine();

                            Console.WriteLine("Por favor, ingrese su documento de identidad");
                            long docID = long.Parse(Console.ReadLine());

                            Console.WriteLine("Por favor, ingrese su fecha de nacimiento");
                            DateTime fechaNacimiento = default;

                            RegistrarEmpleado(nombre, docID, fechaNacimiento, personas);

                            Console.WriteLine("Se ha registrado un empleado con éxito");
                            break;

                        case 3:
                            Console.WriteLine("Por favor, ingrese su nombre");
                            string nombreUsuario = Console.ReadLine();

                            Console.WriteLine("Por favor, ingrese su documento de identidad");
                            long docIDUsuario = long.Parse(Console.ReadLine());

                            Console.WriteLine("Por favor, ingrese su fecha de nacimiento");
                            DateTime fechaNacimientoUsuario = default;

                            Console.WriteLine("Por favor, ingrese su estatura");
                            double estatura = double.Parse(Console.ReadLine());

                            RegistrarUsuario(nombreUsuario, docIDUsuario, fechaNacimientoUsuario, estatura, personas);

                            Console.WriteLine("Se ha registrado el usuario con éxito y se le ha asignado una manilla con un saldo de $0");
                            break;

                        case 4:
                            Console.WriteLine("¿Desea registrar las atracciones desde un archivo? s/n");
                            string res = Console.ReadLine().ToUpper();
                            if (res == "S")
                            {
                                string path = "Atracciones_PD.txt";
                                string linea = "";
                                string[] arregloAtr;
                                StreamReader file = new StreamReader(path);
                                linea = file.ReadLine();
                                while (linea != null)
                                {
                                    arregloAtr = linea.Split('|');

                                        if (arregloAtr[0].ToString() == "MC")
                                        {
                                            atracciones.Add(new Mecanica("MC" + arregloAtr[1], arregloAtr[2], int.Parse(arregloAtr[3]), double.Parse(arregloAtr[4]), double.Parse(arregloAtr[5]), arregloAtr[6]));

                                        }
                                        if (arregloAtr[0].ToString() == "AC")
                                        {
                                            atracciones.Add(new Acuatica("AC" + arregloAtr[1], arregloAtr[2], int.Parse(arregloAtr[3]), double.Parse(arregloAtr[4]), double.Parse(arregloAtr[5]), arregloAtr[6]));

                                        }
                                        if (arregloAtr[0].ToString() == "VI")
                                        {
                                            atracciones.Add(new Virtual("VI" + arregloAtr[1], arregloAtr[2], int.Parse(arregloAtr[3]), double.Parse(arregloAtr[4]), double.Parse(arregloAtr[5]), arregloAtr[6]));

                                        }
                                 

                                    linea = file.ReadLine();

                                }
                            }

                            //RegistrarAtraccion();
                            break;

                        case 5:
                            
                            break;

                        case 6:
                            //ConsutarInfoAtraccion();
                            break;

                        case 7:
                            //ConsultarInfoPersona();
                            break;

                        case 8:
                            ListarAtracciones(atracciones);
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
            Console.WriteLine("[4] Registrar atracción");
            Console.WriteLine("[5] Consultar información atracción");
            Console.WriteLine("[6] Consultar información persona");   
            Console.WriteLine("[7] Asignar atracción a un empleado");
            Console.WriteLine("[8] Listar atracciones");
            Console.WriteLine("[0] Salir");
            Console.WriteLine("=========================================");
        }

        static void GenerarReporte()
        {

        }
       
        static void RegistrarEmpleado(string nombre, long docID, DateTime fechaNacimiento, List<Persona> personas)
        {
            personas.Add(new Empleado(nombre, fechaNacimiento, docID));
        }

        static void RegistrarUsuario(string nombre, long docID, DateTime fechaNacimiento, double estatura, List<Persona> personas)
        {
            personas.Add(new Usuario(nombre, fechaNacimiento, docID, estatura));
        }

        static void RegistrarAtraccion(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion, bool operando, List<Atraccion> atracciones)
        {

        }

        static void ListarAtracciones(List<Atraccion> atracciones)
        {
            if (atracciones.Count > 0)
            {
                foreach (var item in atracciones)
                {
                    Console.WriteLine(atracciones.IndexOf(item) + 1 + " )" + " Código: " + item.Codigo + " \n Nombre: " + item.Nombre + " \n Límite de Edad:" + item.Limite_de_edad + " \n Límite de Estatura:" + item.Limite_de_estatura + " \n Costo:" + item.Costo + "\n  Descripción:" + item.Descripcion);
                    Console.WriteLine();
                }
            }
        }
        
        static void ConsutarInfoAtraccion(Atraccion atraccion)
        {
            
        }

        static void ConsultarInfoPersona(Persona persona)
        {

        }                
    }
}
