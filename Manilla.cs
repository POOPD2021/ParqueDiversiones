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

        public Manilla(double saldo, List<Ingreso> ingresosAtracciones)
        {
            this.saldo = saldo;
            this.ingresosAtracciones = ingresosAtracciones;
        }

        public double Saldo { get => saldo; }
        internal List<Ingreso> IngresosAtracciones { get => ingresosAtracciones; }
    }
    public void EntrarAtraccion(Atraccion atraccion)
    {

    }

    public void RecargarManilla(double recargar)
    {

    }
}
