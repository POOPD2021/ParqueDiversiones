using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Ingreso
    {
        private DateTime fechaIngreso;
        private double descuento;
        private double costo;
        private Atraccion atraccion;

        public Ingreso(DateTime fechaIngreso, double descuento, double costo, Atraccion atraccion)
        {
            this.fechaIngreso = fechaIngreso;
            this.descuento = descuento;
            this.costo = costo;
            this.atraccion = atraccion;
        }

        public DateTime FechaIngreso { get => fechaIngreso; }
        public double Descuento { get => descuento; }
        public double Costo { get => costo;}
        public Atraccion Atraccion { get => atraccion; }
    }
}
