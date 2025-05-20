using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class AntecedenteAlergium
{
    [Key]
    public int idAntecedenteAlergia { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numHistoria { get; set; } = null!;

    [Unicode(false)]
    public string descripcion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? fechaRegistro { get; set; }

    public int? idAlergia { get; set; }

    [ForeignKey("idAlergia")]
    [InverseProperty("AntecedenteAlergia")]
    public virtual Alergium? idAlergiaNavigation { get; set; }

    [ForeignKey("numHistoria")]
    [InverseProperty("AntecedenteAlergia")]
    public virtual HistoriaClinica numHistoriaNavigation { get; set; } = null!;
}
