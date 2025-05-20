using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class ContactoEmergencium
{
    [Key]
    public int id { get; set; }

    public int id_Paciente { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [StringLength(10)]
    public string? telefono { get; set; }

    [StringLength(100)]
    public string? correo { get; set; }

    [ForeignKey("id_Paciente")]
    [InverseProperty("ContactoEmergencia")]
    public virtual Paciente id_PacienteNavigation { get; set; } = null!;
}
