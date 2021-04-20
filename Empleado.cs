using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    public class Empleado : Persona
    {
        private Atraccion encargado;
        public Empleado (string nombre, DateTime fechaNacimiento, long docID): base (nombre,fechaNacimiento,docID)
        {
            encargado = null;
        }

        public void AsignarAtraccion(Atraccion atraccion)
        {
            encargado = atraccion;
        }
        public Atraccion Encargado { get => encargado;}
        public string  ConsultarInfoAtraccion()
        {
            if (encargado != null)
            {
                return encargado.Nombre;           
            }
            else
            {
                return "N/A";
            }
        }
    }
}
