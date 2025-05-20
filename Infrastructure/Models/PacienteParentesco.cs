using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PacienteParentesco")]
public partial class PacienteParentesco
{
    [Key]
    public int id_Paciente { get; set; }

    public int? id_Parentesco { get; set; }

    [ForeignKey("id_Paciente")]
    [InverseProperty("PacienteParentesco")]
    public virtual Paciente id_PacienteNavigation { get; set; } = null!;

    [ForeignKey("id_Parentesco")]
    [InverseProperty("PacienteParentescos")]
    public virtual Parentesco? id_ParentescoNavigation { get; set; }
}
