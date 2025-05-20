using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("TipoEnfermedad")]
[Index("nombre", Name = "UQ_NombreTipoEnfermedad", IsUnique = true)]
public partial class TipoEnfermedad
{
    [Key]
    public int idTipoEnfermedad { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string nombre { get; set; } = null!;

    [InverseProperty("idTipoEnfermedadNavigation")]
    public virtual ICollection<Enfermedad> Enfermedads { get; set; } = new List<Enfermedad>();
}
