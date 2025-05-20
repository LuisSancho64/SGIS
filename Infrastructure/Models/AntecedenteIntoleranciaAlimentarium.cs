using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class AntecedenteIntoleranciaAlimentarium
{
    [Key]
    public int idAntecedenteIntoleranciaAlimentaria { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numHistoria { get; set; } = null!;

    [Unicode(false)]
    public string descripcion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? fechaRegistro { get; set; }

    public int? idAlimento { get; set; }

    [ForeignKey("idAlimento")]
    [InverseProperty("AntecedenteIntoleranciaAlimentaria")]
    public virtual Alimento? idAlimentoNavigation { get; set; }

    [ForeignKey("numHistoria")]
    [InverseProperty("AntecedenteIntoleranciaAlimentaria")]
    public virtual HistoriaClinica numHistoriaNavigation { get; set; } = null!;
}
