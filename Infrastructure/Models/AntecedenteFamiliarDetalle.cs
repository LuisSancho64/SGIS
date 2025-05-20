using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("AntecedenteFamiliarDetalle")]
public partial class AntecedenteFamiliarDetalle
{
    [Key]
    public int idAntecedenteFamiliarDetalle { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string numHistoria { get; set; } = null!;

    [Unicode(false)]
    public string descripcion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? fechaRegistro { get; set; }

    public int? idEnfermedad { get; set; }

    [ForeignKey("idEnfermedad")]
    [InverseProperty("AntecedenteFamiliarDetalles")]
    public virtual Enfermedad? idEnfermedadNavigation { get; set; }

    [ForeignKey("numHistoria")]
    [InverseProperty("AntecedenteFamiliarDetalles")]
    public virtual HistoriaClinica numHistoriaNavigation { get; set; } = null!;
}
