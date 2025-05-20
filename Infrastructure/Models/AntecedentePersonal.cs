using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("AntecedentePersonal")]
public partial class AntecedentePersonal
{
    [Key]
    public int idAntecedentePersonal { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numHistoria { get; set; } = null!;

    [Unicode(false)]
    public string descripcion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? fechaRegistro { get; set; }

    public int? idEnfermedad { get; set; }

    [ForeignKey("idEnfermedad")]
    [InverseProperty("AntecedentePersonals")]
    public virtual Enfermedad? idEnfermedadNavigation { get; set; }

    [ForeignKey("numHistoria")]
    [InverseProperty("AntecedentePersonals")]
    public virtual HistoriaClinica numHistoriaNavigation { get; set; } = null!;
}
