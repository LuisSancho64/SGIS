using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class AntecedenteHabitosToxico
{
    [Key]
    public int idAntecedenteHabitosToxicos { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numHistoria { get; set; } = null!;

    [Unicode(false)]
    public string descripcion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? fechaRegistro { get; set; }

    public int? idHabitoToxico { get; set; }

    [ForeignKey("idHabitoToxico")]
    [InverseProperty("AntecedenteHabitosToxicos")]
    public virtual HabitoToxico? idHabitoToxicoNavigation { get; set; }

    [ForeignKey("numHistoria")]
    [InverseProperty("AntecedenteHabitosToxicos")]
    public virtual HistoriaClinica numHistoriaNavigation { get; set; } = null!;
}
