using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.DTOs
{
    public class CiudadDTO
    {
        public int id { get; set; }

        public int? id_Provincia { get; set; }

        public string? nombre { get; set; }
    }
}
