using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    public abstract class Atraccion
    {
        protected string codigo;
        protected string nombre;
        protected int limite_de_edad;
        protected double limite_de_estatura;
        protected double costo;
        protected string descripcion;
        protected bool operando;
        protected double descuentos;

        public string Codigo { get => codigo; }
        public string Nombre { get => nombre; }
        public int Limite_de_edad { get => limite_de_edad; }
        public double Limite_de_estatura { get => limite_de_estatura; }
        public double Costo { get => costo; }
        public string Descripcion { get => descripcion; }
        public bool Operando { get => operando; set => operando = value; }

        public Atraccion(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.limite_de_edad = limite_de_edad;
            this.limite_de_estatura = limite_de_estatura;
            this.costo = costo;
            this.descripcion = descripcion;
            Operando = false;
        }

     
        public virtual bool Ingresar(Usuario usuario)
        {
          if(usuario.Estatura>=limite_de_estatura && usuario.Edad >= limite_de_edad && usuario.Dueño.Saldo>=costo-descuentos)
            {

                usuario.Dueño.EntrarAtraccion(this, CalcularCosto(usuario), descuentos);
                return true;
            }

          else
            {
                throw new Exception("No cumple con los requisitos");

            }
        }

        public abstract double  CalcularCosto(Usuario usuario);
       
        public string ConsultarEstado()
        {
            if (operando)
            {
                return "Está funcionando ahora mismo";
            }
            else
            {
                return "No está funcionando en estos momentos";
            }
        }
    }
}
