using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMI.Shared.DTOs
{
    public class PersonaDTO
    {
        public int id { get; set; }
        public int? id_Genero { get; set; }
        public string? nombre { get; set; }
        public string? nombre2 { get; set; }
        public string? apellido { get; set; }
        public string? apellido2 { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Correo { get; set; }

        //DIRECCION
        public List<PersonaDireccionDTO>? Direccion { get; set; }

        //TELEFONO
        public PersonaTelefonoDTO? Telefono { get; set; }

        //ESTADO CIVIL
        public EstadoCivilDTO EstadoCivil { get; set; }

        //SEGUROMEDICO
        public List<SeguroMedicoDTO>? SegurosMedicos { get; set; }

        //DOCUMENTOS
        public PersonaDocumentoDTO? Documento { get; set; }

        //LATERALIDAD
        public PersonaLateralidadDTO? Lateralidad { get; set; }

        //RELIGION
        public ReligionDTO? Religion { get; set; }

        //LUGAR DE RESIDENCIA
        public PersonaLugarResidenciaDTO? LugarResidencia { get; set; }

        //PROFESIONAL DE SALUD
        public ProfesionalSaludDTO? ProfesionalSalud { get; set; }

        // GRUPO SANGUÍNEO
        public GrupoSanguineoDTO? GrupoSanguineo { get; set; }

        //PROFESIONES
        public List<ProfesionDTO> profesiones { get; set; } = new ();

        //ACTIVIDAD LABORAL
        public List<ActividadLaboralDTO> ActividadLaboral { get; set; } = new List<ActividadLaboralDTO>();

        //INSTRUCCION
        public NivelInstruccionDTO? Instruccion { get; set; }

    }
}
