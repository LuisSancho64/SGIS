using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("AntecedenteGinecologico")]
public partial class AntecedenteGinecologico
{
    [Key]
    public int idAntecedenteGinecologico { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numHistoria { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? desarrolloGinecologico { get; set; }

    public DateOnly? menarquia { get; set; }

    public DateOnly? pubarquia { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ciclosMenstruales { get; set; }

    public DateOnly? ultimaMenstruacion { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? metodosAnticonceptivos { get; set; }

    public int? idEnfermedad { get; set; }

    [ForeignKey("idEnfermedad")]
    [InverseProperty("AntecedenteGinecologicos")]
    public virtual Enfermedad? idEnfermedadNavigation { get; set; }

    [ForeignKey("numHistoria")]
    [InverseProperty("AntecedenteGinecologicos")]
    public virtual HistoriaClinica numHistoriaNavigation { get; set; } = null!;
}
