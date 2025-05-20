using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models;

[Table("Enfermedad")]
[Index("nombre", Name = "UQ_NombreEnfermedad", IsUnique = true)]
public partial class Enfermedad
{
    [Key]
    public int idEnfermedad { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string nombre { get; set; } = null!;

    public int idTipoEnfermedad { get; set; }

    [InverseProperty("idEnfermedadNavigation")]
    public virtual ICollection<AntecedenteFamiliarDetalle> AntecedenteFamiliarDetalles { get; set; } = new List<AntecedenteFamiliarDetalle>();

    [InverseProperty("idEnfermedadNavigation")]
    public virtual ICollection<AntecedenteGinecologico> AntecedenteGinecologicos { get; set; } = new List<AntecedenteGinecologico>();

    [InverseProperty("idEnfermedadNavigation")]
    public virtual ICollection<AntecedenteObstetrico> AntecedenteObstetricos { get; set; } = new List<AntecedenteObstetrico>();

    [InverseProperty("idEnfermedadNavigation")]
    public virtual ICollection<AntecedentePersonal> AntecedentePersonals { get; set; } = new List<AntecedentePersonal>();

    [ForeignKey("idTipoEnfermedad")]
    [InverseProperty("Enfermedads")]
    public virtual TipoEnfermedad idTipoEnfermedadNavigation { get; set; } = null!;
}
