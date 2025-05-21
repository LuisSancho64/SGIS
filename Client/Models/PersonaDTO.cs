namespace SMI.Client.Models
{
    public class PersonaDto
    {
        public int id { get; set; }
        public int id_Genero { get; set; }
        public string nombre { get; set; }
        public string nombre2 { get; set; }
        public string apellido { get; set; }
        public string apellido2 { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string correo { get; set; }
        public List<Direccion> direccion { get; set; }
        public Telefono telefono { get; set; }
        public EstadoCivil estadoCivil { get; set; }
        public List<SeguroMedico> segurosMedicos { get; set; }
        public Documento documento { get; set; }
        public Lateralidad lateralidad { get; set; }
        public Religion religion { get; set; }
        public LugarResidencia lugarResidencia { get; set; }
        public ProfesionalSalud profesionalSalud { get; set; }
        public GrupoSanguineo grupoSanguineo { get; set; }
        public List<Profesion> profesiones { get; set; }
        public List<ActividadLaboral> actividadLaboral { get; set; }
        public Instruccion instruccion { get; set; }
    }
}
