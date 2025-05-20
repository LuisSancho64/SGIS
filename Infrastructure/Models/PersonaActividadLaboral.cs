using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaActividadLaboral")]
public partial class PersonaActividadLaboral
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_ActividadLaboral { get; set; }

    [ForeignKey("id_ActividadLaboral")]
    [InverseProperty("PersonaActividadLaborals")]
    public virtual ActividadLaboral? id_ActividadLaboralNavigation { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaActividadLaboral")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
