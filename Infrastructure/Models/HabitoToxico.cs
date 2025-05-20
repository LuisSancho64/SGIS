using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("HabitoToxico")]
[Index("nombre", Name = "UQ_NombreHabitoToxico", IsUnique = true)]
public partial class HabitoToxico
{
    [Key]
    public int idHabitoToxico { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string nombre { get; set; } = null!;

    [InverseProperty("idHabitoToxicoNavigation")]
    public virtual ICollection<AntecedenteHabitosToxico> AntecedenteHabitosToxicos { get; set; } = new List<AntecedenteHabitosToxico>();
}
