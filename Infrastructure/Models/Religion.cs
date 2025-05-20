using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Religion")]
public partial class Religion
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_ReligionNavigation")]
    public virtual ICollection<PersonaReligion> PersonaReligions { get; set; } = new List<PersonaReligion>();
}
