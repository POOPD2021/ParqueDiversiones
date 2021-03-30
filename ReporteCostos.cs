using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class ReporteCostos
    {
        private double nroIngresosDia;
        private double ingresosDiaAtraccion;
        private double costosDiaAtraccion;
        private double costosDiaTotales;
        private DateTime fecha;

        public double NroIngresosDia { get => nroIngresosDia;}
        public double IngresosDiaAtraccion { get => ingresosDiaAtraccion;}
        public double CostosDiaAtraccion { get => costosDiaAtraccion;}
        public double CostosDiaTotales { get => costosDiaTotales;}
        public DateTime Fecha { get => fecha;}
    }
}
