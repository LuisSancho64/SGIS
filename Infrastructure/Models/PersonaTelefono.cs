using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaTelefono")]
public partial class PersonaTelefono
{
    [Key]
    public int id_Persona { get; set; }

    [StringLength(10)]
    public string? celular { get; set; }

    [StringLength(10)]
    public string? convencional { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaTelefono")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
