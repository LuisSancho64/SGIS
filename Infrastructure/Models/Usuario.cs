using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int Id { get; set; }

        public int? Id_Persona { get; set; }

        [StringLength(255)]
        public string? Clave { get; set; }

        public bool? Activo { get; set; }

        [ForeignKey("Id_Persona")]
        [InverseProperty("Usuario")]
        public virtual Persona? Id_PersonaNavigation { get; set; }
    }
}
