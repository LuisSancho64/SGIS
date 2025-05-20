using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.DTOs
{
    public class PersonaLugarResidenciaDTO
    {
        public int? id_Ciudad { get; set; }
        public string? nombreCiudad { get; set; }

        public int? id_Provincia { get; set; }
        public string? nombreProvincia { get; set; }
    }
}
