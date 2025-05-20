using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaProfesion")]
public partial class PersonaProfesion
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_Profesion { get; set; }

    [InverseProperty("idNavigation")]
    public virtual Persona? Persona { get; set; }

    [ForeignKey("id_Profesion")]
    [InverseProperty("PersonaProfesions")]
    public virtual Profesion? id_ProfesionNavigation { get; set; }
}
