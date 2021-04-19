using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Mecanica : Atraccion
    {
        public Mecanica(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion) : base(codigo, nombre, limite_de_edad, limite_de_estatura, costo, descripcion)
        {

        }

        public override double CalcularCosto(Usuario usuario)
        {
            bool variosIngresos= false;
            string atrAnterior = "";
            usuario.Dueño.IngresosAtracciones.Sort((s1, s2) => s1.Atraccion.Nombre.CompareTo(s2.Atraccion.Nombre));
            foreach (var item in usuario.Dueño.IngresosAtracciones)
            {
                if (item.Atraccion.Nombre.ToUpper() == atrAnterior.ToUpper()) 
                {
                    atrAnterior = item.Atraccion.Nombre;

                    variosIngresos = true;
                }
            }
            if (variosIngresos)
            {
                costo -= costo * 0.08;
            }
            return costo;
        }
    }
}
