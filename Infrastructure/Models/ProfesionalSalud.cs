using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("ProfesionalSalud")]
public partial class ProfesionalSalud
{
    [Key]
    public int id_ProfesionalSalud { get; set; }

    public int? id_TipoProfesional { get; set; }

    [StringLength(50)]
    public string? numeroRegistro { get; set; }

    [ForeignKey("id_ProfesionalSalud")]
    [InverseProperty("ProfesionalSalud")]
    public virtual Persona id_ProfesionalSaludNavigation { get; set; } = null!;

    [ForeignKey("id_TipoProfesional")]
    [InverseProperty("ProfesionalSaluds")]
    public virtual TipoProfesionalSalud? id_TipoProfesionalNavigation { get; set; }
}
