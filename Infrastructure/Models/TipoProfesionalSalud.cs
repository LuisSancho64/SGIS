using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("TipoProfesionalSalud")]
public partial class TipoProfesionalSalud
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_TipoProfesionalNavigation")]
    public virtual ICollection<ProfesionalSalud> ProfesionalSaluds { get; set; } = new List<ProfesionalSalud>();
}
