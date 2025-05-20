using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class PersonaLugarResidencium
{
    [Key]
    public int id_Persona { get; set; }

    public int? id_Ciudad { get; set; }

    [ForeignKey("id_Ciudad")]
    [InverseProperty("PersonaLugarResidencia")]
    public virtual Ciudad? id_CiudadNavigation { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("PersonaLugarResidencium")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
