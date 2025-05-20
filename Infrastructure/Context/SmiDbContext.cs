using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public partial class SmiDbContext : DbContext
{
    public SmiDbContext(DbContextOptions<SmiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActividadLaboral> ActividadLaborals { get; set; }

    public virtual DbSet<Alergium> Alergia { get; set; }

    public virtual DbSet<Alimento> Alimentos { get; set; }

    public virtual DbSet<AntecedenteAlergium> AntecedenteAlergia { get; set; }

    public virtual DbSet<AntecedenteCirugium> AntecedenteCirugia { get; set; }

    public virtual DbSet<AntecedenteFamiliarDetalle> AntecedenteFamiliarDetalles { get; set; }

    public virtual DbSet<AntecedenteGinecologico> AntecedenteGinecologicos { get; set; }

    public virtual DbSet<AntecedenteHabitosToxico> AntecedenteHabitosToxicos { get; set; }

    public virtual DbSet<AntecedenteIntoleranciaAlimentarium> AntecedenteIntoleranciaAlimentaria { get; set; }

    public virtual DbSet<AntecedenteObstetrico> AntecedenteObstetricos { get; set; }

    public virtual DbSet<AntecedentePersonal> AntecedentePersonals { get; set; }

    public virtual DbSet<Atencion> Atencions { get; set; }

    public virtual DbSet<Cirugium> Cirugia { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<ContactoEmergencium> ContactoEmergencia { get; set; }

    public virtual DbSet<Enfermedad> Enfermedads { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<Evolucion> Evolucions { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<GrupoSanguineo> GrupoSanguineos { get; set; }

    public virtual DbSet<HabitoToxico> HabitoToxicos { get; set; }

    public virtual DbSet<HistoriaClinica> HistoriaClinicas { get; set; }

    public virtual DbSet<Lateralidad> Lateralidads { get; set; }

    public virtual DbSet<NivelInstruccion> NivelInstruccions { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<PacienteParentesco> PacienteParentescos { get; set; }

    public virtual DbSet<Parentesco> Parentescos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaActividadLaboral> PersonaActividadLaborals { get; set; }

    public virtual DbSet<PersonaDireccion> PersonaDireccions { get; set; }

    public virtual DbSet<PersonaDocumento> PersonaDocumentos { get; set; }

    public virtual DbSet<PersonaEstadoCivil> PersonaEstadoCivils { get; set; }

    public virtual DbSet<PersonaGrupoSanguineo> PersonaGrupoSanguineos { get; set; }

    public virtual DbSet<PersonaInstruccion> PersonaInstruccions { get; set; }

    public virtual DbSet<PersonaLateralidad> PersonaLateralidads { get; set; }

    public virtual DbSet<PersonaLugarResidencium> PersonaLugarResidencia { get; set; }

    public virtual DbSet<PersonaProfesion> PersonaProfesions { get; set; }

    public virtual DbSet<PersonaReligion> PersonaReligions { get; set; }

    public virtual DbSet<PersonaSeguroMedico> PersonaSeguroMedicos { get; set; }

    public virtual DbSet<PersonaTelefono> PersonaTelefonos { get; set; }

    public virtual DbSet<Profesion> Profesions { get; set; }

    public virtual DbSet<ProfesionalSalud> ProfesionalSaluds { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<SeguroMedico> SeguroMedicos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoEnfermedad> TipoEnfermedads { get; set; }

    public virtual DbSet<TipoProfesionalSalud> TipoProfesionalSaluds { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alergium>(entity =>
        {
            entity.HasKey(e => e.idAlergia).HasName("PK__Alergia__C7C5B96F04A9C0A0");
        });

        modelBuilder.Entity<Alimento>(entity =>
        {
            entity.HasKey(e => e.idAlimento).HasName("PK__Alimento__5081638377AB6A51");
        });


        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Persona>()
            .HasOne(p => p.Usuario)
            .WithOne(u => u.Id_PersonaNavigation)
            .HasForeignKey<Usuario>(u => u.Id_Persona);


        modelBuilder.Entity<AntecedenteAlergium>(entity =>
        {
            entity.HasKey(e => e.idAntecedenteAlergia).HasName("PK__Antecede__51D46A0BFDCD0D8F");

            entity.Property(e => e.fechaRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.idAlergiaNavigation).WithMany(p => p.AntecedenteAlergia)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AntecedenteAlergia_Alergia");

            entity.HasOne(d => d.numHistoriaNavigation).WithMany(p => p.AntecedenteAlergia)
                .HasPrincipalKey(p => p.numeroHistoria)
                .HasForeignKey(d => d.numHistoria)
                .HasConstraintName("FK_AntecedenteAlergia_HistoriaClinica");
        });

        modelBuilder.Entity<AntecedenteCirugium>(entity =>
        {
            entity.HasKey(e => e.idAntecedenteCirujia).HasName("PK__Antecede__858FA5BDE65A4FC6");

            entity.Property(e => e.fechaRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.idNombreCirugiaNavigation).WithMany(p => p.AntecedenteCirugia)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AntecedenteCirugia_Cirugia");

            entity.HasOne(d => d.numHistoriaNavigation).WithMany(p => p.AntecedenteCirugia)
                .HasPrincipalKey(p => p.numeroHistoria)
                .HasForeignKey(d => d.numHistoria)
                .HasConstraintName("FK_AntecedenteCirujia_HistoriaClinica");
        });

        modelBuilder.Entity<AntecedenteFamiliarDetalle>(entity =>
        {
            entity.HasKey(e => e.idAntecedenteFamiliarDetalle).HasName("PK__Antecede__ADF58A92CD1A25D4");

            entity.Property(e => e.fechaRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.idEnfermedadNavigation).WithMany(p => p.AntecedenteFamiliarDetalles)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AntecedenteFamiliarDetalle_Enfermedad");

            entity.HasOne(d => d.numHistoriaNavigation).WithMany(p => p.AntecedenteFamiliarDetalles)
                .HasPrincipalKey(p => p.numeroHistoria)
                .HasForeignKey(d => d.numHistoria)
                .HasConstraintName("FK_AntecedenteFamiliarDetalle_HistoriaClinica");
        });

        modelBuilder.Entity<AntecedenteGinecologico>(entity =>
        {
            entity.HasKey(e => e.idAntecedenteGinecologico).HasName("PK__Antecede__395023930716E1B9");

            entity.HasOne(d => d.idEnfermedadNavigation).WithMany(p => p.AntecedenteGinecologicos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AntecedenteGinecologico_Enfermedad");

            entity.HasOne(d => d.numHistoriaNavigation).WithMany(p => p.AntecedenteGinecologicos)
                .HasPrincipalKey(p => p.numeroHistoria)
                .HasForeignKey(d => d.numHistoria)
                .HasConstraintName("FK_AntecedenteGinecologico_HistoriaClinica");
        });

        modelBuilder.Entity<AntecedenteHabitosToxico>(entity =>
        {
            entity.HasKey(e => e.idAntecedenteHabitosToxicos).HasName("PK__Antecede__17C039BDE9600B82");

            entity.Property(e => e.fechaRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.idHabitoToxicoNavigation).WithMany(p => p.AntecedenteHabitosToxicos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AntecedenteHabitos_HabitoToxico");

            entity.HasOne(d => d.numHistoriaNavigation).WithMany(p => p.AntecedenteHabitosToxicos)
                .HasPrincipalKey(p => p.numeroHistoria)
                .HasForeignKey(d => d.numHistoria)
                .HasConstraintName("FK_AntecedenteHabitosToxicos_HistoriaClinica");
        });

        modelBuilder.Entity<AntecedenteIntoleranciaAlimentarium>(entity =>
        {
            entity.HasKey(e => e.idAntecedenteIntoleranciaAlimentaria).HasName("PK__Antecede__D43A32DBCD3B7827");

            entity.Property(e => e.fechaRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.idAlimentoNavigation).WithMany(p => p.AntecedenteIntoleranciaAlimentaria)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AntecedenteIntolerancia_Alimento");

            entity.HasOne(d => d.numHistoriaNavigation).WithMany(p => p.AntecedenteIntoleranciaAlimentaria)
                .HasPrincipalKey(p => p.numeroHistoria)
                .HasForeignKey(d => d.numHistoria)
                .HasConstraintName("FK_AntecedenteIntoleranciaAlimentaria_HistoriaClinica");
        });

        modelBuilder.Entity<AntecedenteObstetrico>(entity =>
        {
            entity.HasKey(e => e.idAntecedenteObstetrico).HasName("PK__Antecede__73399F35737EE930");

            entity.Property(e => e.abortos).HasDefaultValue(false);
            entity.Property(e => e.cesareas).HasDefaultValue(false);
            entity.Property(e => e.embarazoActual).HasDefaultValue(false);
            entity.Property(e => e.gestasPrevias).HasDefaultValue(false);
            entity.Property(e => e.hijosVivos).HasDefaultValue(0);
            entity.Property(e => e.lactancia).HasDefaultValue(false);
            entity.Property(e => e.nacidosMuertos).HasDefaultValue(0);
            entity.Property(e => e.nacidosVivos).HasDefaultValue(0);
            entity.Property(e => e.partos).HasDefaultValue(false);

            entity.HasOne(d => d.idEnfermedadNavigation).WithMany(p => p.AntecedenteObstetricos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AntecedenteObstetrico_Enfermedad");

            entity.HasOne(d => d.numHistoriaNavigation).WithMany(p => p.AntecedenteObstetricos)
                .HasPrincipalKey(p => p.numeroHistoria)
                .HasForeignKey(d => d.numHistoria)
                .HasConstraintName("FK_AntecedenteObstetrico_HistoriaClinica");
        });

        modelBuilder.Entity<AntecedentePersonal>(entity =>
        {
            entity.HasKey(e => e.idAntecedentePersonal).HasName("PK__Antecede__B51F084CE537F9A7");

            entity.Property(e => e.fechaRegistro).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.idEnfermedadNavigation).WithMany(p => p.AntecedentePersonals)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AntecedentePersonal_Enfermedad");

            entity.HasOne(d => d.numHistoriaNavigation).WithMany(p => p.AntecedentePersonals)
                .HasPrincipalKey(p => p.numeroHistoria)
                .HasForeignKey(d => d.numHistoria)
                .HasConstraintName("FK_AntecedentePersonal_HistoriaClinica");
        });

        modelBuilder.Entity<Atencion>(entity =>
        {
            entity.HasKey(e => e.idAtencion).HasName("PK__Atencion__E6F7276E4FF4D24B");

            entity.HasOne(d => d.idPacienteNavigation).WithMany(p => p.Atencions).HasConstraintName("FK_Atencion_Paciente");
        });

        modelBuilder.Entity<Cirugium>(entity =>
        {
            entity.HasKey(e => e.idCirugia).HasName("PK__Cirugia__531781B8B2497A52");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.id_ProvinciaNavigation).WithMany(p => p.Ciudads).HasConstraintName("FK_Ciudad_Provincia");
        });

        modelBuilder.Entity<ContactoEmergencium>(entity =>
        {
            entity.HasOne(d => d.id_PacienteNavigation).WithMany(p => p.ContactoEmergencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoEmergencia_Paciente");
        });

        modelBuilder.Entity<Enfermedad>(entity =>
        {
            entity.HasKey(e => e.idEnfermedad).HasName("PK__Enfermed__E8DAA00A922053AC");

            entity.HasOne(d => d.idTipoEnfermedadNavigation).WithMany(p => p.Enfermedads).HasConstraintName("FK_Enfermedad_TipoEnfermedad");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Evolucion>(entity =>
        {
            entity.HasKey(e => e.idEvolucion).HasName("PK__Evolucio__F1508FDCFE8DD3C8");

            entity.HasOne(d => d.idAtencionNavigation).WithMany(p => p.Evolucions).HasConstraintName("FK_Evolucion_Atencion");
        });

        modelBuilder.Entity<HabitoToxico>(entity =>
        {
            entity.HasKey(e => e.idHabitoToxico).HasName("PK__HabitoTo__7B00DCBB5E31CAD7");
        });

        modelBuilder.Entity<HistoriaClinica>(entity =>
        {
            entity.HasKey(e => e.idHistoriaClinica).HasName("PK__Historia__4CBA45A71334622B");

            entity.Property(e => e.activa).HasDefaultValue(true);
            entity.Property(e => e.fechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.idPacienteNavigation).WithMany(p => p.HistoriaClinicas).HasConstraintName("FK_HistoriaClinica_Paciente");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.Paciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Persona");
        });

        modelBuilder.Entity<PacienteParentesco>(entity =>
        {
            entity.Property(e => e.id_Paciente).ValueGeneratedNever();

            entity.HasOne(d => d.id_PacienteNavigation).WithOne(p => p.PacienteParentesco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PacienteParentesco_Paciente");

            entity.HasOne(d => d.id_ParentescoNavigation).WithMany(p => p.PacienteParentescos).HasConstraintName("FK_PacienteParentesco_Parentesco");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.idNavigation).WithOne(p => p.Persona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_PersonaProfesion");

            entity.HasOne(d => d.id_GeneroNavigation).WithMany(p => p.Personas).HasConstraintName("FK_Persona_Genero");
        });

        modelBuilder.Entity<PersonaActividadLaboral>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_ActividadLaboralNavigation).WithMany(p => p.PersonaActividadLaborals).HasConstraintName("FK_PersonaActividadLaboral_ActividadLaboral");

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaActividadLaboral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaActividadLaboral_Persona");
        });

        modelBuilder.Entity<PersonaDireccion>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDireccion_Persona");
        });

        modelBuilder.Entity<PersonaDocumento>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();
            entity.Property(e => e.numeroDocumento).IsFixedLength();

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDocumento_Persona");

            entity.HasOne(d => d.id_TipoDocumentoNavigation).WithMany(p => p.PersonaDocumentos).HasConstraintName("FK_PersonaDocumento_TipoDocumento");
        });

        modelBuilder.Entity<PersonaEstadoCivil>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_EstadoCivilNavigation).WithMany(p => p.PersonaEstadoCivils).HasConstraintName("FK_PersonaEstadoCivil_EstadoCivil");

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaEstadoCivil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaEstadoCivil_Persona");
        });

        modelBuilder.Entity<PersonaGrupoSanguineo>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_GrupoSanguineoNavigation).WithMany(p => p.PersonaGrupoSanguineos).HasConstraintName("FK_PersonaGrupoSanguineo_GrupoSanguineo");

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaGrupoSanguineo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaGrupoSanguineo_Persona");
        });

        modelBuilder.Entity<PersonaInstruccion>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_NivelInstruccionNavigation).WithMany(p => p.PersonaInstruccions).HasConstraintName("FK_PersonaInstruccion_NivelInstruccion");

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaInstruccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaInstruccion_Persona");
        });

        modelBuilder.Entity<PersonaLateralidad>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_LateralidadNavigation).WithMany(p => p.PersonaLateralidads).HasConstraintName("FK_PersonaLateralidad_Lateralidad");

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaLateralidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaLateralidad_Persona");
        });

        modelBuilder.Entity<PersonaLugarResidencium>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_CiudadNavigation).WithMany(p => p.PersonaLugarResidencia).HasConstraintName("FK_PersonaLugarResidencia_Ciudad");

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaLugarResidencium)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaLugarResidencia_Persona");
        });

        modelBuilder.Entity<PersonaProfesion>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_ProfesionNavigation).WithMany(p => p.PersonaProfesions).HasConstraintName("FK_PersonaProfesion_Profesion");
        });

        modelBuilder.Entity<PersonaReligion>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaReligion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaReligion_Persona");

            entity.HasOne(d => d.id_ReligionNavigation).WithMany(p => p.PersonaReligions).HasConstraintName("FK_PersonaReligion_Religion");
        });

        modelBuilder.Entity<PersonaSeguroMedico>(entity =>
        {
            entity.HasOne(d => d.id_PersonaNavigation).WithMany(p => p.PersonaSeguroMedicos).HasConstraintName("FK_PersonaSeguroMedico_Persona");

            entity.HasOne(d => d.id_SeguroMedicoNavigation).WithMany(p => p.PersonaSeguroMedicos).HasConstraintName("FK_PersonaSeguroMedico_SeguroMedico");
        });

        modelBuilder.Entity<PersonaTelefono>(entity =>
        {
            entity.Property(e => e.id_Persona).ValueGeneratedNever();

            entity.HasOne(d => d.id_PersonaNavigation).WithOne(p => p.PersonaTelefono)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaTelefono_Persona");
        });

        modelBuilder.Entity<ProfesionalSalud>(entity =>
        {
            entity.Property(e => e.id_ProfesionalSalud).ValueGeneratedNever();

            entity.HasOne(d => d.id_ProfesionalSaludNavigation).WithOne(p => p.ProfesionalSalud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfesionalSalud_Persona");

            entity.HasOne(d => d.id_TipoProfesionalNavigation).WithMany(p => p.ProfesionalSaluds).HasConstraintName("FK_ProfesionalSalud_TipoProfesionalSalud");
        });

        modelBuilder.Entity<TipoEnfermedad>(entity =>
        {
            entity.HasKey(e => e.idTipoEnfermedad).HasName("PK__TipoEnfe__DC87AE58943744EE");
        });

        modelBuilder.Entity<TipoProfesionalSalud>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Usuario");

            entity.HasOne(d => d.Id_PersonaNavigation)
                  .WithOne(p => p.Usuario)
                  .HasForeignKey<Usuario>(d => d.Id_Persona)
                  .HasConstraintName("FK_Usuario_Persona")
                  .OnDelete(DeleteBehavior.Restrict);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

