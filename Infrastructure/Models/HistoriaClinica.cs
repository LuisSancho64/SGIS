using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("HistoriaClinica")]
[Index("numeroHistoria", Name = "UQ_NumeroHistoria", IsUnique = true)]
[Index("numeroHistoria", Name = "UQ__Historia__A23988ADD4EC9488", IsUnique = true)]
public partial class HistoriaClinica
{
    [Key]
    public int idHistoriaClinica { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numeroHistoria { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? fechaCreacion { get; set; }

    public bool? activa { get; set; }

    [Unicode(false)]
    public string? observacionesGenerales { get; set; }

    public int? idPaciente { get; set; }

    [InverseProperty("numHistoriaNavigation")]
    public virtual ICollection<AntecedenteAlergium> AntecedenteAlergia { get; set; } = new List<AntecedenteAlergium>();

    [InverseProperty("numHistoriaNavigation")]
    public virtual ICollection<AntecedenteCirugium> AntecedenteCirugia { get; set; } = new List<AntecedenteCirugium>();

    [InverseProperty("numHistoriaNavigation")]
    public virtual ICollection<AntecedenteFamiliarDetalle> AntecedenteFamiliarDetalles { get; set; } = new List<AntecedenteFamiliarDetalle>();

    [InverseProperty("numHistoriaNavigation")]
    public virtual ICollection<AntecedenteGinecologico> AntecedenteGinecologicos { get; set; } = new List<AntecedenteGinecologico>();

    [InverseProperty("numHistoriaNavigation")]
    public virtual ICollection<AntecedenteHabitosToxico> AntecedenteHabitosToxicos { get; set; } = new List<AntecedenteHabitosToxico>();

    [InverseProperty("numHistoriaNavigation")]
    public virtual ICollection<AntecedenteIntoleranciaAlimentarium> AntecedenteIntoleranciaAlimentaria { get; set; } = new List<AntecedenteIntoleranciaAlimentarium>();

    [InverseProperty("numHistoriaNavigation")]
    public virtual ICollection<AntecedenteObstetrico> AntecedenteObstetricos { get; set; } = new List<AntecedenteObstetrico>();

    [InverseProperty("numHistoriaNavigation")]
    public virtual ICollection<AntecedentePersonal> AntecedentePersonals { get; set; } = new List<AntecedentePersonal>();

    [ForeignKey("idPaciente")]
    [InverseProperty("HistoriaClinicas")]
    public virtual Paciente? idPacienteNavigation { get; set; }
}
