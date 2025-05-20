using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Parentesco")]
public partial class Parentesco
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_ParentescoNavigation")]
    public virtual ICollection<PacienteParentesco> PacienteParentescos { get; set; } = new List<PacienteParentesco>();
}
