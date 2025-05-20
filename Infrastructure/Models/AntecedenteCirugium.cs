using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

public partial class AntecedenteCirugium
{
    [Key]
    public int idAntecedenteCirujia { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numHistoria { get; set; } = null!;

    [Unicode(false)]
    public string descripcion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? fechaRegistro { get; set; }

    public int? idNombreCirugia { get; set; }

    [ForeignKey("idNombreCirugia")]
    [InverseProperty("AntecedenteCirugia")]
    public virtual Cirugium? idNombreCirugiaNavigation { get; set; }

    [ForeignKey("numHistoria")]
    [InverseProperty("AntecedenteCirugia")]
    public virtual HistoriaClinica numHistoriaNavigation { get; set; } = null!;
}
