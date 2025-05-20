using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Evolucion")]
public partial class Evolucion
{
    [Key]
    public int idEvolucion { get; set; }

    [Unicode(false)]
    public string observacion { get; set; } = null!;

    public double porcentajeEvolucion { get; set; }

    public int idAtencion { get; set; }

    [ForeignKey("idAtencion")]
    [InverseProperty("Evolucions")]
    public virtual Atencion idAtencionNavigation { get; set; } = null!;
}
