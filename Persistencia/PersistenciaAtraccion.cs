using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones.Persistencia
{
    public class PersistenciaAtraccion
    {
        /// <summary>
        /// Abre el archivo de texto y lee las atracciones que están escritas
        /// </summary>
        /// <param name="atracciones"></param>
        public  void ActualizarInfoAtr(List<Atraccion> atracciones)
        {
            string path = "Atracciones_PD.txt";
            string linea = "";
            string[] arregloAtr;
            using (StreamReader file = new StreamReader(path))
            {
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
       public  void RegistrarAtraccion(int tipoAtraccion, string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion, List<Atraccion> atracciones)
        {
            if (tipoAtraccion == 1)
            {
                atracciones.Add(new Mecanica("MC" + codigo, nombre, limite_de_edad, limite_de_estatura, costo, descripcion));
                Console.WriteLine("Se ha registrado una atracción mecánica con éxito.");

                using (StreamWriter sw = File.AppendText("Atracciones_PD.txt"))
                {
                    sw.WriteLine("MC" + "|" + codigo + "|" + nombre + "|" + limite_de_edad + "|" + limite_de_estatura + "|" + costo + "|" + descripcion);
                }
            }
            else if (tipoAtraccion == 2)
            {
                atracciones.Add(new Acuatica("AC" + codigo, nombre, limite_de_edad, limite_de_estatura, costo, descripcion));
                Console.WriteLine("Se ha registrado una atracción acuática con éxito.");

                using (StreamWriter sw = File.AppendText("Atracciones_PD.txt"))
                {
                    sw.WriteLine("AC" + "|" + codigo + "|" + nombre + "|" + limite_de_edad + "|" + limite_de_estatura + "|" + costo + "|" + descripcion);
                }
            }
            else if (tipoAtraccion == 3)
            {
                atracciones.Add(new Virtual("VI" + codigo, nombre, limite_de_edad, limite_de_estatura, costo, descripcion));
                Console.WriteLine("Se ha registrado una atracción virtual con éxito.");

                using (StreamWriter sw = File.AppendText("Atracciones_PD.txt"))
                {
                    sw.WriteLine("VI" + "|" + codigo + "|" + nombre + "|" + limite_de_edad + "|" + limite_de_estatura + "|" + costo + "|" + descripcion);
                }
            }
        }
    }
}
