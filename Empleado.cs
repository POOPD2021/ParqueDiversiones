using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Empleado : Persona
    {
        private Atraccion encargado;
        public Empleado (string nombre, DateTime fechaNacimiento, long docID, Atraccion atraccion): base (nombre,fechaNacimiento,docID)
        {
            this.encargado = atraccion;
        }
        public void AsignarAtraccion(Atraccion atraccion)
        {

        }
    }
}
