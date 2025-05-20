using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Profesion")]
public partial class Profesion
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_ProfesionNavigation")]
    public virtual ICollection<PersonaProfesion> PersonaProfesions { get; set; } = new List<PersonaProfesion>();
}
