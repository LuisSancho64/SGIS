using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaInstruccion")]
public partial class PersonaInstruccion
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_NivelInstruccion { get; set; }

    [ForeignKey("id_NivelInstruccion")]
    [InverseProperty("PersonaInstruccions")]
    public virtual NivelInstruccion? id_NivelInstruccionNavigation { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaInstruccion")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
