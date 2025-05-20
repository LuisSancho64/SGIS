using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Alimento")]
[Index("nombre", Name = "UQ_NombreAlimento", IsUnique = true)]
public partial class Alimento
{
    [Key]
    public int idAlimento { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string nombre { get; set; } = null!;

    [InverseProperty("idAlimentoNavigation")]
    public virtual ICollection<AntecedenteIntoleranciaAlimentarium> AntecedenteIntoleranciaAlimentaria { get; set; } = new List<AntecedenteIntoleranciaAlimentarium>();
}
