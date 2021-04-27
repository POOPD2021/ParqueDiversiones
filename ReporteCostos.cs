using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    public class ReporteCostos
    {
        private int nroIngresosDia;
        private double costosDiaTotales;
        private DateTime fecha;
        List<Atraccion> atracciones = new List<Atraccion>();


        public ReporteCostos(List<Persona> personas, DateTime fechaReporte, List<Atraccion> atrs)
        {
            this.Atracciones = atrs;
            this.costosDiaTotales = 0;
            this.fecha = DateTime.Now;

            CalcularNroIngresosDias(personas, fechaReporte);
            CalcularInfoAtracciones(personas, fechaReporte, Atracciones);

        }

        public int NroIngresosDia { get => nroIngresosDia;}
        public double CostosDiaTotales { get => costosDiaTotales;}
        public DateTime Fecha { get => fecha;}
        public List<Atraccion> Atracciones { get => atracciones; set => atracciones = value; }

        public void CalcularNroIngresosDias(List<Persona> personas, DateTime fechaReporte)
        {
            nroIngresosDia = 0;
            foreach (var item in personas)
            {
                Usuario usuario = item as Usuario;
                if (usuario.FechaIngresoParque.ToString("dd/MM/yyyy") == fechaReporte.ToString("dd/MM/yyyy"))
                {                   
                    nroIngresosDia++;
                }
            }
        }

        public void CalcularInfoAtracciones(List<Persona> personas, DateTime fechaReporte, List<Atraccion> atracciones)
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
                    if (ingreso.FechaIngreso.ToString("dd/MM/yyyy") == fechaReporte.ToString("dd/MM/yyyy"))
                    {
                        foreach (var atraccion in atracciones)
                        {
                            if (ingreso.Atraccion == atraccion)
                            {
                                atraccion.TotalUsuariosIngresados++;
                                atraccion.TotalCostos += ingreso.Costo;
                            }
                        }
                    }
                }
            }
        }
    }
}
