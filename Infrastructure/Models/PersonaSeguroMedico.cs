using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("PersonaSeguroMedico")]
public partial class PersonaSeguroMedico
{
    [Key]
    public int id { get; set; }

    public int? id_Persona { get; set; }

    public int? id_SeguroMedico { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaSeguroMedicos")]
    public virtual Persona? id_PersonaNavigation { get; set; }

    [ForeignKey("id_SeguroMedico")]
    [InverseProperty("PersonaSeguroMedicos")]
    public virtual SeguroMedico? id_SeguroMedicoNavigation { get; set; }
}
