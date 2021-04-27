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
        public List<Atraccion> ActualizarInfoAtr(List<Atraccion> atracciones)
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
            return atracciones;
        }
       public  void RegistrarAtraccion(Atraccion atr)
        {
            string prefijo="";

            if (atr.GetType().Name.ToUpper() == "MECANICA") 
            {
                prefijo = "MC";

            }
            else if (atr.GetType().Name.ToUpper() == "VIRTUAL")
            {
                prefijo = "VI";

            }
            else if (atr.GetType().Name.ToUpper() == "ACUATICA")
            {

                prefijo = "AC";

            }
            using (StreamWriter sw = File.AppendText("Atracciones_PD.txt"))
            {
                sw.WriteLine(prefijo + "|" + atr.Codigo + "|" + atr.Nombre + "|" + atr.Limite_de_edad + "|" + atr.Limite_de_estatura + "|" + atr.Costo + "|" + atr.Descripcion);
            }
        }
    }
}
