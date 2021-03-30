using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Atraccion
    {
        protected string codigo;
        protected string nombre;
        protected int limite_de_edad;
        protected double limite_de_estatura;
        protected double costo;
        protected string descripcion;
        protected bool operando;

        protected string Codigo { get => codigo; set => codigo = value; }
        protected string Nombre { get => nombre; set => nombre = value; }
        protected int Limite_de_edad { get => limite_de_edad; set => limite_de_edad = value; }
        protected double Limite_de_estatura { get => limite_de_estatura; set => limite_de_estatura = value; }
        protected double Costo { get => costo; set => costo = value; }
        protected string Descripcion { get => descripcion; set => descripcion = value; }
        protected bool Operando { get => operando; set => operando = value; }

        public Atraccion()
        {
            
        }

        public bool Ingresar()
        {
            return true;
        }

        private void CalcularCosto()
        {

        }
    }
}
