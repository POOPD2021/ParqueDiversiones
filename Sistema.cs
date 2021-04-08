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
            ActualizarInfoAtr(atracciones); //Asegura que la informacion acerca de las atracciones se va actualizar cada que se inicie el programa
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
                            //Registrar una persona general y pregunta si es usuario o empleado
                            Console.WriteLine("¿Usuario o empleado? [1] o [2]");
                            int tipoPersona = int.Parse(Console.ReadLine());
                            Console.WriteLine("Por favor, ingrese su nombre");
                            string nombre = Console.ReadLine();
                            Console.WriteLine("Por favor, ingrese su documento de identidad");
                            long docID = long.Parse(Console.ReadLine());
                            Console.WriteLine("Por favor, ingrese su fecha de nacimiento");
                            DateTime fechaNacimiento = SolicitarFecha();

                            if (tipoPersona == 1)
                            {
                              
                                Console.WriteLine("Por favor, ingrese su estatura");
                                double estatura = double.Parse(Console.ReadLine());

                                RegistrarUsuario(nombre, docID, fechaNacimiento, estatura, personas);

                                Console.WriteLine("Se ha registrado el usuario con éxito y se le ha asignado una manilla con un saldo de $0");
                            }
                            else if (tipoPersona == 2)
                            {
                                RegistrarEmpleado(nombre, docID, fechaNacimiento, personas);
                                Console.WriteLine("Se ha registrado un empleado con éxito");

                            }


                            break;

                        case 3:
                           
                           
                            break;

                        case 4:

                            ActualizarInfoAtr(atracciones);
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
                            //Pregunta la atraccion a la que le quiere asignar el empleado
                            Console.WriteLine("Escoja la atracción que quiere asignar al empleado: ");
                            ListarAtracciones(atracciones);
                            int atrSeleccionada = int.Parse(Console.ReadLine()) - 1;
                            //Organiza la lista de personas separando usuarios y empleados 
                            personas.Sort((s1, s2) => s1.GetType().Name.CompareTo(s2.GetType().Name));
                            Console.WriteLine("Escoja el empleado a asignar la atracción ");

                            //llama  la lista de empleados
                            ConsultarInfoEmpleados(personas);
                            int emplSeleccionado = int.Parse(Console.ReadLine()) - 1;
                            Empleado empleado=  personas[emplSeleccionado] as Empleado; //Convierte la persona en empleado para poder acceder a su metodo
                            empleado.AsignarAtraccion(atracciones[atrSeleccionada]);//Le asigna la atracción
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
            Console.WriteLine("[2] Registrar persona");
            Console.WriteLine("[3] Recargar manilla");
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
                    var usuario = item as Usuario; //Permite consultar las propiedades del usuario conviertiendo el objecto persona en usuario
                    if (usuario != null) //si hay un usuario en la lista de personas
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
                var empleado = item as Empleado;//Permite consultar las propiedades del empleado conviertiendo el objecto persona en empleado
                if (empleado != null)//si hay un empleado en la lista de personas
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
        /// <summary>
        /// Pregunta la fecha en el formata Año/mes/dia, los cuarda en un arreglo y crea un datetime
        /// </summary>
        /// <Datetime></returns>
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
        /// <summary>
        /// Abre el archivo de texto y lee las atracciones que están escritas
        /// </summary>
        /// <param name="atracciones"></param>
        static void ActualizarInfoAtr(List<Atraccion> atracciones)
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
    }
}
