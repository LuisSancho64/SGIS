using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaDocumento")]
public partial class PersonaDocumento
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_TipoDocumento { get; set; }

    [StringLength(10)]
    public string? numeroDocumento { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaDocumento")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;

    [ForeignKey("id_TipoDocumento")]
    [InverseProperty("PersonaDocumentos")]
    public virtual TipoDocumento? id_TipoDocumentoNavigation { get; set; }
}
