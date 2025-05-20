using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Index("nombre", Name = "UQ_NombreAlergia", IsUnique = true)]
public partial class Alergium
{
    [Key]
    public int idAlergia { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string nombre { get; set; } = null!;

    [InverseProperty("idAlergiaNavigation")]
    public virtual ICollection<AntecedenteAlergium> AntecedenteAlergia { get; set; } = new List<AntecedenteAlergium>();
}
