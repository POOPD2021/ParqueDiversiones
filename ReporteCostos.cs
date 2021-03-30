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

        public ReporteCostos(double nroIngresosDia, double ingresosDiaAtraccion, double costosDiaAtraccion, double costosDiaTotales, DateTime fecha)
        {
            this.nroIngresosDia = nroIngresosDia;
            this.ingresosDiaAtraccion = ingresosDiaAtraccion;
            this.costosDiaAtraccion = costosDiaAtraccion;
            this.costosDiaTotales = costosDiaTotales;
            this.fecha = fecha;
        }

        public double NroIngresosDia { get => nroIngresosDia;}
        public double IngresosDiaAtraccion { get => ingresosDiaAtraccion;}
        public double CostosDiaAtraccion { get => costosDiaAtraccion;}
        public double CostosDiaTotales { get => costosDiaTotales;}
        public DateTime Fecha { get => fecha;}
    }
}
