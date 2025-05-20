using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class Provincium
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_ProvinciaNavigation")]
    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
}
