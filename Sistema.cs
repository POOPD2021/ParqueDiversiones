using System;
using System.Collections.Generic;
using System.IO;
using ParqueDiversiones.Persistencia;
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
            PersistenciaAtraccion prAtraccion = new PersistenciaAtraccion();

            prAtraccion.ActualizarInfoAtr(atracciones); //Asegura que la informacion acerca de las atracciones se va actualizar cada que se inicie el programa
            
            int opcion = default;
            do
            {
                try
                {
                    Menu();

                    switch (opcion = int.Parse(Console.ReadLine()))
                    {

                        case 1:
                            GenerarReporte(personas, atracciones);
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

                                Console.WriteLine("Por favor, ingrese su estatura (En cm. Sin puntos ni comas)");
                                double estatura = double.Parse(Console.ReadLine());
                                personas.Add(new Usuario(nombre, fechaNacimiento, docID, estatura));
                                Console.WriteLine("Se ha registrado el usuario con éxito y se le ha asignado una manilla con un saldo de $0");
                            }
                            else if (tipoPersona == 2)
                            {
                                personas.Add(new Empleado(nombre, fechaNacimiento, docID));

                                Console.WriteLine("Se ha registrado un empleado con éxito");

                            }


                            break;

                        case 3:
                            personas.Sort((s1, s2) => s1.GetType().Name.CompareTo(s2.GetType().Name));
                            personas.Reverse();
                            Console.WriteLine("Escoja a cuál usuario desea recargar la manilla:");
                            ConsultarInfoUsuarios(personas);
                            int usuarioEscogido = int.Parse(Console.ReadLine())-1;
                            Console.WriteLine("¿Cuánto dinero desea recargar?");
                            double saldoRecarga = double.Parse(Console.ReadLine());
                            Usuario usuario = personas[usuarioEscogido] as Usuario;
                            usuario.Dueño.RecargarManilla(saldoRecarga);
                            Console.WriteLine("Se ha recargado con éxito!");
                            break;

                        case 4:

                            Console.WriteLine("¿Qué tipo de atracción es? 1. Mecánica/ 2. Acuática / 3. Virtual");
                            int tipoAtraccion = int.Parse(Console.ReadLine());
                            if (tipoAtraccion != 1 && tipoAtraccion != 2 && tipoAtraccion != 3)
                            {
                                Console.WriteLine("Ha ocurrido un error. Vuelva a intentarlo.");
                                return;
                            }
                            Console.WriteLine("Por favor, ingrese el código");
                            string codigoA = Console.ReadLine();
                            Console.WriteLine("Por favor, ingrese el nombre");
                            string nombreA = Console.ReadLine();
                            Console.WriteLine("Por favor, ingrese el límite de edad");
                            int limite_de_edadA = int.Parse(Console.ReadLine());
                            Console.WriteLine("Por favor, ingrese el límite de estatura");
                            double limite_de_estaturaA = double.Parse(Console.ReadLine());
                            Console.WriteLine("Por favor, ingrese el costo");
                            double costoA = double.Parse(Console.ReadLine());
                            Console.WriteLine("Por favor, ingrese una descripción de la atracción");
                            string descripcionA = Console.ReadLine();

                            prAtraccion.RegistrarAtraccion(tipoAtraccion, codigoA, nombreA, limite_de_edadA, limite_de_estaturaA, costoA, descripcionA, atracciones);
                            break;

                        case 5:
                          
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
                        case 10:
                            personas.Sort((s1, s2) => s1.GetType().Name.CompareTo(s2.GetType().Name));
                            personas.Reverse();
                            ConsultarInfoUsuarios(personas);

                            Console.WriteLine("Escoja el usuario para ingresar a la atracción: ");
                            int usrEscogido = int.Parse(Console.ReadLine())-1;
                            ListarAtracciones(atracciones);
                            Console.WriteLine("Escoja la atracción");
                            int atraccion = int.Parse(Console.ReadLine())-1;

                            Usuario usr = personas[usrEscogido] as Usuario;
                            
                           
                            bool ingreso =atracciones[atraccion].Ingresar(usr);
                            

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
            Console.WriteLine("[1] Generar reporte");//falta Stefa
            Console.WriteLine("[2] Registrar persona");
            Console.WriteLine("[3] Recargar manilla");//falta  Pablo
            Console.WriteLine("[4] Registrar atracción");//listo
            Console.WriteLine("[5] Consultar información atracción");//listo
            Console.WriteLine("[6] Consultar información usuarios");//listo
            Console.WriteLine("[7] Consultar información empleados");//listo
            Console.WriteLine("[8] Asignar atracción a un empleado");
            Console.WriteLine("[9] Listar atracciones");//ya
            Console.WriteLine("[10] Ingresar a atracción");//falta Samuel
            Console.WriteLine("[0] Salir");
            Console.WriteLine("=========================================");
        }

        static void GenerarReporte(List<Persona> personas, List<Atraccion> atracciones)
        {
            
            ReporteCostos rc = new ReporteCostos(personas, DateTime.Now, atracciones);
            Console.WriteLine("Numero de ingresos por día: " + rc.NroIngresosDia);
            Console.WriteLine("Fecha:" + rc.Fecha);
            foreach (var item in rc.Atracciones) 
            {
               
                Console.WriteLine("Atraccion: " + item.Nombre+ " Total usuarios por día: "+item.TotalUsuariosIngresados +" Ganancias totales por dia: "+ item.TotalCostos);
            }
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
                    Usuario usuario = item as Usuario; //Permite consultar las propiedades del usuario conviertiendo el objecto persona en usuario
                    if (usuario != null) //si hay un usuario en la lista de personas
                    {
                    Console.WriteLine(contadorUsuarios + 1 + " )" + "| Tipo: " + usuario.GetType().Name + "  | Nombre: " + usuario.Nombre + "| Saldo: " + usuario.Dueño.Saldo +  "| Documento: " + usuario.DocID + "| Edad: " + usuario.Edad + "| Estaura:" + usuario.Estatura);
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
                Empleado empleado = item as Empleado;//Permite consultar las propiedades del empleado conviertiendo el objecto persona en empleado
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
        /// Pregunta la fecha en el formata Año/mes/dia, los guarda en un arreglo y crea un datetime
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
       

    }
}
