﻿using SIFAIS.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFAIS.Datos.RepActivos
{
    public interface IRepActivosBLL
    {
        Respuesta ListRepTotalesActivo(ApplicationDbContext context);
    }
}
