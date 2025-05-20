using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaEstadoCivil")]
public partial class PersonaEstadoCivil
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_EstadoCivil { get; set; }

    [ForeignKey("id_EstadoCivil")]
    [InverseProperty("PersonaEstadoCivils")]
    public virtual EstadoCivil? id_EstadoCivilNavigation { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaEstadoCivil")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
