using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    public class Usuario : Persona
    {
        private Manilla dueño;
        private Double estatura;
        private DateTime fechaIngresoParque;

        public Usuario(string nombre, DateTime fechaNacimiento, long docID, Double estatura) : base(nombre, fechaNacimiento, docID)
        { 
            this.estatura = estatura;
            GenerarManilla();
            this.fechaIngresoParque = DateTime.Now;
        }

        public double Estatura { get => estatura; }
        public DateTime FechaIngresoParque { get => fechaIngresoParque;}
        public Manilla Dueño { get => dueño; }
       
        public void GenerarManilla()
        {
            dueño = new Manilla();
        }
        public override string ToString()
        {
            return "Nombre:  " + Nombre + "   | Documento: " + DocID+ "   |Saldo: " + Dueño.Saldo.ToString();
        }
    }
}
