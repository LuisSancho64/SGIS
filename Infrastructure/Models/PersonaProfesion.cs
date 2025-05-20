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

    [Key]
    public int id_Profesion { get; set; }

    [ForeignKey(nameof(id_Persona))]
    [InverseProperty("PersonaProfesions")]
    public virtual Persona? Persona { get; set; }

    [ForeignKey(nameof(id_Profesion))]
    [InverseProperty("PersonaProfesions")]
    public virtual Profesion? id_ProfesionNavigation { get; set; }
}

