﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueDiversiones
{
    class Virtual : Atraccion
    {
        public Virtual(string codigo, string nombre, int limite_de_edad, double limite_de_estatura, double costo, string descripcion) : base(codigo, nombre, limite_de_edad, limite_de_estatura, costo, descripcion)
        {

        }
    }
}