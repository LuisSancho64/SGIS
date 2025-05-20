using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("GrupoSanguineo")]
public partial class GrupoSanguineo
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_GrupoSanguineoNavigation")]
    public virtual ICollection<PersonaGrupoSanguineo> PersonaGrupoSanguineos { get; set; } = new List<PersonaGrupoSanguineo>();
}
