using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaLateralidad")]
public partial class PersonaLateralidad
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_Lateralidad { get; set; }

    [ForeignKey("id_Lateralidad")]
    [InverseProperty("PersonaLateralidads")]
    public virtual Lateralidad? id_LateralidadNavigation { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaLateralidad")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
