using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Atraccion
    {
        private string codigo;
        private string nombre;
        private int limite_de_edad;
        private double limite_de_estatura;
        private double costo;
        private string descripcion;
        private bool operando;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Limite_de_edad { get => limite_de_edad; set => limite_de_edad = value; }
        public double Limite_de_estatura { get => limite_de_estatura; set => limite_de_estatura = value; }
        public double Costo { get => costo; set => costo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Operando { get => operando; set => operando = value; }


    }
}
