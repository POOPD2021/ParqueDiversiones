using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class ReporteCostos
    {
        private int nroIngresosDia;
        private double ingresosDiaAtraccion;
        private double costosDiaAtraccion;
        private double costosDiaTotales;
        private DateTime fecha;

        public ReporteCostos(List<Persona> personas, DateTime fechaReporte, List<Atraccion> atracciones)
        {
            
            this.ingresosDiaAtraccion = 0;
            this.costosDiaAtraccion = 0;
            this.costosDiaTotales = 0;
            this.fecha = DateTime.Now;

            CalcularNroIngresosDias(personas, fechaReporte);
            CalcularIngresosAtracciones(personas, fechaReporte, atracciones);
            CalcularCostoAtracciones(personas, fechaReporte, atracciones);
            CalcularCostoDias(personas, fechaReporte, atracciones);

        }

        public int NroIngresosDia { get => nroIngresosDia;}
        public double IngresosDiaAtraccion { get => ingresosDiaAtraccion;}
        public double CostosDiaAtraccion { get => costosDiaAtraccion;}
        public double CostosDiaTotales { get => costosDiaTotales;}
        public DateTime Fecha { get => fecha;}

        public void CalcularNroIngresosDias(List<Persona> personas, DateTime fechaReporte)
        {
            nroIngresosDia = 0;
            foreach (var item in personas)
            {
                Usuario usuario = item as Usuario;
                if (usuario.FechaIngresoParque == fechaReporte)
                {                   
                    nroIngresosDia++;
                }
            }
        }

        public void CalcularIngresosAtracciones(List<Persona> personas, DateTime fechaReporte, List<Atraccion> atracciones)
        {
            foreach (var item in atracciones)
            {
                item.TotalUsuariosIngresados = 0;
            }
            foreach (var item in personas)
            {
                Usuario usuario = item as Usuario;
                foreach (var ingreso in usuario.Dueño.IngresosAtracciones)
                {
                    if (ingreso.FechaIngreso == fechaReporte)
                    {
                        foreach (var atraccion in atracciones)
                        {
                            if(ingreso.Atraccion == atraccion)
                            {
                                atraccion.TotalUsuariosIngresados++;
                            }
                        }
                    }
                }
                
            }
        }

        public void CalcularCostoAtracciones(List<Persona> personas, DateTime fechaReporte, List<Atraccion> atracciones)
        {
            foreach (var item in atracciones)
            {
                item.TotalCostos = 0;
            }
            foreach (var item in personas)
            {
                Usuario usuario = item as Usuario;
                foreach (var ingreso in usuario.Dueño.IngresosAtracciones)
                {
                    if (ingreso.FechaIngreso == fechaReporte)
                    {
                        foreach (var atraccion in atracciones)
                        {
                            if (ingreso.Atraccion == atraccion)
                            {
                                atraccion.TotalCostos++;
                            }
                        }
                    }
                }

            }
        }

        public void CalcularCostoDias(List<Persona> personas, DateTime fechaReporte, List<Atraccion> atracciones)
        {
            costosDiaTotales = 0;
            CalcularCostoAtracciones(personas, fechaReporte, atracciones);
            foreach (var item in atracciones)
            {
                costosDiaTotales += item.TotalCostos;
            }
        }
    }
}
