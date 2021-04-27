using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    public class Manilla
    {
        private double saldo;
        List<Ingreso> ingresosAtracciones = new List<Ingreso>();

        public Manilla()
        {
            
        }

        public double Saldo { get => saldo; }
        public List<Ingreso> IngresosAtracciones { get => ingresosAtracciones; }

        public void EntrarAtraccion(Atraccion atraccion,double costo, double descuentos)
        {
            saldo -= costo;
            DateTime fechaIngreso = DateTime.Now;
            Ingreso nuevoIngreso = new Ingreso(fechaIngreso,descuentos, costo,atraccion);
            ingresosAtracciones.Add(nuevoIngreso);
            Console.WriteLine("Ingresando a la atracción");
        }

        public void RecargarManilla(double monto)
        {
            if (monto >0)
            {
                saldo += monto;
            }
            else
            {
                throw new Exception("El valor ingresado debe ser positivo");
            }
        }
    }
    
}
