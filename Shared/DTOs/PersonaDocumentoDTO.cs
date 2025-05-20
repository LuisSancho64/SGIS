using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.DTOs
{
    public class PersonaDocumentoDTO
    {
        public int id_Persona { get; set; }

        public int? id_TipoDocumento { get; set; }

        public string? numeroDocumento { get; set; }

        public string? nombreTipoDocumento { get; set; }
    }
}
