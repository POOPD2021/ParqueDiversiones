using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    
        class Usuario : Persona
        {
            private Manilla dueño;
            private Double estatura;
            public Usuario(string nombre, DateTime fechaNacimiento, long docID, Manilla dueño, Double estatura) : base(nombre, fechaNacimiento, docID)
            {
                this.dueño = dueño;
               this.estatura = estatura;
            }

        public double Estatura { get => estatura; }
        internal Manilla Dueño { get => dueño;  }
    }
}
