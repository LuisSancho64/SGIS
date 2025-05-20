using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Lateralidad")]
public partial class Lateralidad
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_LateralidadNavigation")]
    public virtual ICollection<PersonaLateralidad> PersonaLateralidads { get; set; } = new List<PersonaLateralidad>();
}
