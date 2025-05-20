using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaDireccion")]
public partial class PersonaDireccion
{
    [Key]
    public int id_Persona { get; set; }

    [StringLength(100)]
    public string? callePrincipal { get; set; }

    [StringLength(100)]
    public string? calleSecundaria1 { get; set; }

    [StringLength(100)]
    public string? calleSecundaria2 { get; set; }

    [StringLength(50)]
    public string? numeroCasa { get; set; }

    [StringLength(100)]
    public string? referencia { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaDireccion")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
