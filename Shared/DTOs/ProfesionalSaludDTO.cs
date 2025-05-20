using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.DTOs
{
    public class ProfesionalSaludDTO
    {
        public int id_ProfesionalSalud { get; set; }

        public int? id_TipoProfesional { get; set; }

        public string? numeroRegistro { get; set; }

        public string? nombreTipoProfesional { get; set; }
    }
}
