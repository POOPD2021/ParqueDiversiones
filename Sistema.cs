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
                            DateTime fechaNacimiento = SolicitarFecha();

                            RegistrarEmpleado(nombre, docID, fechaNacimiento, personas);

                            Console.WriteLine("Se ha registrado un empleado con éxito");
                            break;

                        case 3:
                            Console.WriteLine("Por favor, ingrese su nombre");
                            string nombreUsuario = Console.ReadLine();

                            Console.WriteLine("Por favor, ingrese su documento de identidad");
                            long docIDUsuario = long.Parse(Console.ReadLine());

                            Console.WriteLine("Por favor, ingrese su fecha de nacimiento");
                            DateTime fechaNacimientoUsuario = SolicitarFecha();

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
                            Console.WriteLine("¿Qué atracción desea consultar su información?");
                            Console.WriteLine();
                            ListarAtracciones(atracciones);
                            int atraccionSeleccionada = int.Parse(Console.ReadLine()) - 1;
                            ConsutarInfoAtraccion(atracciones[atraccionSeleccionada]);
                            break;

                        case 6:
                            ConsultarInfoUsuarios(personas);
                            break;

                        case 7:
                            ConsultarInfoEmpleados(personas);
                            break;

                        case 8:
                          
                            Console.WriteLine("Escoja la atracción que quiere asignar al empleado: ");
                            ListarAtracciones(atracciones);
                            int atrSeleccionada = int.Parse(Console.ReadLine()) - 1;

                            personas.Sort((s1, s2) => s1.GetType().Name.CompareTo(s2.GetType().Name));
                            Console.WriteLine("Escoja el empleado a asignar la atracción ");

                            ConsultarInfoEmpleados(personas);
                            int emplSeleccionado = int.Parse(Console.ReadLine()) - 1;
                            Empleado empleado=  personas[emplSeleccionado] as Empleado;
                            empleado.AsignarAtraccion(atracciones[atrSeleccionada]);
                            Console.WriteLine("Atraccion asignada con éxito");

                            break;
                        case 9:
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
            Console.WriteLine("[6] Consultar información usuarios");
            Console.WriteLine("[7] Consultar información empleados");
            Console.WriteLine("[8] Asignar atracción a un empleado");
            Console.WriteLine("[9] Listar atracciones");
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
                    Console.WriteLine(atracciones.IndexOf(item) + 1 + " )" + "|Tipo: " + item.GetType().Name+ "| Código: " + item.Codigo + "  |Nombre: " + item.Nombre +"| Costo: " +item.Costo) ;
                    Console.WriteLine();
                }
            }
            else
            {
                throw new Exception("No hay atracciones inscritas");
            }
        }
        
        static void ConsutarInfoAtraccion(Atraccion atraccion)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTipo: " + atraccion.GetType().Name + "\nCódigo: " + atraccion.Codigo + "\nNombre: " + atraccion.Nombre+ "\nCosto: " + atraccion.Costo+ "\nLimite de edad: " + atraccion.Limite_de_edad + "\nLimite estatura:" + atraccion.Limite_de_estatura + "\nDescripcion general:" + atraccion.Descripcion + "\nEstado:" + atraccion.ConsultarEstado());
            Console.WriteLine();
        }

        static void ConsultarInfoUsuarios(List<Persona> personas)
        {
            int contadorUsuarios = default;
            foreach (var item in personas)
            {
                    var usuario = item as Usuario;
                    if (usuario != null)
                    {
                    Console.WriteLine(contadorUsuarios + 1 + " )" + "| Tipo: " + usuario.GetType().Name + "  | Nombre: " + usuario.Nombre + "| Documento: " + usuario.DocID + "| Edad: " + usuario.Edad + "| Estaura:" + usuario.Estatura);
                    contadorUsuarios++;
                    }
            }
            if (contadorUsuarios == 0)
            {
                throw new Exception("No hay usuarios inscritos");
            }
            
        }
       static void  ConsultarInfoEmpleados(List<Persona> personas)
        {
            int contadorEmpleados = default;
            foreach (var item in personas)
            {
                var empleado = item as Empleado;
                if (empleado != null)
                {
                    Console.WriteLine(contadorEmpleados + 1 + " )" + "| Tipo: " + empleado.GetType().Name + "  | Nombre: " + empleado.Nombre + "| Documento: " + empleado.DocID + "| Edad: " + empleado.Edad + "| Atraccion encargada: " + empleado.ConsultarInfoAtraccion());
                    contadorEmpleados++;
                }
            }
            if (contadorEmpleados == 0)
            {
                throw new Exception("No hay empleados inscritos");
            }
        }

        static DateTime SolicitarFecha()
        {
            string[] fecha = new string[2];
            int[] fechaInt = new int[2];
            string linea = "";
            DateTime fechaNacimiento;

            Console.WriteLine("Escriba la fecha de nacimiento en  formato: Año/Mes/Dia");
            linea = Console.ReadLine();
            for (int i = 0; i < 2; i++)
            {
                fecha = (linea.Split('/'));
            }
            fechaInt = Array.ConvertAll(fecha, int.Parse);
            fechaNacimiento = new DateTime(fechaInt[0], fechaInt[1], fechaInt[2]);

            return fechaNacimiento;
        }
    }
}
