using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaReligion")]
public partial class PersonaReligion
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_Religion { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaReligion")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;

    [ForeignKey("id_Religion")]
    [InverseProperty("PersonaReligions")]
    public virtual Religion? id_ReligionNavigation { get; set; }
}
