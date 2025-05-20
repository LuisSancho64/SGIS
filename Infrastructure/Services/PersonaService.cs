using SMI.Shared.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Context;
using Infrastructure.Models;
using Application.Interfaces;

namespace Infrastructure.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly SmiDbContext _context;

        public PersonaService(SmiDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonaDTO>> GetAllPersonasAsync()
        {
            var personas = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .Include(p => p.PersonaTelefono)
                .Include(p => p.PersonaSeguroMedicos)
                    .ThenInclude(psm => psm.id_SeguroMedicoNavigation)
                .Include(p => p.PersonaEstadoCivil)
                    .ThenInclude(pec => pec.id_EstadoCivilNavigation)
                .Include(p => p.PersonaDocumento)
                    .ThenInclude(pd => pd.id_TipoDocumentoNavigation)
                .Include(p => p.PersonaLateralidad)
                    .ThenInclude(pl => pl.id_LateralidadNavigation)
                .Include(p => p.PersonaReligion)
                    .ThenInclude(pr => pr.id_ReligionNavigation)
                .Include(p => p.PersonaLugarResidencium)
                    .ThenInclude(plr => plr.id_CiudadNavigation)
                    .ThenInclude(plr => plr.id_ProvinciaNavigation)
                .Include(p => p.ProfesionalSalud)
                    .ThenInclude(ps => ps.id_TipoProfesionalNavigation)
                .Include(p => p.PersonaGrupoSanguineo)
                    .ThenInclude(pg => pg.id_GrupoSanguineoNavigation)
                .Include(p => p.PersonaProfesions)
                    .ThenInclude(pp => pp.id_ProfesionNavigation)
                .Include(p => p.PersonaActividadLaboral)
                    .ThenInclude(pa => pa.id_ActividadLaboralNavigation)
                .Include(p => p.PersonaInstruccion)
                    .ThenInclude(pi => pi.id_NivelInstruccionNavigation)

                .ToListAsync();

            return personas.Select(p => MapToDto(p)).ToList();
        }

        public async Task<PersonaDTO?> GetPersonaByIdAsync(int id)
        {
            var persona = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .Include(p => p.PersonaTelefono)
                .Include(p => p.PersonaSeguroMedicos)
                    .ThenInclude(psm => psm.id_SeguroMedicoNavigation)
                .Include(p => p.PersonaEstadoCivil)
                    .ThenInclude(pec => pec.id_EstadoCivilNavigation)
                .Include(p => p.PersonaDocumento)
                    .ThenInclude(pd => pd.id_TipoDocumentoNavigation)
                .Include(p => p.PersonaLateralidad)
                    .ThenInclude(pl => pl.id_LateralidadNavigation)
                .Include(p => p.PersonaReligion)
                    .ThenInclude(pr => pr.id_ReligionNavigation)
                .Include(p => p.PersonaLugarResidencium)
                    .ThenInclude(plr => plr.id_CiudadNavigation)
                    .ThenInclude(plr => plr.id_ProvinciaNavigation)
                .Include(p => p.ProfesionalSalud)
                    .ThenInclude(ps => ps.id_TipoProfesionalNavigation)
                .Include(p => p.PersonaGrupoSanguineo)
                    .ThenInclude(pg => pg.id_GrupoSanguineoNavigation)
                .Include(p => p.PersonaProfesions)
                    .ThenInclude(pp => pp.id_ProfesionNavigation)
                .Include(p => p.PersonaActividadLaboral)
                    .ThenInclude(pa => pa.id_ActividadLaboralNavigation)
                .Include(p => p.PersonaInstruccion)
                    .ThenInclude(pi => pi.id_NivelInstruccionNavigation)

                .FirstOrDefaultAsync(p => p.id == id);

            return persona == null ? null : MapToDto(persona);
        }

        public async Task<PersonaDTO> AddPersonaAsync(PersonaDTO dto)
        {
            // 1. Crear la entidad Persona (sin relaciones)
            var persona = new Persona
            {
                id_Genero = dto.id_Genero,
                nombre = dto.nombre,
                nombre2 = dto.nombre2,
                apellido = dto.apellido,
                apellido2 = dto.apellido2,
                FechaNacimiento = dto.FechaNacimiento,
                Correo = dto.Correo
            };

            // 2. Guardar persona para obtener ID autogenerado
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            // 3. Crear y asociar relaciones utilizando el ID generado
            if (dto.Direccion?.FirstOrDefault() is PersonaDireccionDTO dir)
            {
                var personaDireccion = new PersonaDireccion
                {
                    id_Persona = persona.id,
                    callePrincipal = dir.CallePrincipal,
                    calleSecundaria1 = dir.CalleSecundaria1,
                    calleSecundaria2 = dir.CalleSecundaria2,
                    numeroCasa = dir.NumeroCasa,
                    referencia = dir.Referencia
                };
                _context.PersonaDireccions.Add(personaDireccion);
            }

            if (dto.Telefono is PersonaTelefonoDTO tel)
            {
                var personaTelefono = new PersonaTelefono
                {
                    id_Persona = persona.id,
                    convencional = tel.Convencional,
                    celular = tel.Celular
                };
                _context.PersonaTelefonos.Add(personaTelefono);
            }

            if (dto.EstadoCivil is EstadoCivilDTO estadoCivil)
            {
                var personaEstadoCivil = new PersonaEstadoCivil
                {
                    id_Persona = persona.id,
                    id_EstadoCivil = estadoCivil.id
                };
                _context.PersonaEstadoCivils.Add(personaEstadoCivil);
            }


            if (dto.SegurosMedicos != null && dto.SegurosMedicos.Any())
            {
                var seguros = dto.SegurosMedicos.Select(s => new PersonaSeguroMedico
                {
                    id_Persona = persona.id,
                    id_SeguroMedico = s.id
                }).ToList();

                _context.PersonaSeguroMedicos.AddRange(seguros);
            }

            if (dto.Documento is PersonaDocumentoDTO doc)
            {
                var personaDocumento = new PersonaDocumento
                {
                    id_Persona = persona.id,
                    id_TipoDocumento = doc.id_TipoDocumento,
                    numeroDocumento = doc.numeroDocumento
                };
                _context.PersonaDocumentos.Add(personaDocumento);
            }

            if (dto.Lateralidad is PersonaLateralidadDTO lat)
            {
                var personaLateralidad = new PersonaLateralidad
                {
                    id_Persona = persona.id,
                    id_Lateralidad = lat.id_Lateralidad
                };
                _context.PersonaLateralidads.Add(personaLateralidad);
            }

            if (dto.Religion is ReligionDTO religion)
            {
                var personaReligion = new PersonaReligion
                {
                    id_Persona = persona.id,
                    id_Religion = religion.id
                };
                _context.PersonaReligions.Add(personaReligion);
            }

            if (dto.LugarResidencia is PersonaLugarResidenciaDTO lug)
            {
                var personaLugarResidencia = new PersonaLugarResidencium
                {
                    id_Persona = persona.id,
                    id_Ciudad = lug.id_Ciudad
                };
                _context.PersonaLugarResidencia.Add(personaLugarResidencia);
            }

            if (dto.ProfesionalSalud is ProfesionalSaludDTO prof)
            {
                var profesional = new ProfesionalSalud
                {
                    id_ProfesionalSalud = persona.id, // solo si se está actualizando uno existente
                    id_TipoProfesional = prof.id_TipoProfesional,
                    numeroRegistro = prof.numeroRegistro
                };
                _context.ProfesionalSaluds.Add(profesional);
            }

            if (dto.GrupoSanguineo != null)
            {
                var personaGrupoSanguineo = new PersonaGrupoSanguineo
                {
                    id_Persona = persona.id,
                    id_GrupoSanguineo = dto.GrupoSanguineo.id
                };
                _context.PersonaGrupoSanguineos.Add(personaGrupoSanguineo);
            }

            if (dto.profesiones != null && dto.profesiones.Any())
            {
                foreach (var profesionDTO in dto.profesiones)
                {
                    if (profesionDTO.id != 0 && await _context.Profesions.AnyAsync(p => p.id == profesionDTO.id))
                    {
                        var personaProfesion = new PersonaProfesion
                        {
                            id_Persona = persona.id,
                            id_Profesion = profesionDTO.id
                        };
                        _context.PersonaProfesions.Add(personaProfesion);
                    }
                }
            }

            if (dto.ActividadLaboral != null && dto.ActividadLaboral.Any())
            {
                foreach (var actividadDTO in dto.ActividadLaboral)
                {
                    if (actividadDTO.id != 0 && await _context.ActividadLaborals.AnyAsync(a => a.id == actividadDTO.id))
                    {
                        var personaActividad = new PersonaActividadLaboral
                        {
                            id_Persona = persona.id,
                            id_ActividadLaboral = actividadDTO.id
                        };
                        _context.PersonaActividadLaborals.Add(personaActividad);
                    }
                }
            }

            if (dto.Instruccion != null)
            {
                var personaInstruccion = new PersonaInstruccion
                {
                    id_Persona = persona.id,
                    id_NivelInstruccion = dto.Instruccion.id
                };
                _context.PersonaInstruccions.Add(personaInstruccion);
            }






            // 4. Guardar todas las relaciones
            await _context.SaveChangesAsync();

            // 5. Consultar nuevamente la persona con sus relaciones
            var personaConRelaciones = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .Include(p => p.PersonaTelefono)
                .Include(p => p.PersonaEstadoCivil)
                    .ThenInclude(ec => ec.id_EstadoCivilNavigation)
                .Include(p => p.PersonaSeguroMedicos)
                    .ThenInclude(sm => sm.id_SeguroMedicoNavigation)
                .Include(p => p.PersonaDocumento)
                    .ThenInclude(pd => pd.id_TipoDocumentoNavigation)
                .Include(p => p.PersonaLateralidad)
                    .ThenInclude(l => l.id_LateralidadNavigation)
                .Include(p => p.PersonaReligion)
                    .ThenInclude(r => r.id_ReligionNavigation)
                .Include(p => p.PersonaLugarResidencium)
                    .ThenInclude(lr => lr.id_CiudadNavigation)
                    .ThenInclude(c => c.id_ProvinciaNavigation)
                .Include(p => p.ProfesionalSalud)
                    .ThenInclude(ps => ps.id_TipoProfesionalNavigation)
                .Include(p => p.PersonaGrupoSanguineo)
                    .ThenInclude(pg => pg.id_GrupoSanguineoNavigation)
                .Include(p => p.PersonaProfesions)
                    .ThenInclude(pp => pp.id_ProfesionNavigation)
                .Include(p => p.PersonaActividadLaboral)
                    .ThenInclude(pa => pa.id_ActividadLaboralNavigation)
                .Include(p => p.PersonaInstruccion)
                    .ThenInclude(pi => pi.id_NivelInstruccionNavigation)


                .FirstOrDefaultAsync(p => p.id == persona.id);

            // 6. Retornar DTO
            return MapToDto(personaConRelaciones!);
        }



        public async Task<PersonaDTO?> UpdatePersonaAsync(PersonaDTO dto)
        {
            if (dto.id == null) return null;

            var persona = await _context.Personas
                .Include(p => p.PersonaDireccion)
                .Include(p => p.PersonaTelefono)
                .Include(p => p.PersonaSeguroMedicos)
                    .ThenInclude(psm => psm.id_SeguroMedicoNavigation)
                .Include(p => p.PersonaEstadoCivil)
                    .ThenInclude(pec => pec.id_EstadoCivilNavigation)
                .Include(p => p.PersonaDocumento)
                    .ThenInclude(pd => pd.id_TipoDocumentoNavigation)
                .Include(p => p.PersonaLateralidad)
                    .ThenInclude(pl => pl.id_LateralidadNavigation)
                .Include(p => p.PersonaReligion)
                    .ThenInclude(pr => pr.id_ReligionNavigation)
                .Include(p => p.PersonaLugarResidencium)
                    .ThenInclude(plr => plr.id_CiudadNavigation)
                        .ThenInclude(plr => plr.id_ProvinciaNavigation)
                .Include(p => p.ProfesionalSalud)
                    .ThenInclude(ps => ps.id_TipoProfesionalNavigation)
                .Include(p => p.PersonaGrupoSanguineo)
                    .ThenInclude(pg => pg.id_GrupoSanguineoNavigation)
                .Include(p => p.PersonaActividadLaboral)
                    .ThenInclude(pa => pa.id_ActividadLaboralNavigation)
                .Include(p => p.PersonaInstruccion)
                    .ThenInclude(pi => pi.id_NivelInstruccionNavigation)
                .FirstOrDefaultAsync(p => p.id == dto.id);

            if (persona == null) return null;

            // Actualizar campos escalares
            persona.id_Genero = dto.id_Genero;
            persona.nombre = dto.nombre;
            persona.nombre2 = dto.nombre2;
            persona.apellido = dto.apellido;
            persona.apellido2 = dto.apellido2;
            persona.FechaNacimiento = dto.FechaNacimiento;
            persona.Correo = dto.Correo;

            // ACTUALIZAR DIRECCIONES
            if (dto.Direccion != null && dto.Direccion.Any())
            {
                var dirDto = dto.Direccion.First();

                if (persona.PersonaDireccion == null)
                {
                    persona.PersonaDireccion = new PersonaDireccion();
                }
                persona.PersonaDireccion.callePrincipal = dirDto.CallePrincipal;
                persona.PersonaDireccion.calleSecundaria1 = dirDto.CalleSecundaria1;
                persona.PersonaDireccion.calleSecundaria2 = dirDto.CalleSecundaria2;
                persona.PersonaDireccion.numeroCasa = dirDto.NumeroCasa;
                persona.PersonaDireccion.referencia = dirDto.Referencia;

                persona.PersonaDireccion.id_Persona = persona.id;
            }

            // ACTUALIZAR TELEFONO (asumo uno solo)
            if (dto.Telefono != null)
            {
                if (persona.PersonaTelefono == null)
                {
                    persona.PersonaTelefono = new PersonaTelefono
                    {
                        celular = dto.Telefono.Celular,
                        convencional = dto.Telefono.Convencional,
                        id_Persona = persona.id
                    };
                }
                else
                {
                    persona.PersonaTelefono.celular = dto.Telefono.Celular;
                    persona.PersonaTelefono.convencional = dto.Telefono.Convencional;
                }
            }

            // ACTUALIZAR ESTADO CIVIL (uno a uno)
            if (dto.EstadoCivil != null)
            {
                if (persona.PersonaEstadoCivil == null)
                {
                    persona.PersonaEstadoCivil = new PersonaEstadoCivil
                    {
                        id_Persona = persona.id,
                        id_EstadoCivil = dto.EstadoCivil.id
                    };
                }
                else
                {
                    persona.PersonaEstadoCivil.id_EstadoCivil = dto.EstadoCivil.id;
                }
            }

            // ACTUALIZAR SEGUROS MEDICOS (colección)
            if (dto.SegurosMedicos != null)
            {
                // Eliminar todos los seguros medicos actuales en la BD
                _context.PersonaSeguroMedicos.RemoveRange(persona.PersonaSeguroMedicos);

                persona.PersonaSeguroMedicos.Clear();

                foreach (var smDto in dto.SegurosMedicos)
                {
                    var sm = new PersonaSeguroMedico
                    {
                        id_Persona = persona.id,
                        id_SeguroMedico = smDto.id
                    };
                    persona.PersonaSeguroMedicos.Add(sm);
                }
            }

            // ACTUALIZAR DOCUMENTO (uno a uno)
            if (dto.Documento != null)
            {
                if (persona.PersonaDocumento == null)
                {
                    persona.PersonaDocumento = new PersonaDocumento
                    {
                        id_Persona = persona.id,
                        id_TipoDocumento = dto.Documento.id_TipoDocumento,
                        numeroDocumento = dto.Documento.numeroDocumento
                    };
                }
                else
                {
                    persona.PersonaDocumento.id_TipoDocumento = dto.Documento.id_TipoDocumento;
                    persona.PersonaDocumento.numeroDocumento = dto.Documento.numeroDocumento;
                }
            }

            // ACTUALIZAR LATERALIDAD (uno a uno)
            if (dto.Lateralidad != null)
            {
                if (persona.PersonaLateralidad == null)
                {
                    persona.PersonaLateralidad = new PersonaLateralidad
                    {
                        id_Persona = persona.id,
                        id_Lateralidad = dto.Lateralidad.id_Lateralidad
                    };
                }
                else
                {
                    persona.PersonaLateralidad.id_Lateralidad = dto.Lateralidad.id_Lateralidad;
                }
            }

            // ACTUALIZAR RELIGION (uno a uno)
            if (dto.Religion != null)
            {
                if (persona.PersonaReligion == null)
                {
                    persona.PersonaReligion = new PersonaReligion
                    {
                        id_Persona = persona.id,
                        id_Religion = dto.Religion.id
                    };
                }
                else
                {
                    persona.PersonaReligion.id_Religion = dto.Religion.id;
                }
            }

            // ACTUALIZAR LUGAR DE RESIDENCIA (uno a uno)
            if (dto.LugarResidencia != null)
            {
                if (persona.PersonaLugarResidencium == null)
                {
                    persona.PersonaLugarResidencium = new PersonaLugarResidencium
                    {
                        id_Persona = persona.id,
                        id_Ciudad = dto.LugarResidencia.id_Ciudad
                    };
                }
                else
                {
                    persona.PersonaLugarResidencium.id_Ciudad = dto.LugarResidencia.id_Ciudad;
                }
            }

            // ACTUALIZAR PROFESIONAL DE SALUD (uno a uno)
            if (dto.ProfesionalSalud != null)
            {
                if (persona.ProfesionalSalud == null)
                {
                    persona.ProfesionalSalud = new ProfesionalSalud
                    {
                        id_ProfesionalSalud = persona.id,  // clave compartida con Persona
                        id_TipoProfesional = dto.ProfesionalSalud.id_TipoProfesional,
                        numeroRegistro = dto.ProfesionalSalud.numeroRegistro,
                    };
                }
                else
                {
                    persona.ProfesionalSalud.id_TipoProfesional = dto.ProfesionalSalud.id_TipoProfesional;
                    persona.ProfesionalSalud.numeroRegistro = dto.ProfesionalSalud.numeroRegistro;
                }
            }

            // ACTUALIZAR GRUPO SANGUÍNEO (uno a uno)
            if (dto.GrupoSanguineo != null)
            {
                if (persona.PersonaGrupoSanguineo == null)
                {
                    persona.PersonaGrupoSanguineo = new PersonaGrupoSanguineo
                    {
                        id_Persona = persona.id,
                        id_GrupoSanguineo = dto.GrupoSanguineo.id
                    };
                }
                else
                {
                    persona.PersonaGrupoSanguineo.id_GrupoSanguineo = dto.GrupoSanguineo.id;
                }
            }

            // ACTUALIZAR ACTIVIDAD LABORAL (colección)
            if (dto.ActividadLaboral != null)
            {
                _context.PersonaActividadLaborals.RemoveRange(persona.PersonaActividadLaboral);

                persona.PersonaActividadLaboral.Clear();

                foreach (var actDto in dto.ActividadLaboral)
                {
                    persona.PersonaActividadLaboral.Add(new PersonaActividadLaboral
                    {
                        id_Persona = persona.id,
                        id_ActividadLaboral = actDto.id
                    });
                }
            }

            // ACTUALIZAR INSTRUCCION (uno a uno)
            if (dto.Instruccion != null)
            {
                if (persona.PersonaInstruccion == null)
                {
                    persona.PersonaInstruccion = new PersonaInstruccion
                    {
                        id_Persona = persona.id,
                        id_NivelInstruccion = dto.Instruccion.id
                    };
                }
                else
                {
                    persona.PersonaInstruccion.id_NivelInstruccion = dto.Instruccion.id;
                }
            }

            await _context.SaveChangesAsync();

            return MapToDto(persona);
        }





        public async Task<bool> DeletePersonaAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return false;

            // Borrar dependencias antes de borrar persona
            _context.Pacientes.RemoveRange(_context.Pacientes.Where(p => p.id_Persona == id));
            _context.PersonaActividadLaborals.RemoveRange(_context.PersonaActividadLaborals.Where(pa => pa.id_Persona == id));
            _context.PersonaDireccions.RemoveRange(_context.PersonaDireccions.Where(d => d.id_Persona == id));
            _context.PersonaDocumentos.RemoveRange(_context.PersonaDocumentos.Where(doc => doc.id_Persona == id));
            _context.PersonaEstadoCivils.RemoveRange(_context.PersonaEstadoCivils.Where(ec => ec.id_Persona == id));
            _context.PersonaGrupoSanguineos.RemoveRange(_context.PersonaGrupoSanguineos.Where(gs => gs.id_Persona == id));
            _context.PersonaInstruccions.RemoveRange(_context.PersonaInstruccions.Where(ins => ins.id_Persona == id));
            _context.PersonaLateralidads.RemoveRange(_context.PersonaLateralidads.Where(lat => lat.id_Persona == id));
            _context.PersonaLugarResidencia.RemoveRange(_context.PersonaLugarResidencia.Where(lr => lr.id_Persona == id));
            _context.PersonaReligions.RemoveRange(_context.PersonaReligions.Where(rel => rel.id_Persona == id));
            _context.PersonaSeguroMedicos.RemoveRange(_context.PersonaSeguroMedicos.Where(sm => sm.id_Persona == id));
            _context.PersonaTelefonos.RemoveRange(_context.PersonaTelefonos.Where(t => t.id_Persona == id));
            _context.ProfesionalSaluds.RemoveRange(_context.ProfesionalSaluds.Where(ps => ps.id_ProfesionalSalud == id));
            _context.Usuarios.RemoveRange(_context.Usuarios.Where(u => u.Id_Persona == id));

            // Finalmente borrar persona
            _context.Personas.Remove(persona);

            await _context.SaveChangesAsync();
            return true;
        }



        // -------------------- MAPEO DTO A ENTIDAD --------------------
        private PersonaDTO MapToDto(Persona persona)
        {
            return new PersonaDTO
            {
                id_Genero = persona.id_Genero,
                nombre = persona.nombre,
                nombre2 = persona.nombre2,
                apellido = persona.apellido,
                apellido2 = persona.apellido2,
                FechaNacimiento = persona.FechaNacimiento,
                Correo = persona.Correo,

                Direccion = persona.PersonaDireccion != null
                ? new List<PersonaDireccionDTO>
                {
                    new PersonaDireccionDTO
                    {
                        CallePrincipal = persona.PersonaDireccion.callePrincipal,
                        CalleSecundaria1 = persona.PersonaDireccion.calleSecundaria1,
                        CalleSecundaria2 = persona.PersonaDireccion.calleSecundaria2,
                        NumeroCasa = persona.PersonaDireccion.numeroCasa,
                        Referencia = persona.PersonaDireccion.referencia
                    }
                }
                : null,

                Telefono = persona.PersonaTelefono != null
                ? new PersonaTelefonoDTO
                {
                    Convencional = persona.PersonaTelefono.convencional,
                    Celular = persona.PersonaTelefono.celular
                }
                : null,

                EstadoCivil = persona.PersonaEstadoCivil == null || persona.PersonaEstadoCivil.id_EstadoCivilNavigation == null
                ? null
                : new EstadoCivilDTO
                {
                    id = persona.PersonaEstadoCivil.id_EstadoCivilNavigation.id,
                    nombre = persona.PersonaEstadoCivil.id_EstadoCivilNavigation.nombre
                },

                SegurosMedicos = persona.PersonaSeguroMedicos?
                .Where(psm => psm.id_SeguroMedicoNavigation != null)
                .Select(pms => new SeguroMedicoDTO
                {
                    id = pms.id_SeguroMedicoNavigation!.id,
                    nombre = pms.id_SeguroMedicoNavigation.nombre,
                }).ToList(),

                Documento = persona.PersonaDocumento == null ? null : new PersonaDocumentoDTO
                {
                    id_Persona = persona.PersonaDocumento.id_Persona,
                    id_TipoDocumento = persona.PersonaDocumento.id_TipoDocumento,
                    nombreTipoDocumento = persona.PersonaDocumento.id_TipoDocumentoNavigation?.nombre,
                    numeroDocumento = persona.PersonaDocumento.numeroDocumento
                },

                Lateralidad = persona.PersonaLateralidad == null ? null : new PersonaLateralidadDTO
                {
                    id_Persona = persona.PersonaLateralidad.id_Persona,
                    id_Lateralidad = persona.PersonaLateralidad.id_Lateralidad,
                    nombreLateralidad = persona.PersonaLateralidad.id_LateralidadNavigation?.nombre
                },

                Religion = persona.PersonaReligion == null ? null : new ReligionDTO
                {
                    id = persona.PersonaReligion.id_ReligionNavigation?.id ?? 0,
                    nombre = persona.PersonaReligion.id_ReligionNavigation?.nombre
                }
                ,

                LugarResidencia = persona.PersonaLugarResidencium != null
                ? new PersonaLugarResidenciaDTO
                {
                    id_Ciudad = persona.PersonaLugarResidencium.id_Ciudad,
                    nombreCiudad = persona.PersonaLugarResidencium.id_CiudadNavigation?.nombre,
                    id_Provincia = persona.PersonaLugarResidencium.id_CiudadNavigation?.id_ProvinciaNavigation?.id,
                    nombreProvincia = persona.PersonaLugarResidencium.id_CiudadNavigation?.id_ProvinciaNavigation?.nombre
                }
                : null,

                ProfesionalSalud = persona.ProfesionalSalud != null ? new ProfesionalSaludDTO
                {
                    id_ProfesionalSalud = persona.ProfesionalSalud.id_ProfesionalSalud,
                    id_TipoProfesional = persona.ProfesionalSalud.id_TipoProfesional,
                    numeroRegistro = persona.ProfesionalSalud.numeroRegistro,
                    nombreTipoProfesional = persona.ProfesionalSalud.id_TipoProfesionalNavigation?.nombre
                } : null,
                
                GrupoSanguineo = persona.PersonaGrupoSanguineo != null && persona.PersonaGrupoSanguineo.id_GrupoSanguineoNavigation != null
                ? new GrupoSanguineoDTO
                {
                    id = persona.PersonaGrupoSanguineo.id_GrupoSanguineoNavigation.id,
                    nombre = persona.PersonaGrupoSanguineo.id_GrupoSanguineoNavigation.nombre
                }
                : null,

                profesiones = persona.PersonaProfesions?
                    .Where(pp => pp.id_ProfesionNavigation != null)
                    .Select(pp => new ProfesionDTO
                    {
                        id = pp.id_ProfesionNavigation!.id,
                        nombre = pp.id_ProfesionNavigation.nombre
                    }).ToList() ?? new List<ProfesionDTO>(),

                ActividadLaboral = persona.PersonaActividadLaboral?
                .Where(pa => pa.id_ActividadLaboralNavigation != null)
                .Select(pa => new ActividadLaboralDTO
                {
                    id = pa.id_ActividadLaboralNavigation!.id,
                    nombre = pa.id_ActividadLaboralNavigation.nombre
                }).ToList() ?? new List<ActividadLaboralDTO>(),

                Instruccion = persona.PersonaInstruccion != null && persona.PersonaInstruccion.id_NivelInstruccionNavigation != null
                ? new NivelInstruccionDTO
                {
                    id = persona.PersonaInstruccion.id_NivelInstruccionNavigation.id,
                    nombre = persona.PersonaInstruccion.id_NivelInstruccionNavigation.nombre
                }
                : null



            };
        }

        private Persona MapToEntity(PersonaDTO dto)
        {
            return new Persona
            {
                id_Genero = dto.id_Genero,
                nombre = dto.nombre,
                nombre2 = dto.nombre2,
                apellido = dto.apellido,
                apellido2 = dto.apellido2,
                FechaNacimiento = dto.FechaNacimiento,
                Correo = dto.Correo,

                PersonaDireccion = dto.Direccion?.FirstOrDefault() == null ? null : new PersonaDireccion
                {
                    callePrincipal = dto.Direccion.First().CallePrincipal,
                    calleSecundaria1 = dto.Direccion.First().CalleSecundaria1,
                    calleSecundaria2 = dto.Direccion.First().CalleSecundaria2,
                    numeroCasa = dto.Direccion.First().NumeroCasa,
                    referencia = dto.Direccion.First().Referencia
                },

                PersonaTelefono = dto.Telefono == null ? null : new PersonaTelefono
                {
                    convencional = dto.Telefono.Convencional,
                    celular = dto.Telefono.Celular
                },

                PersonaEstadoCivil = dto.EstadoCivil == null
                ? null
                : new PersonaEstadoCivil
                {
                    id_EstadoCivil = dto.EstadoCivil.id
                },

                PersonaSeguroMedicos = dto.SegurosMedicos?.Select(s => new PersonaSeguroMedico
                {
                    id_SeguroMedico = s.id
                }).ToList(),

                PersonaDocumento = dto.Documento == null ? null : new PersonaDocumento
                {
                    id_Persona = dto.Documento.id_Persona,
                    id_TipoDocumento = dto.Documento.id_TipoDocumento,
                    numeroDocumento = dto.Documento.numeroDocumento
                },

                PersonaLateralidad = dto.Lateralidad == null ? null : new PersonaLateralidad
                {
                    id_Persona = dto.Lateralidad.id_Persona,
                    id_Lateralidad = dto.Lateralidad.id_Lateralidad
                },

                PersonaReligion = dto.Religion == null ? null : new PersonaReligion
                {
                    id_Religion = dto.Religion.id
                },

                PersonaLugarResidencium = dto.LugarResidencia == null ? null : new PersonaLugarResidencium
                {
                    id_Ciudad = dto.LugarResidencia.id_Ciudad
                },

                ProfesionalSalud = dto.ProfesionalSalud == null ? null : new ProfesionalSalud
                {
                    id_ProfesionalSalud = dto.ProfesionalSalud.id_ProfesionalSalud,
                    id_TipoProfesional = dto.ProfesionalSalud.id_TipoProfesional,
                    numeroRegistro = dto.ProfesionalSalud.numeroRegistro
                },

            };
        }

    }
}
