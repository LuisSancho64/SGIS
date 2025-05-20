using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("NivelInstruccion")]
public partial class NivelInstruccion
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_NivelInstruccionNavigation")]
    public virtual ICollection<PersonaInstruccion> PersonaInstruccions { get; set; } = new List<PersonaInstruccion>();
}
