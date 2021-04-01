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

        protected string Codigo { get => codigo; }
        protected string Nombre { get => nombre; }
        protected int Limite_de_edad { get => limite_de_edad; }
        protected double Limite_de_estatura { get => limite_de_estatura; }
        protected double Costo { get => costo; }
        protected string Descripcion { get => descripcion; }
        protected bool Operando { get => operando; }

        public Atraccion(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion)
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
