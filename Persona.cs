using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    public class Persona
    {
        private string nombre;
        private long docID;
        private DateTime fechaNacimiento;
        private int edad;

        public Persona(string nombre, DateTime fechaNacimiento, long docID)
        {
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.edad = (DateTime.Now.Year - fechaNacimiento.Year);
            this.docID = docID;
        }


        public string Nombre { get => nombre;}
        public long DocID { get => docID; }
        public DateTime FechaNacimiento { get => fechaNacimiento; }
        public int Edad { get => edad; }

        
    }
}
