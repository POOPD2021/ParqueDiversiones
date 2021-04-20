using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    public class Mecanica : Atraccion
    {
        public Mecanica(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion) : base(codigo, nombre, limite_de_edad, limite_de_estatura, costo, descripcion)
        {

        }

        public override double CalcularCosto(Usuario usuario)
        {

            int contador = 0;
            double costoCalculado = costo;
            
            foreach (var item in usuario.Dueño.IngresosAtracciones)
            {
                if (item.Atraccion.Nombre.ToUpper() == nombre.ToUpper()) 
                {
                    contador++;
                 
                }
            }
            if (contador>=2)
            {
                descuentos = costo * 0.08;
                costoCalculado -= descuentos;
            }
            return costoCalculado;
        }
    }
}
