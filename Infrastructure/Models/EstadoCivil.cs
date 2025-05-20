using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("EstadoCivil")]
public partial class EstadoCivil
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_EstadoCivilNavigation")]
    public virtual ICollection<PersonaEstadoCivil> PersonaEstadoCivils { get; set; } = new List<PersonaEstadoCivil>();
}
