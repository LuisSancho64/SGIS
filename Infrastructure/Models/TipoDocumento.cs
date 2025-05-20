using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("TipoDocumento")]
public partial class TipoDocumento
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_TipoDocumentoNavigation")]
    public virtual ICollection<PersonaDocumento> PersonaDocumentos { get; set; } = new List<PersonaDocumento>();
}
