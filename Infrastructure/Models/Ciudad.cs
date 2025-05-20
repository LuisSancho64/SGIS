using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Ciudad")]
public partial class Ciudad
{
    [Key]
    public int id { get; set; }

    public int? id_Provincia { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [InverseProperty("id_CiudadNavigation")]
    public virtual ICollection<PersonaLugarResidencium> PersonaLugarResidencia { get; set; } = new List<PersonaLugarResidencium>();

    [ForeignKey("id_Provincia")]
    [InverseProperty("Ciudads")]
    public virtual Provincium? id_ProvinciaNavigation { get; set; }
}
