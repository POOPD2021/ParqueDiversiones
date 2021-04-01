using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Manilla
    {
        private double saldo;
        List<Ingreso> ingresosAtracciones = new List<Ingreso>();

        public Manilla(double saldo)
        {
            this.saldo = saldo;
        }

        public double Saldo { get => saldo; }
        internal List<Ingreso> IngresosAtracciones { get => ingresosAtracciones; }

        public void EntrarAtraccion(Atraccion atraccion)
        {

        }

        public void RecargarManilla(double recargar)
        {

        }
    }
    
}
