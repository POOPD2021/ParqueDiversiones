using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Acuatica : Atraccion
    {
        public Acuatica(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion) : base(codigo, nombre, limite_de_edad, limite_de_estatura, costo, descripcion)
        {
            
        }

        public override double CalcularCosto(Usuario usuario)
        {
            if(usuario.Edad>=45&& usuario.Edad <= 50)
            {
                descuentos = costo * 0.07;
                costo -= descuentos;
            }
            return costo;
        }

       
    }
}
