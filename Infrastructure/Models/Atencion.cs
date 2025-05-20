using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Atencion")]
public partial class Atencion
{
    [Key]
    public int idAtencion { get; set; }

    public DateOnly fechaAtencion { get; set; }

    public int? idPaciente { get; set; }

    [InverseProperty("idAtencionNavigation")]
    public virtual ICollection<Evolucion> Evolucions { get; set; } = new List<Evolucion>();

    [ForeignKey("idPaciente")]
    [InverseProperty("Atencions")]
    public virtual Paciente? idPacienteNavigation { get; set; }
}
