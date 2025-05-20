using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("ActividadLaboral")]
public partial class ActividadLaboral
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_ActividadLaboralNavigation")]
    public virtual ICollection<PersonaActividadLaboral> PersonaActividadLaborals { get; set; } = new List<PersonaActividadLaboral>();
}
