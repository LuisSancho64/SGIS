using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("AntecedenteObstetrico")]
public partial class AntecedenteObstetrico
{
    [Key]
    public int idAntecedenteObstetrico { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numHistoria { get; set; } = null!;

    public bool? embarazoActual { get; set; }

    public bool? gestasPrevias { get; set; }

    public bool? partos { get; set; }

    public bool? abortos { get; set; }

    public bool? cesareas { get; set; }

    public int? nacidosVivos { get; set; }

    public int? nacidosMuertos { get; set; }

    public int? hijosVivos { get; set; }

    public bool? lactancia { get; set; }

    public int? idEnfermedad { get; set; }

    [ForeignKey("idEnfermedad")]
    [InverseProperty("AntecedenteObstetricos")]
    public virtual Enfermedad? idEnfermedadNavigation { get; set; }

    [ForeignKey("numHistoria")]
    [InverseProperty("AntecedenteObstetricos")]
    public virtual HistoriaClinica numHistoriaNavigation { get; set; } = null!;
}
