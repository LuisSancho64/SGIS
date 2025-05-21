using System.Threading.Tasks;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SMI.Shared.DTOs;

namespace API.Controllers
{
    public class ComplementosController : ControllerBase
    {
        private readonly SmiDbContext _context;

        public ComplementosController(SmiDbContext context)
        {
            _context = context;
        }
        //SEGUROS
        [HttpGet("seguros")]
        public async Task<ActionResult<IEnumerable<SeguroMedicoDTO>>> GetSegurosMedicos()
        {
            var seguros = await _context.SeguroMedicos.ToListAsync();
            return seguros.Select(s => new SeguroMedicoDTO
            {
                id = s.id,
                nombre = s.nombre
            }).ToList();
        }

        //ESTADOS CIVILES
        [HttpGet("estados-civiles")]
        public async Task<ActionResult<IEnumerable<EstadoCivilDTO>>> GetEstadosCiviles()
        {
            var estadosCiviles = await _context.EstadoCivils.ToListAsync();
            return estadosCiviles.Select(e => new EstadoCivilDTO
            {
                id = e.id,
                nombre = e.nombre
            }).ToList();
        }

        //LATERALIDADES
        [HttpGet("lateralidades")]
        public async Task<ActionResult<IEnumerable<LateralidadDTO>>> GetLateralidades()
        {
            var lateralidades = await _context.Lateralidads.ToListAsync();
            return lateralidades.Select(l => new LateralidadDTO
            {
                id = l.id,
                nombre = l.nombre
            }).ToList();
        }

        //RELIGIONES
        [HttpGet("religiones")]
        public async Task<ActionResult<IEnumerable<ReligionDTO>>> GetReligiones()
        {
            var religiones = await _context.Religions.ToListAsync();
            return religiones.Select(r => new ReligionDTO
            {
                id = r.id,
                nombre = r.nombre
            }).ToList();
        }
        //PROVINCIAS
        [HttpGet("provincias")]
        public async Task<ActionResult<IEnumerable<ProvinciaDTO>>> GetProvincias()
        {
            var provincias = await _context.Provincia.ToListAsync();
            return provincias.Select(p => new ProvinciaDTO
            {
                id = p.id,
                nombre = p.nombre
            }).ToList();
        }

        //CIUDADES
        [HttpGet("ciudades")]
        public async Task<ActionResult<IEnumerable<CiudadDTO>>> GetCiudades()
        {
            var ciudades = await _context.Ciudads.ToListAsync();
            return ciudades.Select(c => new CiudadDTO
            {
                id = c.id,
                nombre = c.nombre
            }).ToList();
        }

        //TIPOS DE DOCUMENTO
        [HttpGet("tipos-documento")]
        public async Task<ActionResult<IEnumerable<TipoDocumentoDTO>>> GetTiposDocumento()
        {
            var tiposDocumento = await _context.TipoDocumentos.ToListAsync();
            return tiposDocumento.Select(td => new TipoDocumentoDTO
            {
                id = td.id,
                nombre = td.nombre
            }).ToList();
        }

        //TIPOS PROFESIONALES SALUD
        public async Task<ActionResult<IEnumerable<TipoProfesionalSaludDTO>>> GetTiposProfesionalesSalud()
        {
            var tiposProfesionalesSalud = await _context.TipoProfesionalSaluds.ToListAsync();
            return tiposProfesionalesSalud.Select(tps => new TipoProfesionalSaludDTO
            {
                id = tps.id,
                nombre = tps.nombre
            }).ToList();
        }

        //GRUPO SANGUINEO
        public async Task<ActionResult<IEnumerable<GrupoSanguineoDTO>>> GetGrupoSanguineos()
        {
            var gruposSanguineos = await _context.GrupoSanguineos.ToListAsync();
            return gruposSanguineos.Select(gs => new GrupoSanguineoDTO
            {
                id = gs.id,
                nombre = gs.nombre
            }).ToList();
        }

        //PROFESIONES
        public async Task<ActionResult<IEnumerable<ProfesionDTO>>> GetProfesiones()
        {
            var profesiones = await _context.Profesions.ToListAsync();
            return profesiones.Select(p => new ProfesionDTO
            {
                id = p.id,
                nombre = p.nombre
            }).ToList();
        }

        //ACTIVIDAD_LABORAL
        public async Task<ActionResult<IEnumerable<ActividadLaboralDTO>>> GetActividadesLaborales()
        {
            var actividadesLaborales = await _context.ActividadLaborals.ToListAsync();
            return actividadesLaborales.Select(al => new ActividadLaboralDTO
            {
                id = al.id,
                nombre = al.nombre
            }).ToList();
        }

        //INSTRUCCION
        public async Task<ActionResult<IEnumerable<NivelInstruccionDTO>>> GetInstrucciones()
        {
            var instrucciones = await _context.NivelInstruccions.ToListAsync();
            return instrucciones.Select(i => new NivelInstruccionDTO
            {
                id = i.id,
                nombre = i.nombre
            }).ToList();
        }

    }
}
