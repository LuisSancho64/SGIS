using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaGrupoSanguineo")]
public partial class PersonaGrupoSanguineo
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_GrupoSanguineo { get; set; }

    [ForeignKey("id_GrupoSanguineo")]
    [InverseProperty("PersonaGrupoSanguineos")]
    public virtual GrupoSanguineo? id_GrupoSanguineoNavigation { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaGrupoSanguineo")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
