using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("SeguroMedico")]
public partial class SeguroMedico
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_SeguroMedicoNavigation")]
    public virtual ICollection<PersonaSeguroMedico> PersonaSeguroMedicos { get; set; } = new List<PersonaSeguroMedico>();
}
