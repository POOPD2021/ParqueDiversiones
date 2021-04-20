using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Virtual : Atraccion
    {
        public Virtual(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion) : base(codigo, nombre, limite_de_edad, limite_de_estatura, costo, descripcion)
        {
        }

        public override double CalcularCosto(Usuario usuario)
        {
            int contador = 0;
            double costoCalculado = costo;
          
            foreach (var item in usuario.Dueño.IngresosAtracciones)
            {
                string tipo = item.Atraccion.GetType().Name;
                if (tipo.ToUpper() == "VIRTUAL")
                {
                    contador++;
                }
            }
            if (contador > 2)
            {
                descuentos = costo * 0.05;
                costoCalculado += costo * 0.05;
            }
            return costoCalculado;
        }
        public override bool Ingresar(Usuario usuario)
        {
            if (usuario.Estatura >= limite_de_estatura && usuario.Edad >= limite_de_edad && usuario.Dueño.Saldo > costo + descuentos)
            {
                return true;
            }

            else
            {
                throw new Exception("No cumple con los requisitos");

            }
        }

    }
}
