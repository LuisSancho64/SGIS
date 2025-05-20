using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Index("nombre", Name = "UQ_NombreCirugia", IsUnique = true)]
public partial class Cirugium
{
    [Key]
    public int idCirugia { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string nombre { get; set; } = null!;

    [InverseProperty("idNombreCirugiaNavigation")]
    public virtual ICollection<AntecedenteCirugium> AntecedenteCirugia { get; set; } = new List<AntecedenteCirugium>();
}
