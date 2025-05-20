using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Persona")]
public partial class Persona
{
    [Key]
    public int id { get; set; }


    public int? id_Genero { get; set; }

    [StringLength(100)]
    public string? nombre { get; set; }

    [StringLength(100)]
    public string? nombre2 { get; set; }

    [StringLength(100)]
    public string? apellido { get; set; }

    [StringLength(100)]
    public string? apellido2 { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    [StringLength(255)]
    public string? Correo { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual Paciente? Paciente { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaActividadLaboral? PersonaActividadLaboral { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaDireccion? PersonaDireccion { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaDocumento? PersonaDocumento { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaEstadoCivil? PersonaEstadoCivil { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaGrupoSanguineo? PersonaGrupoSanguineo { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaInstruccion? PersonaInstruccion { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaLateralidad? PersonaLateralidad { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaLugarResidencium? PersonaLugarResidencium { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaReligion? PersonaReligion { get; set; }

    [InverseProperty("id_PersonaNavigation")]
    public virtual ICollection<PersonaSeguroMedico> PersonaSeguroMedicos { get; set; } = new List<PersonaSeguroMedico>();

    [InverseProperty("id_PersonaNavigation")]
    public virtual PersonaTelefono? PersonaTelefono { get; set; }

    [InverseProperty("id_ProfesionalSaludNavigation")]
    public virtual ProfesionalSalud? ProfesionalSalud { get; set; }

    [ForeignKey("id")]
    [InverseProperty("Persona")]
    public virtual PersonaProfesion idNavigation { get; set; } = null!;

    [ForeignKey("id_Genero")]
    [InverseProperty("Personas")]
    public virtual Genero? id_GeneroNavigation { get; set; }

    [InverseProperty("Id_PersonaNavigation")]
    public virtual Usuario? Usuario { get; set; }

}
