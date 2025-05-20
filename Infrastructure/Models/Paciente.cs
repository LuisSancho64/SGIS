using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Paciente")]
public partial class Paciente
{
    [Key]
    public int id_Persona { get; set; }

    [InverseProperty("idPacienteNavigation")]
    public virtual ICollection<Atencion> Atencions { get; set; } = new List<Atencion>();

    [InverseProperty("id_PacienteNavigation")]
    public virtual ICollection<ContactoEmergencium> ContactoEmergencia { get; set; } = new List<ContactoEmergencium>();

    [InverseProperty("idPacienteNavigation")]
    public virtual ICollection<HistoriaClinica> HistoriaClinicas { get; set; } = new List<HistoriaClinica>();

    [InverseProperty("id_PacienteNavigation")]
    public virtual PacienteParentesco? PacienteParentesco { get; set; }

    [ForeignKey("id_Persona")]
    [InverseProperty("Paciente")]
    public virtual Persona id_PersonaNavigation { get; set; } = null!;
}
