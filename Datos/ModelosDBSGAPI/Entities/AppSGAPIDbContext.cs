using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Datos.ModelosDBSGAPI.Entities;

public partial class AppSGAPIDbContext : DbContext
{
    public AppSGAPIDbContext()
    {
    }

    public AppSGAPIDbContext(DbContextOptions<AppSGAPIDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acreditadora> Acreditadoras { get; set; }

    public virtual DbSet<AcreditadoraProceso> AcreditadoraProcesos { get; set; }

    public virtual DbSet<Apartado> Apartados { get; set; }

    public virtual DbSet<AreaCorporativa> AreaCorporativas { get; set; }

    public virtual DbSet<AreaCorporativaSubArea> AreaCorporativaSubAreas { get; set; }

    public virtual DbSet<AreaResponsabilidad> AreaResponsabilidads { get; set; }

    public virtual DbSet<AreaResponsable> AreaResponsables { get; set; }

    public virtual DbSet<AreaResponsableNivelModalidad> AreaResponsableNivelModalidads { get; set; }

    public virtual DbSet<Campus> Campuses { get; set; }

    public virtual DbSet<Capitulo> Capitulos { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<CatalogoElementoEvaluacion> CatalogoElementoEvaluacions { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<ComentarioSeguimiento> ComentarioSeguimientos { get; set; }

    public virtual DbSet<Componente> Componentes { get; set; }

    public virtual DbSet<ComponenteUvm> ComponenteUvms { get; set; }

    public virtual DbSet<ConfiguracionGeneral> ConfiguracionGenerals { get; set; }

    public virtual DbSet<ConfiguracionIndicadorSiac> ConfiguracionIndicadorSiacs { get; set; }

    public virtual DbSet<ConfiguracionSistema> ConfiguracionSistemas { get; set; }

    public virtual DbSet<Criterio> Criterios { get; set; }

    public virtual DbSet<ElementoEvaluacion> ElementoEvaluacions { get; set; }

    public virtual DbSet<EscalaMedicion> EscalaMedicions { get; set; }

    public virtual DbSet<EscalaMedicionEscenario> EscalaMedicionEscenarios { get; set; }

    public virtual DbSet<EvidenciaAnio> EvidenciaAnios { get; set; }

    public virtual DbSet<Evidencium> Evidencia { get; set; }

    public virtual DbSet<IndicadorMatriz> IndicadorMatrizs { get; set; }

    public virtual DbSet<IndicadorSiac> IndicadorSiacs { get; set; }

    public virtual DbSet<IndicadorUvm> IndicadorUvms { get; set; }

    public virtual DbSet<MatrizUvm> MatrizUvms { get; set; }

    public virtual DbSet<MatrizUvmIndicadorUvm> MatrizUvmIndicadorUvms { get; set; }

    public virtual DbSet<MatrizUvmSubIndicadorUvm> MatrizUvmSubIndicadorUvms { get; set; }

    public virtual DbSet<NivelAtencion> NivelAtencions { get; set; }

    public virtual DbSet<NivelModalidad> NivelModalidads { get; set; }

    public virtual DbSet<NivelOrganizacional> NivelOrganizacionals { get; set; }

    public virtual DbSet<NivelRevision> NivelRevisions { get; set; }

    public virtual DbSet<Normativa> Normativas { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<PerfilCampus> PerfilCampuses { get; set; }

    public virtual DbSet<PerfilVistaTipoAcceso> PerfilVistaTipoAccesos { get; set; }

    public virtual DbSet<PerfilVistum> PerfilVista { get; set; }

    public virtual DbSet<PeriodoEvaluacion> PeriodoEvaluacions { get; set; }

    public virtual DbSet<Ponderacion> Ponderacions { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RegistroElementoEvaluacionArchivo> RegistroElementoEvaluacionArchivos { get; set; }

    public virtual DbSet<RegistroEvidenciaArchivo> RegistroEvidenciaArchivos { get; set; }

    public virtual DbSet<RegistroEvidencium> RegistroEvidencia { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolProceso> RolProcesos { get; set; }

    public virtual DbSet<RolProcesoVistaTipoAcceso> RolProcesoVistaTipoAccesos { get; set; }

    public virtual DbSet<RolProcesoVistum> RolProcesoVista { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<SubIndicadorUvm> SubIndicadorUvms { get; set; }

    public virtual DbSet<Subarea> Subareas { get; set; }

    public virtual DbSet<TipoAcceso> TipoAccesos { get; set; }

    public virtual DbSet<TipoEvidencium> TipoEvidencia { get; set; }

    public virtual DbSet<TmpMsXxTipoEvidencium> TmpMsXxTipoEvidencia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRolProceso> UsuarioRolProcesos { get; set; }

    public virtual DbSet<UsuarioRolProcesoCapitulo> UsuarioRolProcesoCapitulos { get; set; }

    public virtual DbSet<UsuarioRolProcesoCriterio> UsuarioRolProcesoCriterios { get; set; }

    public virtual DbSet<Vistum> Vista { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile("appsettings.json", optional: false).Build();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SGAPI"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acreditadora>(entity =>
        {
            entity.ToTable("Acreditadora", tb => tb.HasComment("Listado de Acreditadoras"));

            entity.Property(e => e.AcreditadoraId)
                .HasMaxLength(50)
                .HasComment("Siglas de identificación única para la acreditadora.")
                .HasColumnName("AcreditadoraID");
            entity.Property(e => e.Activo).HasComment("Indicador de activo/inactivo para el registro.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre de la acreditadora.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación sobre el registro.");
        });

        modelBuilder.Entity<AcreditadoraProceso>(entity =>
        {
            entity.ToTable("AcreditadoraProceso", tb => tb.HasComment("Listado de procesos por acreditadora."));

            entity.HasIndex(e => e.AcreditadoraProcesoId, "IX_AcreditadoraProceso");

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador único del proceso.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.AcreditadoraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la acreditadora a la que perteneces este proceso.")
                .HasColumnName("AcreditadoraID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFin)
                .HasComment("Fecha de fin del proceso. Limite para generar y documentar evidencias.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaInicio)
                .HasComment("Fecha de inicio del proceso.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del proceso. Usualmente es un año seguido de un ciclo.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación sobre el registro.");

            entity.HasOne(d => d.Acreditadora).WithMany(p => p.AcreditadoraProcesos)
                .HasForeignKey(d => d.AcreditadoraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcreditadoraProceso_Acreditadora");
        });

        modelBuilder.Entity<Apartado>(entity =>
        {
            entity.ToTable("Apartado", tb => tb.HasComment("Apartados del libro electrónico."));

            entity.HasIndex(e => new { e.AcreditadoraProcesoId, e.CarreraId }, "CL_APARTADO");

            entity.Property(e => e.ApartadoId)
                .HasComment("Identificador único del apartado.")
                .HasColumnName("ApartadoID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este apartado.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.ApartadoPadre).HasComment("Identificador del padre de este apartado. NULL en caso de ser un apartado de primer nivel.");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia este apartado.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Identificador del criterio al que se asocia este apartado.")
                .HasColumnName("CriterioID");
            entity.Property(e => e.Especificaciones).HasComment("Contenido en HTML del apartado.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Orden).HasComment("Indica el orden de despliegue de los apartados. Se ordenan de menor a mayor, agrupados por niveles herárquicos.");
            entity.Property(e => e.Titulo)
                .HasMaxLength(500)
                .HasComment("Titulo del apartado.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.ApartadoPadreNavigation).WithMany(p => p.InverseApartadoPadreNavigation)
                .HasForeignKey(d => d.ApartadoPadre)
                .HasConstraintName("FK_Apartado_Apartado");

            entity.HasOne(d => d.Carrera).WithMany(p => p.Apartados)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartado_Carrera");

            entity.HasOne(d => d.Criterio).WithMany(p => p.Apartados)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CriterioId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartado_Criterio");
        });

        modelBuilder.Entity<AreaCorporativa>(entity =>
        {
            entity.ToTable("AreaCorporativa", tb => tb.HasComment("Catálogo de la área corporativa."));

            entity.Property(e => e.AreaCorporativaId)
                .HasMaxLength(5)
                .HasComment("Clave única de la área corporativa.")
                .HasColumnName("AreaCorporativaID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre de la área corporativa.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<AreaCorporativaSubArea>(entity =>
        {
            entity.HasKey(e => e.AreaCorporativaSubAreaId).HasName("PK_SubAreaCorporativa");

            entity.ToTable("AreaCorporativaSubArea", tb => tb.HasComment("Subareas de una área corporativa."));

            entity.Property(e => e.AreaCorporativaSubAreaId)
                .HasComment("Clave única de la sub área corporativa.")
                .HasColumnName("AreaCorporativaSubAreaID");
            entity.Property(e => e.AreaCorporativaId)
                .HasMaxLength(5)
                .HasComment("Identificador de la área corporativa.")
                .HasColumnName("AreaCorporativaID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre de la sub área corporativa ");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AreaCorporativa).WithMany(p => p.AreaCorporativaSubAreas)
                .HasForeignKey(d => d.AreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubAreaCorporativa_AreaCorporativa");
        });

        modelBuilder.Entity<AreaResponsabilidad>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.AreaResponsabilidadId });

            entity.ToTable("AreaResponsabilidad", tb => tb.HasComment("Listado de áreas de reponsabilidad."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece esta área.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.AreaResponsabilidadId)
                .HasMaxLength(50)
                .HasComment("Siglas de la área de responsabilidad dentro del proceso.")
                .HasColumnName("AreaResponsabilidadID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelAtencionId)
                .HasMaxLength(50)
                .HasComment("Identificador del nivel de atención asociado a esta área.")
                .HasColumnName("NivelAtencionID");
            entity.Property(e => e.NivelOrganizacionalId)
                .HasMaxLength(50)
                .HasComment("Identificador del nivel de organizacional asociado a esta área.")
                .HasColumnName("NivelOrganizacionalID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del área de responsabilidad.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.AreaResponsabilidads)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaResponsabilidad_AcreditadoraProceso");

            entity.HasOne(d => d.NivelAtencion).WithMany(p => p.AreaResponsabilidads)
                .HasForeignKey(d => d.NivelAtencionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaResponsabilidad_NivelAtencion");

            entity.HasOne(d => d.NivelOrganizacional).WithMany(p => p.AreaResponsabilidads)
                .HasForeignKey(d => d.NivelOrganizacionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaResponsabilidad_NivelOrganizacional");
        });

        modelBuilder.Entity<AreaResponsable>(entity =>
        {
            entity.ToTable("AreaResponsable", tb => tb.HasComment("Catálogo de áreas responsables."));

            entity.Property(e => e.AreaResponsableId)
                .HasComment("Clave única del Área responsable.")
                .HasColumnName("AreaResponsableID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.AreaResponsablePadre).HasComment("Identificador del Área responsable padre al que pertenece este Área responsable.");
            entity.Property(e => e.Consolidacion).HasComment("Indica si la información se va a consolidar los resultados de la etapa de Autoevaluación.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Generica).HasComment("Indica si el Área responsable es genérica.");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre del área responsable");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AreaResponsablePadreNavigation).WithMany(p => p.InverseAreaResponsablePadreNavigation)
                .HasForeignKey(d => d.AreaResponsablePadre)
                .HasConstraintName("FK_AreaResponsable_AreaResponsable1");
        });

        modelBuilder.Entity<AreaResponsableNivelModalidad>(entity =>
        {
            entity.ToTable("AreaResponsableNivelModalidad");

            entity.Property(e => e.AreaResponsableNivelModalidadId)
                .HasComment("Identificador del Área responsable para el Nivel/Modalidad.")
                .HasColumnName("AreaResponsableNivelModalidadID");
            entity.Property(e => e.AreaResponsableId)
                .HasComment("Identificador del Área responsable.")
                .HasColumnName("AreaResponsableID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelModalidadId)
                .HasMaxLength(5)
                .HasComment("Identificador del Nivel/Modalidad.")
                .HasColumnName("NivelModalidadID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AreaResponsable).WithMany(p => p.AreaResponsableNivelModalidads)
                .HasForeignKey(d => d.AreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaResponsableNivelModalidad_AreaResponsable");

            entity.HasOne(d => d.NivelModalidad).WithMany(p => p.AreaResponsableNivelModalidads)
                .HasForeignKey(d => d.NivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaResponsableNivelModalidad_NivelModalidad");
        });

        modelBuilder.Entity<Campus>(entity =>
        {
            entity.HasKey(e => e.CampusId).HasName("PK__Campus__FD598D3652A354C3");

            entity.ToTable("Campus", tb => tb.HasComment("Catálogo de campus."));

            entity.Property(e => e.CampusId)
                .HasMaxLength(50)
                .HasComment("Clave única del campus. ")
                .HasColumnName("CampusID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del campus.");
            entity.Property(e => e.RegionId)
                .HasMaxLength(50)
                .HasComment("Región a la que pertenece este campus.")
                .HasColumnName("RegionID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Region).WithMany(p => p.Campuses)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Campus_Region");

            entity.HasMany(d => d.NivelModalidads).WithMany(p => p.Campuses)
                .UsingEntity<Dictionary<string, object>>(
                    "CampusNivelModalidad",
                    r => r.HasOne<NivelModalidad>().WithMany()
                        .HasForeignKey("NivelModalidadId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CampusNivelModalidad_NivelModalidad"),
                    l => l.HasOne<Campus>().WithMany()
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CampusNivelModalidad_Campus"),
                    j =>
                    {
                        j.HasKey("CampusId", "NivelModalidadId").HasName("PK_Campus_NivelModalidad");
                        j.ToTable("CampusNivelModalidad", tb => tb.HasComment("Asociación entre campus y nivel/modalidad del sistema."));
                        j.IndexerProperty<string>("CampusId")
                            .HasMaxLength(50)
                            .HasColumnName("CampusID");
                        j.IndexerProperty<string>("NivelModalidadId")
                            .HasMaxLength(5)
                            .HasColumnName("NivelModalidadID");
                    });
        });

        modelBuilder.Entity<Capitulo>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.CapituloId });

            entity.ToTable("Capitulo", tb => tb.HasComment("Listado de cápitulos."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este cápitulo.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CapituloId)
                .HasMaxLength(50)
                .HasComment("Número del cápitulo dentro del proceso.")
                .HasColumnName("CapituloID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .HasComment("Descripción larga del cápitulo.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del cápitulo.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.Capitulos)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Capitulo_AcreditadoraProceso");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.CarreraId).HasName("PK__Carrera__3E43B181735CB4C8");

            entity.ToTable("Carrera", tb => tb.HasComment("Catálogo de carreras."));

            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Siglas de identificación única para la carrera.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.Activo).HasComment("Indicador de activo/inactivo para el registro.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre descriptivo de la carrera.");
            entity.Property(e => e.Plan)
                .HasMaxLength(15)
                .HasComment("Plan de la carrera.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación sobre el registro.");
        });

        modelBuilder.Entity<CatalogoElementoEvaluacion>(entity =>
        {
            entity.HasKey(e => e.ElementoEvaluacionId);

            entity.ToTable("CatalogoElementoEvaluacion");

            entity.Property(e => e.ElementoEvaluacionId)
                .HasMaxLength(5)
                .HasComment("Clave del elemento de evaluacion")
                .HasColumnName("ElementoEvaluacionID");
            entity.Property(e => e.Activo).HasComment("Muestra el estatus del registro");
            entity.Property(e => e.CantidadEvidencia).HasComment(" Es un valor numérico entero de 3 posiciones");
            entity.Property(e => e.DescripcionEvidencia)
                .HasMaxLength(200)
                .HasComment("Descripción detallada de la evidencia");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha que se creo el registro")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Usuario que  modifico el registro")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreElementoEvaluacion)
                .HasMaxLength(150)
                .HasComment("Nombre del elemento de evaluacion");
            entity.Property(e => e.NombreEvidencia)
                .HasMaxLength(150)
                .HasComment("Nombre de la Evidencia");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que creo el registro");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que modifico el registro");
        });

        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.CicloId).HasName("PK__Ciclo");

            entity.ToTable("Ciclo", tb => tb.HasComment("Catálogo de ciclos."));

            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasComment("Clave única del ciclo.")
                .HasColumnName("CicloID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasComment("Nombre del ciclo.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<ComentarioSeguimiento>(entity =>
        {
            entity.ToTable("ComentarioSeguimiento", tb => tb.HasComment("Comentarios de seguimiento sobre un proceso de acreditación."));

            entity.Property(e => e.ComentarioSeguimientoId)
                .HasComment("Identificador único del comentario de seguimiento.")
                .HasColumnName("ComentarioSeguimientoID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este comentario.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia este comentario.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.Contenido).HasComment("Contenido del comentario. Texto abierto.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Titulo)
                .HasMaxLength(500)
                .HasComment("Titulo del comentario.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.ComentarioSeguimientos)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComentarioSeguimiento_AcreditadoraProceso");

            entity.HasOne(d => d.Carrera).WithMany(p => p.ComentarioSeguimientos)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComentarioSeguimiento_Carrera");
        });

        modelBuilder.Entity<Componente>(entity =>
        {
            entity.ToTable("Componente", tb => tb.HasComment("Catálogo de componentes."));

            entity.Property(e => e.ComponenteId)
                .HasMaxLength(5)
                .HasComment("Clave única del componente. ")
                .HasColumnName("ComponenteID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre del componente.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<ComponenteUvm>(entity =>
        {
            entity.ToTable("ComponenteUvm");

            entity.Property(e => e.ComponenteUvmId)
                .HasComment("Clave única del componente uvm.")
                .HasColumnName("ComponenteUvmID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.DescripcionComponenteUvm)
                .HasMaxLength(500)
                .HasComment("Descripción del componente uvm.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreComponenteUvm)
                .HasMaxLength(200)
                .HasComment("Nombre del componente uvm.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<ConfiguracionGeneral>(entity =>
        {
            entity.HasKey(e => new { e.ConfiguracionGeneralId, e.Anio, e.CicloId }).HasName("PK_ConfiguracionNivelAreaResponsable");

            entity.ToTable("ConfiguracionGeneral", tb => tb.HasComment("Configuración general para SIAC"));

            entity.Property(e => e.ConfiguracionGeneralId)
                .ValueGeneratedOnAdd()
                .HasComment("Clave única de la configuración general para SIAC")
                .HasColumnName("ConfiguracionGeneralID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasComment("Identificador del Ciclo para esta configuración.")
                .HasColumnName("CicloID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.AreaResponsableId)
                .HasComment("Identificador del Área responsable para esta configuración.")
                .HasColumnName("AreaResponsableID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelModalidadId)
                .HasMaxLength(5)
                .HasComment("Identificador del Nivel/Modalidad para esta configuración.")
                .HasColumnName("NivelModalidadID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AreaResponsable).WithMany(p => p.ConfiguracionGenerals)
                .HasForeignKey(d => d.AreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionNivelAreaResponsable_AreaResponsable");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.ConfiguracionGenerals)
                .HasForeignKey(d => d.CicloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionGeneral_Ciclo");

            entity.HasOne(d => d.NivelModalidad).WithMany(p => p.ConfiguracionGenerals)
                .HasForeignKey(d => d.NivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionNivelAreaResponsable_NivelModalidad");
        });

        modelBuilder.Entity<ConfiguracionIndicadorSiac>(entity =>
        {
            entity.ToTable("ConfiguracionIndicadorSiac");

            entity.Property(e => e.ConfiguracionIndicadorSiacId).HasColumnName("ConfiguracionIndicadorSiacID");
            entity.Property(e => e.AreaResponsableId).HasColumnName("AreaResponsableID");
            entity.Property(e => e.CatalogoIndicadorSiacId)
                .HasMaxLength(5)
                .HasColumnName("CatalogoIndicadorSiacID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasColumnName("CicloID");
            entity.Property(e => e.ComponenteId)
                .HasMaxLength(5)
                .HasColumnName("ComponenteID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.MatrizUvmId).HasColumnName("MatrizUvmID");
            entity.Property(e => e.NivelModalidadId)
                .HasMaxLength(5)
                .HasColumnName("NivelModalidadID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.AreaResponsable).WithMany(p => p.ConfiguracionIndicadorSiacs)
                .HasForeignKey(d => d.AreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionIndicadorSiac_AreaResponsable");

            entity.HasOne(d => d.CatalogoIndicadorSiac).WithMany(p => p.ConfiguracionIndicadorSiacs)
                .HasForeignKey(d => d.CatalogoIndicadorSiacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionIndicadorSiac_CatalogoIndicadorSiacId");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.ConfiguracionIndicadorSiacs)
                .HasForeignKey(d => d.CicloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionIndicadorSiac_Ciclo");

            entity.HasOne(d => d.Componente).WithMany(p => p.ConfiguracionIndicadorSiacs)
                .HasForeignKey(d => d.ComponenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionIndicadorSiac_Componente");

            entity.HasOne(d => d.MatrizUvm).WithMany(p => p.ConfiguracionIndicadorSiacs)
                .HasForeignKey(d => d.MatrizUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionIndicadorSiac_MatrizUvm");

            entity.HasOne(d => d.NivelModalidad).WithMany(p => p.ConfiguracionIndicadorSiacs)
                .HasForeignKey(d => d.NivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfiguracionIndicadorSiac_NivelModalidad");
        });

        modelBuilder.Entity<ConfiguracionSistema>(entity =>
        {
            entity.ToTable("ConfiguracionSistema");

            entity.Property(e => e.ConfiguracionSistemaId)
                .HasComment("Identificador del registro de configuración.")
                .HasColumnName("ConfiguracionSistemaID");
            entity.Property(e => e.MensajeBienvenida)
                .HasMaxLength(4000)
                .HasComment("Mensaje de bienvenida en el portal FIMPES");
            entity.Property(e => e.UrlManual)
                .HasMaxLength(400)
                .HasComment("URL donde se puedes descargar el manual de la plataforma FIMPES");
        });

        modelBuilder.Entity<Criterio>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.CriterioId, e.CarreraId });

            entity.ToTable("Criterio", tb => tb.HasComment("Listado de Criterios por Proceso"));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este criterio.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Número del criterio dentro del proceso.")
                .HasColumnName("CriterioID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia este criterio. Null significa que no aplica.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.CapituloId)
                .HasMaxLength(50)
                .HasComment("Identificador del cápitulo al que se asocia este criterio.")
                .HasColumnName("CapituloID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .HasComment("Descripción larga del criterio.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.TipoEvidenciaId)
                .HasMaxLength(50)
                .HasComment("Identificador del tipo de evidencia que se usará para este criterio.")
                .HasColumnName("TipoEvidenciaID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.Criterios)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Criterio_AcreditadoraProceso");

            entity.HasOne(d => d.Carrera).WithMany(p => p.Criterios)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Criterio_Carrera");

            entity.HasOne(d => d.Capitulo).WithMany(p => p.Criterios)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CapituloId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Criterio_Capitulo");

            entity.HasOne(d => d.TipoEvidencium).WithMany(p => p.Criterios)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.TipoEvidenciaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Criterio_TipoEvidencia");
        });

        modelBuilder.Entity<ElementoEvaluacion>(entity =>
        {
            entity.HasKey(e => e.ElementoEvaluacionId).HasName("PK_ElementoEvaluacion_1");

            entity.ToTable("ElementoEvaluacion", tb => tb.HasComment("Elementos de evaluación "));

            entity.Property(e => e.ElementoEvaluacionId)
                .HasComment("Clave única del elemento de evaluación. ")
                .HasColumnName("ElementoEvaluacionID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Anio).HasComment("Año al que perteneece el elemento de evaluación");
            entity.Property(e => e.AreaCorporativaId)
                .HasMaxLength(5)
                .HasComment("Identificador del Área corporativa a la que pertenece el elemento de evaluación.")
                .HasColumnName("AreaCorporativaID");
            entity.Property(e => e.AreaResponsableId)
                .HasComment("Clave del área responsable")
                .HasColumnName("AreaResponsableID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasComment("Identificador del Ciclo para esta configuración.")
                .HasColumnName("CicloID");
            entity.Property(e => e.ComponenteId)
                .HasMaxLength(5)
                .HasComment("Identificador del Componente que pertenece al elemento de evaluación.")
                .HasColumnName("ComponenteID");
            entity.Property(e => e.ElementoEvaluacionCatalogoId)
                .HasMaxLength(5)
                .HasComment("Clave del catalogo de elemento de evaluacion");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Generica).HasComment("Tipo de area si es generica es verdadero");
            entity.Property(e => e.NivelModalidadId)
                .HasMaxLength(5)
                .HasComment("Clave del registro nivel modalidad")
                .HasColumnName("NivelModalidadID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AreaCorporativa).WithMany(p => p.ElementoEvaluacions)
                .HasForeignKey(d => d.AreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementoEvaluacion_AreaCorporativa");

            entity.HasOne(d => d.AreaResponsable).WithMany(p => p.ElementoEvaluacions)
                .HasForeignKey(d => d.AreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementoEvaluacion_AreaResponsable");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.ElementoEvaluacions)
                .HasForeignKey(d => d.CicloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementoEvaluacion_Ciclo");

            entity.HasOne(d => d.Componente).WithMany(p => p.ElementoEvaluacions)
                .HasForeignKey(d => d.ComponenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementoEvaluacion_Componente");

            entity.HasOne(d => d.ElementoEvaluacionCatalogo).WithMany(p => p.ElementoEvaluacions)
                .HasForeignKey(d => d.ElementoEvaluacionCatalogoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementoEvaluacion_CatalogoElementoEvaluacion");

            entity.HasOne(d => d.NivelModalidad).WithMany(p => p.ElementoEvaluacions)
                .HasForeignKey(d => d.NivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementoEvaluacion_NivelModalidad");

            entity.HasMany(d => d.Normativas).WithMany(p => p.ElementoEvaluacions)
                .UsingEntity<Dictionary<string, object>>(
                    "ElementoEvaluacionNormativa",
                    r => r.HasOne<Normativa>().WithMany()
                        .HasForeignKey("NormativaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ElementoEvaluacionNormativa_Normativa"),
                    l => l.HasOne<ElementoEvaluacion>().WithMany()
                        .HasForeignKey("ElementoEvaluacionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ElementoEvaluacionNormativa_ElementoEvaluacion"),
                    j =>
                    {
                        j.HasKey("ElementoEvaluacionId", "NormativaId");
                        j.ToTable("ElementoEvaluacionNormativa", tb => tb.HasComment("Asociación entre elementos de evaluación y normativas"));
                        j.IndexerProperty<int>("ElementoEvaluacionId")
                            .HasComment("Identificador del elemento de evaluación.")
                            .HasColumnName("ElementoEvaluacionID");
                        j.IndexerProperty<string>("NormativaId")
                            .HasMaxLength(5)
                            .HasComment("Identificador de la normativa.")
                            .HasColumnName("NormativaID");
                    });
        });

        modelBuilder.Entity<EscalaMedicion>(entity =>
        {
            entity.HasKey(e => e.EscalaMedicionId).HasName("PK_EsacalaMedicion");

            entity.ToTable("EscalaMedicion");

            entity.Property(e => e.EscalaMedicionId).HasColumnName("EscalaMedicionID");
            entity.Property(e => e.AreaResponsableId).HasColumnName("AreaResponsableID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasColumnName("CicloID");
            entity.Property(e => e.ComponenteId)
                .HasMaxLength(5)
                .HasColumnName("ComponenteID");
            entity.Property(e => e.ElementoEvaluacionId).HasColumnName("ElementoEvaluacionID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NivelModalidadId)
                .HasMaxLength(5)
                .HasColumnName("NivelModalidadID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.AreaResponsable).WithMany(p => p.EscalaMedicions)
                .HasForeignKey(d => d.AreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EsacalaMedicion_AreaResponsable");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.EscalaMedicions)
                .HasForeignKey(d => d.CicloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EsacalaMedicion_Ciclo");

            entity.HasOne(d => d.Componente).WithMany(p => p.EscalaMedicions)
                .HasForeignKey(d => d.ComponenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EsacalaMedicion_Componente");

            entity.HasOne(d => d.ElementoEvaluacion).WithMany(p => p.EscalaMedicions)
                .HasForeignKey(d => d.ElementoEvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EsacalaMedicion_ElementoEvaluacion");

            entity.HasOne(d => d.NivelModalidad).WithMany(p => p.EscalaMedicions)
                .HasForeignKey(d => d.NivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EsacalaMedicion_NivelModalidad");
        });

        modelBuilder.Entity<EscalaMedicionEscenario>(entity =>
        {
            entity.HasKey(e => e.EscenarioId);

            entity.Property(e => e.EscenarioId).HasColumnName("EscenarioID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.EscalaMedicionId).HasColumnName("EscalaMedicionID");

            entity.HasOne(d => d.EscalaMedicion).WithMany(p => p.EscalaMedicionEscenarios)
                .HasForeignKey(d => d.EscalaMedicionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EscalaMedicionEscenarios_EsacalaMedicion");
        });

        modelBuilder.Entity<EvidenciaAnio>(entity =>
        {
            entity.HasKey(e => new { e.AnioId, e.EvidenciaId, e.AcreditadoraProcesoId, e.CarreraId, e.CriterioId });

            entity.ToTable("EvidenciaAnio", tb => tb.HasComment("Relación entre evidencias y años"));

            entity.Property(e => e.AnioId).HasColumnName("AnioID");
            entity.Property(e => e.EvidenciaId).HasColumnName("EvidenciaID");
            entity.Property(e => e.AcreditadoraProcesoId).HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasColumnName("CriterioID");

            entity.HasOne(d => d.Evidencium).WithMany(p => p.EvidenciaAnios)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CarreraId, d.CriterioId, d.EvidenciaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvidenciaAnio_Evidencia");
        });

        modelBuilder.Entity<Evidencium>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.CarreraId, e.CriterioId, e.EvidenciaId });

            entity.ToTable(tb => tb.HasComment("Indice de evidencias por proceso y carrera."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece esta evidencia.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.")
                .HasColumnName("CriterioID");
            entity.Property(e => e.EvidenciaId)
                .HasComment("Número del evidencia dentro del proceso.")
                .HasColumnName("EvidenciaID");
            entity.Property(e => e.AreaResponsabilidadId)
                .HasMaxLength(50)
                .HasColumnName("AreaResponsabilidadID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .HasComment("Descripción larga de la evidencia.");
            entity.Property(e => e.Especificaciones)
                .HasMaxLength(4000)
                .HasComment("Especificaciones para capturar la evidencia.");
            entity.Property(e => e.FechaCompromiso)
                .HasComment("Fecha compromiso para el registro de las evidencias. Debe ser inferior a la fecha de fin del proceso.")
                .HasColumnType("date");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelOrganizacionalId)
                .HasMaxLength(50)
                .HasColumnName("NivelOrganizacionalID");
            entity.Property(e => e.Responsable).HasComment("Identificador del responsable general de estas evidencias.");
            entity.Property(e => e.SedeId)
                .HasMaxLength(50)
                .HasColumnName("SedeID");
            entity.Property(e => e.TipoEvidenciaId)
                .HasMaxLength(50)
                .HasColumnName("TipoEvidenciaID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidencia_AcreditadoraProceso");

            entity.HasOne(d => d.Carrera).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidencia_Carrera");

            entity.HasOne(d => d.NivelOrganizacional).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.NivelOrganizacionalId)
                .HasConstraintName("FK_Evidencia_NivelOrganizacional");

            entity.HasOne(d => d.ResponsableNavigation).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.Responsable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidencia_Usuario");

            entity.HasOne(d => d.Sede).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.SedeId)
                .HasConstraintName("FK_Evidencia_Sede");

            entity.HasOne(d => d.A).WithMany(p => p.Evidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.AreaResponsabilidadId })
                .HasConstraintName("FK_Evidencia_AreaResponsabilidad");

            entity.HasOne(d => d.TipoEvidencium).WithMany(p => p.Evidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.TipoEvidenciaId })
                .HasConstraintName("FK_Evidencia_TipoEvidencia");

            entity.HasOne(d => d.Criterio).WithMany(p => p.Evidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CriterioId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidencia_Criterio");

            entity.HasMany(d => d.Campuses).WithMany(p => p.Evidencia)
                .UsingEntity<Dictionary<string, object>>(
                    "EvidenciaCampus",
                    r => r.HasOne<Campus>().WithMany()
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaCampus_Campus"),
                    l => l.HasOne<Evidencium>().WithMany()
                        .HasForeignKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaCampus_Evidencia"),
                    j =>
                    {
                        j.HasKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId", "CampusId");
                        j.ToTable("EvidenciaCampus", tb => tb.HasComment("Relación entre evidencias y campuses."));
                        j.IndexerProperty<int>("AcreditadoraProcesoId")
                            .HasComment("Identificador del proceso al que pertenece esta evidencia.")
                            .HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("CarreraId")
                            .HasMaxLength(50)
                            .HasComment("Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.")
                            .HasColumnName("CarreraID");
                        j.IndexerProperty<string>("CriterioId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.")
                            .HasColumnName("CriterioID");
                        j.IndexerProperty<int>("EvidenciaId")
                            .HasComment("Número del evidencia dentro del proceso.")
                            .HasColumnName("EvidenciaID");
                        j.IndexerProperty<string>("CampusId")
                            .HasMaxLength(50)
                            .HasColumnName("CampusID");
                    });

            entity.HasMany(d => d.Ciclos).WithMany(p => p.Evidencia)
                .UsingEntity<Dictionary<string, object>>(
                    "EvidenciaCiclo",
                    r => r.HasOne<Ciclo>().WithMany()
                        .HasForeignKey("CicloId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaCiclo_Ciclo"),
                    l => l.HasOne<Evidencium>().WithMany()
                        .HasForeignKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaCiclo_Evidencia"),
                    j =>
                    {
                        j.HasKey("EvidenciaId", "CicloId", "AcreditadoraProcesoId", "CriterioId", "CarreraId");
                        j.ToTable("EvidenciaCiclo", tb => tb.HasComment("Relación entre evidencias y ciclos"));
                        j.IndexerProperty<int>("EvidenciaId").HasColumnName("EvidenciaID");
                        j.IndexerProperty<string>("CicloId")
                            .HasMaxLength(50)
                            .HasColumnName("CicloID");
                        j.IndexerProperty<int>("AcreditadoraProcesoId").HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("CriterioId")
                            .HasMaxLength(50)
                            .HasColumnName("CriterioID");
                        j.IndexerProperty<string>("CarreraId")
                            .HasMaxLength(50)
                            .HasColumnName("CarreraID");
                    });

            entity.HasMany(d => d.Subareas).WithMany(p => p.Evidencia)
                .UsingEntity<Dictionary<string, object>>(
                    "EvidenciaSubarea",
                    r => r.HasOne<Subarea>().WithMany()
                        .HasForeignKey("SubareaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaSubarea_Subarea"),
                    l => l.HasOne<Evidencium>().WithMany()
                        .HasForeignKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaSubarea_Evidencia"),
                    j =>
                    {
                        j.HasKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId", "SubareaId");
                        j.ToTable("EvidenciaSubarea", tb => tb.HasComment("Relación entre evidencias y subáreas."));
                        j.IndexerProperty<int>("AcreditadoraProcesoId")
                            .HasComment("Identificador del proceso al que pertenece esta evidencia.")
                            .HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("CarreraId")
                            .HasMaxLength(50)
                            .HasComment("Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.")
                            .HasColumnName("CarreraID");
                        j.IndexerProperty<string>("CriterioId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.")
                            .HasColumnName("CriterioID");
                        j.IndexerProperty<int>("EvidenciaId")
                            .HasComment("Número del evidencia dentro del proceso.")
                            .HasColumnName("EvidenciaID");
                        j.IndexerProperty<string>("SubareaId")
                            .HasMaxLength(50)
                            .HasColumnName("SubareaID");
                    });
        });

        modelBuilder.Entity<IndicadorMatriz>(entity =>
        {
            entity.ToTable("IndicadorMatriz", tb => tb.HasComment("Catálogo de matriz de indicadores de UVM."));

            entity.Property(e => e.IndicadorMatrizId)
                .ValueGeneratedNever()
                .HasComment("Clave única de la matriz e indicador UVM. ")
                .HasColumnName("IndicadorMatrizID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<IndicadorSiac>(entity =>
        {
            entity.ToTable("IndicadorSiac");

            entity.Property(e => e.IndicadorSiacId)
                .HasMaxLength(5)
                .HasComment("Clave del indicador siac")
                .HasColumnName("IndicadorSiacID");
            entity.Property(e => e.Activo).HasComment("Estatus del indicador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasComment("Descripción del indicador siac");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del indicador")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de modificación del indicador siac")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre del indicador siac");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que creo el indicador siac");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que modifico del indicador siac");
        });

        modelBuilder.Entity<IndicadorUvm>(entity =>
        {
            entity.ToTable("IndicadorUvm");

            entity.Property(e => e.IndicadorUvmId)
                .HasComment("Clave única del indicador uvm.")
                .HasColumnName("IndicadorUvmID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreIndicadorUvm)
                .HasMaxLength(200)
                .HasComment("Nombre del indicador uvm.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<MatrizUvm>(entity =>
        {
            entity.ToTable("MatrizUvm");

            entity.Property(e => e.MatrizUvmId)
                .HasComment("Indentificador unico de matriz uvm")
                .HasColumnName("MatrizUvmID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.ComponenteUvmId)
                .HasComment("Clave de la relación de componente uvm y de matriz uvm")
                .HasColumnName("ComponenteUvmID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.ComponenteUvm).WithMany(p => p.MatrizUvms)
                .HasForeignKey(d => d.ComponenteUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatrizUvm_ComponenteUvm");
        });

        modelBuilder.Entity<MatrizUvmIndicadorUvm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MatrizUvmIndicadorUvm");

            entity.Property(e => e.IndicadorUvmId)
                .HasComment("Clave de la relación de  matriz indicador uvm e Indicador uvm")
                .HasColumnName("IndicadorUvmID");
            entity.Property(e => e.MatrizUvmId)
                .HasComment("Clave de la relación de matriz uvm y matriz indicador uvm")
                .HasColumnName("MatrizUvmID");

            entity.HasOne(d => d.IndicadorUvm).WithMany()
                .HasForeignKey(d => d.IndicadorUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatrizUvmIndicadorUvm_IndicadorUvmID");

            entity.HasOne(d => d.MatrizUvm).WithMany()
                .HasForeignKey(d => d.MatrizUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatrizUvmIndicadorUvm_MatrizUvmID");
        });

        modelBuilder.Entity<MatrizUvmSubIndicadorUvm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MatrizUvmSubIndicadorUvm");

            entity.Property(e => e.MatrizUvmId).HasColumnName("MatrizUvmID");
            entity.Property(e => e.SubIndicadorUvmId).HasColumnName("SubIndicadorUvmID");

            entity.HasOne(d => d.MatrizUvm).WithMany()
                .HasForeignKey(d => d.MatrizUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatrizUvmSubIndicadorUvm_MatrizUvmID");

            entity.HasOne(d => d.SubIndicadorUvm).WithMany()
                .HasForeignKey(d => d.SubIndicadorUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatrizUvmSubIndicadorUvm_SubIndicadorUvmID");
        });

        modelBuilder.Entity<NivelAtencion>(entity =>
        {
            entity.HasKey(e => e.NivelAtencionId).HasName("PK__NivelAte__70133C66542AE049");

            entity.ToTable("NivelAtencion", tb => tb.HasComment("Catálogo de niveles de atención."));

            entity.Property(e => e.NivelAtencionId)
                .HasMaxLength(50)
                .HasComment("Clave única del nivel de atención. ")
                .HasColumnName("NivelAtencionID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del nivel de atención.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<NivelModalidad>(entity =>
        {
            entity.ToTable("NivelModalidad", tb => tb.HasComment("Listado de Nivel/Modalidad"));

            entity.HasIndex(e => e.NivelModalidadId, "PK__NivelModalidad").IsUnique();

            entity.Property(e => e.NivelModalidadId)
                .HasMaxLength(5)
                .HasComment("Siglas de identificación única para la Nivel/Modalidad.")
                .HasColumnName("NivelModalidadID");
            entity.Property(e => e.Activo).HasComment("Indicador de activo/inactivo para el registro.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Modalidad)
                .HasMaxLength(100)
                .HasComment("Modalidad de Nivel/Modalidad.");
            entity.Property(e => e.Nivel)
                .HasMaxLength(100)
                .HasComment("Nivel  de Nivel/Modalidad.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación sobre el registro.");
        });

        modelBuilder.Entity<NivelOrganizacional>(entity =>
        {
            entity.HasKey(e => e.NivelOrganizacionalId).HasName("PK__NivelOrg__DBFF4C51C6E46066");

            entity.ToTable("NivelOrganizacional", tb => tb.HasComment("Catálogo de niveles organizacionales."));

            entity.Property(e => e.NivelOrganizacionalId)
                .HasMaxLength(50)
                .HasComment("Clave única del nivel organizacional. ")
                .HasColumnName("NivelOrganizacionalID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del nivel organizacional.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<NivelRevision>(entity =>
        {
            entity.ToTable("NivelRevision", tb => tb.HasComment("Catálogo de nivel de revisión."));

            entity.Property(e => e.NivelRevisionId)
                .HasComment("Clave única del nivel de revisión ")
                .HasColumnName("NivelRevisionID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Descripción)
                .HasMaxLength(150)
                .HasComment("Descripción del nivel de revisión.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasComment("Nombre del nivel de revisión.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<Normativa>(entity =>
        {
            entity.ToTable("Normativa", tb => tb.HasComment("Catálogo de normativas."));

            entity.Property(e => e.NormativaId)
                .HasMaxLength(5)
                .HasComment("Clave única de la normativa. ")
                .HasColumnName("NormativaID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre del componente.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.ToTable("Perfil", tb => tb.HasComment("Catálogo de matriz de indicadores de Perfiles."));

            entity.Property(e => e.PerfilId)
                .HasComment("Clave única del perfil. ")
                .HasColumnName("PerfilID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasComment("Nombre del perfil.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
            entity.Property(e => e.VistaInicial)
                .HasMaxLength(50)
                .HasComment("Vista inicial del usuario al iniciar sesión.");

            entity.HasOne(d => d.VistaInicialNavigation).WithMany(p => p.Perfils)
                .HasForeignKey(d => d.VistaInicial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Perfil_Vista");
        });

        modelBuilder.Entity<PerfilCampus>(entity =>
        {
            entity.ToTable("PerfilCampus", tb => tb.HasComment("Asociación entre perfil y campuses del sistema."));

            entity.Property(e => e.PerfilCampusId)
                .HasComment("Clave única de la asociación perfil y campus.")
                .HasColumnName("PerfilCampusID");
            entity.Property(e => e.CampusId)
                .HasMaxLength(50)
                .HasComment("Identificador del campus")
                .HasColumnName("CampusID");
            entity.Property(e => e.PerfilId)
                .HasComment("Identificador del perfil.")
                .HasColumnName("PerfilID");

            entity.HasOne(d => d.Campus).WithMany(p => p.PerfilCampuses)
                .HasForeignKey(d => d.CampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilCampus_Campus");

            entity.HasOne(d => d.Perfil).WithMany(p => p.PerfilCampuses)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilCampus_Perfil");
        });

        modelBuilder.Entity<PerfilVistaTipoAcceso>(entity =>
        {
            entity.HasKey(e => e.PerfilVistaTipoAccesoId).HasName("PK_PerfilVistaTipoAcceso_1");

            entity.ToTable("PerfilVistaTipoAcceso", tb => tb.HasComment("Listado de tipos de acceso acorde a las pantallas del perfil"));

            entity.Property(e => e.PerfilVistaTipoAccesoId)
                .HasComment("Identificador único de la relacion de perfil/vista y tipo acceso.")
                .HasColumnName("PerfilVistaTipoAccesoID");
            entity.Property(e => e.PerfilVistaId)
                .HasComment("Identificador de la vistas acorde al perfil.")
                .HasColumnName("PerfilVistaID");
            entity.Property(e => e.TipoAccesoId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Identificador del tipo de acceso.");

            entity.HasOne(d => d.PerfilVista).WithMany(p => p.PerfilVistaTipoAccesos)
                .HasForeignKey(d => d.PerfilVistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilVistaTipoAcceso_PerfilVista");

            entity.HasOne(d => d.TipoAcceso).WithMany(p => p.PerfilVistaTipoAccesos)
                .HasForeignKey(d => d.TipoAccesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilVistaTipoAcceso_TipoAcceso");
        });

        modelBuilder.Entity<PerfilVistum>(entity =>
        {
            entity.HasKey(e => e.PerfilVistaId).HasName("PK_PerfilVistaTipoAcceso");

            entity.ToTable(tb => tb.HasComment("Asociación entre perfil, vista y tipo de acceso."));

            entity.Property(e => e.PerfilVistaId)
                .HasComment("Identificador único del tipo de acceso asociado a la vista y perfil.")
                .HasColumnName("PerfilVistaID");
            entity.Property(e => e.PerfilId)
                .HasComment("Identificador del perfil.")
                .HasColumnName("PerfilID");
            entity.Property(e => e.VistaId)
                .HasMaxLength(50)
                .HasComment("Identificador de la vista.")
                .HasColumnName("VistaID");

            entity.HasOne(d => d.Perfil).WithMany(p => p.PerfilVista)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilVistaTipoAcceso_Perfil");

            entity.HasOne(d => d.Vista).WithMany(p => p.PerfilVista)
                .HasForeignKey(d => d.VistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilVistaTipoAcceso_Vista");
        });

        modelBuilder.Entity<PeriodoEvaluacion>(entity =>
        {
            entity.ToTable("PeriodoEvaluacion", tb => tb.HasComment("Catálogo de periodo de evaluación."));

            entity.Property(e => e.PeriodoEvaluacionId).HasColumnName("PeriodoEvaluacionID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.AnioId).HasColumnName("AnioID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasColumnName("CicloID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFinAuditoria)
                .HasComment("Fecha fin del proceso Auditoría .")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinAutoEvaluacion)
                .HasComment("Fecha fin del proceso Autoevaluación.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinCapturaResultados)
                .HasComment("Fecha fin del proceso Captura de resultados.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinCargaEvidencia)
                .HasComment("Fecha fin del proceso Carga de evidencias.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinMeta)
                .HasComment("Fecha fin del proceso Meta.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinPlanMejora)
                .HasComment("Fecha fin del proceso Plan mejora.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinRevision)
                .HasComment("Fecha fin del proceso de Revisión.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialAuditoria)
                .HasComment("Fecha inicial del proceso Auditoría.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialAutoEvaluacion)
                .HasComment("Fecha inicial del proceso Autoevaluación.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialCapturaResultados)
                .HasComment("Fecha inicial del proceso Captura de resultados.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialCargaEvidencia)
                .HasComment("Fecha inicial del proceso Carga de evidencias.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialMeta)
                .HasComment("Fecha inicial del proceso Meta.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialPlanMejora)
                .HasComment("Fecha inicial del proceso Plan mejora.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialRevision)
                .HasComment("Fecha inicial del proceso de Revisión.")
                .HasColumnType("date");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.PeriodoEvaluacions)
                .HasForeignKey(d => d.CicloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoEvaluacion_Ciclo");
        });

        modelBuilder.Entity<Ponderacion>(entity =>
        {
            entity.ToTable("Ponderacion", tb => tb.HasComment("Catálogo de ponderaciones."));

            entity.Property(e => e.PonderacionId)
                .HasComment("Clave única de la ponderación. ")
                .HasColumnName("PonderacionID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.ComponenteId)
                .HasMaxLength(5)
                .HasColumnName("ComponenteID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelModalidadId)
                .HasMaxLength(5)
                .HasColumnName("NivelModalidadID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Componente).WithMany(p => p.Ponderacions)
                .HasForeignKey(d => d.ComponenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ponderacion_Componente");

            entity.HasOne(d => d.NivelModalidad).WithMany(p => p.Ponderacions)
                .HasForeignKey(d => d.NivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ponderacion_NivelModalidad");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__Region__ACD84443C0ED2F33");

            entity.ToTable("Region", tb => tb.HasComment("Catálogo de regiones."));

            entity.Property(e => e.RegionId)
                .HasMaxLength(50)
                .HasComment("Clave única del región. ")
                .HasColumnName("RegionID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del región.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<RegistroElementoEvaluacionArchivo>(entity =>
        {
            entity.HasKey(e => new { e.RegistroElementoEvaluacionArchivoId, e.ElementoEvaluacionId, e.ConfiguracionGeneralId, e.CicloId, e.Anio });

            entity.ToTable("RegistroElementoEvaluacionArchivo", tb => tb.HasComment("Listado de archivos registrados acorde a un elemento de evaluación."));

            entity.Property(e => e.RegistroElementoEvaluacionArchivoId)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador único del archivo registrado.");
            entity.Property(e => e.ElementoEvaluacionId).HasComment("Elemento de evaluación al que pertence este archivo.");
            entity.Property(e => e.ConfiguracionGeneralId)
                .HasComment("Configuración general que pertenece al elemento de evaluación.")
                .HasColumnName("ConfiguracionGeneralID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasComment("Identificador del Ciclo para esta configuración.")
                .HasColumnName("CicloID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Mime)
                .HasMaxLength(500)
                .HasComment("El mime type del tipo de archivo.");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(500)
                .HasComment("Nombre físico del archivo.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.RegistroElementoEvaluacionArchivos)
                .HasForeignKey(d => d.CicloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroElementoEvaluacionArchivo_Ciclo");

            entity.HasOne(d => d.ElementoEvaluacion).WithMany(p => p.RegistroElementoEvaluacionArchivos)
                .HasForeignKey(d => d.ElementoEvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroElementoEvaluacionArchivo_ElementoEvaluacion");
        });

        modelBuilder.Entity<RegistroEvidenciaArchivo>(entity =>
        {
            entity.ToTable("RegistroEvidenciaArchivo", tb => tb.HasComment("Listado de archivos registrados como evidencia."));

            entity.Property(e => e.RegistroEvidenciaArchivoId).HasColumnName("RegistroEvidenciaArchivoID");
            entity.Property(e => e.AcreditadoraProcesoId).HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CampusId)
                .HasMaxLength(50)
                .HasColumnName("CampusID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasColumnName("CriterioID");
            entity.Property(e => e.EvidenciaId).HasColumnName("EvidenciaID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Mime).HasMaxLength(500);
            entity.Property(e => e.NombreArchivo).HasMaxLength(500);
            entity.Property(e => e.RegistroEvidenciaId).HasColumnName("RegistroEvidenciaID");
            entity.Property(e => e.SubareaId)
                .HasMaxLength(50)
                .HasColumnName("SubareaID");
            entity.Property(e => e.Url).HasMaxLength(1500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.RegistroEvidencium).WithMany(p => p.RegistroEvidenciaArchivos)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CarreraId, d.CriterioId, d.EvidenciaId, d.SubareaId, d.CampusId, d.RegistroEvidenciaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidenciaArchivo_RegistroEvidencia");
        });

        modelBuilder.Entity<RegistroEvidencium>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.CarreraId, e.CriterioId, e.EvidenciaId, e.SubareaId, e.CampusId, e.RegistroEvidenciaId });

            entity.ToTable(tb => tb.HasComment("Tabla donde se generan los registros de evidencia en base los indices."));

            entity.Property(e => e.AcreditadoraProcesoId).HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasColumnName("CriterioID");
            entity.Property(e => e.EvidenciaId).HasColumnName("EvidenciaID");
            entity.Property(e => e.SubareaId)
                .HasMaxLength(50)
                .HasColumnName("SubareaID");
            entity.Property(e => e.CampusId)
                .HasMaxLength(50)
                .HasColumnName("CampusID");
            entity.Property(e => e.RegistroEvidenciaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RegistroEvidenciaID");
            entity.Property(e => e.AnioId).HasColumnName("AnioID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasColumnName("CicloID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_AcreditadoraProceso");

            entity.HasOne(d => d.Campus).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => d.CampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_Campus");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => d.CicloId)
                .HasConstraintName("FK_RegistroEvidencia_Ciclo");

            entity.HasOne(d => d.Subarea).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => d.SubareaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_Subarea");

            entity.HasOne(d => d.Criterio).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CriterioId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_Criterio");

            entity.HasOne(d => d.Evidencium).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CarreraId, d.CriterioId, d.EvidenciaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_Evidencia");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302D1E2297579");

            entity.ToTable("Rol", tb => tb.HasComment("Catálogo de roles del sistema."));

            entity.Property(e => e.RolId)
                .HasComment("Identificador único del rol.")
                .HasColumnName("RolID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Descripción)
                .HasMaxLength(500)
                .HasComment("Descripción del rol.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasComment("Nombre del rol.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasMany(d => d.Usuarios).WithMany(p => p.Rols)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRol",
                    r => r.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRol_Usuario"),
                    l => l.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRol_Rol"),
                    j =>
                    {
                        j.HasKey("RolId", "UsuarioId").HasName("PK__UsuarioR__6B90DCA865BA62BA");
                        j.ToTable("UsuarioRol", tb => tb.HasComment("Asociación entre usuarios y roles del sistema."));
                        j.IndexerProperty<int>("RolId").HasColumnName("RolID");
                        j.IndexerProperty<Guid>("UsuarioId").HasColumnName("UsuarioID");
                    });
        });

        modelBuilder.Entity<RolProceso>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.RolProcesoId });

            entity.ToTable("RolProceso", tb => tb.HasComment("Listado de Roles por Proceso."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este rol.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol para el proceso.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del rol.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
            entity.Property(e => e.VistaInicial).HasMaxLength(50);

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.RolProcesos)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProceso_AcreditadoraProceso");

            entity.HasOne(d => d.VistaInicialNavigation).WithMany(p => p.RolProcesos)
                .HasForeignKey(d => d.VistaInicial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProceso_Vista");

            entity.HasMany(d => d.Vista).WithMany(p => p.RolProcesosNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "VistaRolProceso",
                    r => r.HasOne<Vistum>().WithMany()
                        .HasForeignKey("VistaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VistaRolProceso_Vista"),
                    l => l.HasOne<RolProceso>().WithMany()
                        .HasForeignKey("AcreditadoraProcesoId", "RolProcesoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VistaRolProceso_RolProceso"),
                    j =>
                    {
                        j.HasKey("AcreditadoraProcesoId", "RolProcesoId", "VistaId");
                        j.ToTable("VistaRolProceso", tb => tb.HasComment("Asociación entre vistas y roles."));
                        j.IndexerProperty<int>("AcreditadoraProcesoId")
                            .HasComment("Identificador del proceso al que pertenece este rol.")
                            .HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("RolProcesoId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del rol para el proceso.")
                            .HasColumnName("RolProcesoID");
                        j.IndexerProperty<string>("VistaId")
                            .HasMaxLength(50)
                            .HasColumnName("VistaID");
                    });
        });

        modelBuilder.Entity<RolProcesoVistaTipoAcceso>(entity =>
        {
            entity.HasKey(e => e.RolProcesoVistaTipoAccesoId).HasName("PK_RolVistaTipoAcceso");

            entity.ToTable("RolProcesoVistaTipoAcceso", tb => tb.HasComment("Asociación entre rol, vista y tipo de acceso."));

            entity.Property(e => e.RolProcesoVistaTipoAccesoId).HasColumnName("RolProcesoVistaTipoAccesoID");
            entity.Property(e => e.RolProcesoVistaId).HasColumnName("RolProcesoVistaID");
            entity.Property(e => e.TipoAccesoId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TipoAccesoID");

            entity.HasOne(d => d.RolProcesoVista).WithMany(p => p.RolProcesoVistaTipoAccesos)
                .HasForeignKey(d => d.RolProcesoVistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProcesoVistaTipoAcceso_RolProcesoVista");

            entity.HasOne(d => d.TipoAcceso).WithMany(p => p.RolProcesoVistaTipoAccesos)
                .HasForeignKey(d => d.TipoAccesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProcesoVistaTipoAcceso_TipoAcceso");
        });

        modelBuilder.Entity<RolProcesoVistum>(entity =>
        {
            entity.HasKey(e => e.RolProcesoVistaId);

            entity.ToTable(tb => tb.HasComment("Listado de Vistas por Rol."));

            entity.Property(e => e.RolProcesoVistaId)
                .HasComment("Identificador único de la relación rol y vista.")
                .HasColumnName("RolProcesoVistaID");
            entity.Property(e => e.AcreditadoraProcesoId).HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.VistaId)
                .HasMaxLength(50)
                .HasComment("Identificador de la vista.")
                .HasColumnName("VistaID");

            entity.HasOne(d => d.Vista).WithMany(p => p.RolProcesoVista)
                .HasForeignKey(d => d.VistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProcesoVista_Vista");

            entity.HasOne(d => d.RolProceso).WithMany(p => p.RolProcesoVista)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.RolProcesoId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProcesoVista_RolProceso");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.SedeId).HasName("PK__Sede__FD76DFFB0C43FF99");

            entity.ToTable("Sede", tb => tb.HasComment("Catálogo de sedes."));

            entity.Property(e => e.SedeId)
                .HasMaxLength(50)
                .HasComment("Clave única de la sede. ")
                .HasColumnName("SedeID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre de la sede.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<SubIndicadorUvm>(entity =>
        {
            entity.ToTable("SubIndicadorUvm");

            entity.Property(e => e.SubIndicadorUvmId)
                .HasComment("Clave única del subindicador uvm.")
                .HasColumnName("SubIndicadorUvmID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreSubIndicadorUvm)
                .HasMaxLength(200)
                .HasComment("Nombre del subindicador uvm.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<Subarea>(entity =>
        {
            entity.HasKey(e => e.SubareaId).HasName("PK__Subarea__FCB946D3BC0D3B72");

            entity.ToTable("Subarea", tb => tb.HasComment("Catálogo de subareas."));

            entity.Property(e => e.SubareaId)
                .HasMaxLength(50)
                .HasComment("Clave única de la subarea. ")
                .HasColumnName("SubareaID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelAtencionId)
                .HasMaxLength(50)
                .HasComment("Nivel de atención al que pertence esta subarea.")
                .HasColumnName("NivelAtencionID");
            entity.Property(e => e.NivelOrganizacionalId)
                .HasMaxLength(50)
                .HasComment("Nivel organizacional al que pertence esta subarea.")
                .HasColumnName("NivelOrganizacionalID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre de la subarea.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.NivelAtencion).WithMany(p => p.Subareas)
                .HasForeignKey(d => d.NivelAtencionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subarea_NivelAtencion");

            entity.HasOne(d => d.NivelOrganizacional).WithMany(p => p.Subareas)
                .HasForeignKey(d => d.NivelOrganizacionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subarea_NivelOrganizacional");
        });

        modelBuilder.Entity<TipoAcceso>(entity =>
        {
            entity.ToTable("TipoAcceso", tb => tb.HasComment("Catálogo de Tipo de Acceso."));

            entity.Property(e => e.TipoAccesoId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Clave única del tipo de acceso. ")
                .HasColumnName("TipoAccesoID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasComment("Descripción del tipo de acceso.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasComment("Nombre del tipo de acceso.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<TipoEvidencium>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.TipoEvidenciaId });

            entity.Property(e => e.AcreditadoraProcesoId).HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.TipoEvidenciaId)
                .HasMaxLength(50)
                .HasColumnName("TipoEvidenciaID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.RegionId)
                .HasMaxLength(50)
                .HasColumnName("RegionID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.TipoEvidencia)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoEvidencia_AcreditadoraProces");

            entity.HasOne(d => d.Region).WithMany(p => p.TipoEvidencia)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoEvidencia_Region");
        });

        modelBuilder.Entity<TmpMsXxTipoEvidencium>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.TipoEvidenciaId }).HasName("tmp_ms_xx_constraint_PK_TipoEvidencia1");

            entity.ToTable("tmp_ms_xx_TipoEvidencia");

            entity.Property(e => e.AcreditadoraProcesoId).HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.TipoEvidenciaId)
                .HasMaxLength(50)
                .HasColumnName("TipoEvidenciaID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.RegionId)
                .HasMaxLength(50)
                .HasColumnName("RegionID");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE79864F285C2");

            entity.ToTable("Usuario", tb => tb.HasComment("Listado de usaurios del sistema."));

            entity.HasIndex(e => e.Correo, "IX_Usuario_Correo").IsUnique();

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasComment("Identificador único del usuario en el directorio activo.")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .HasComment("Apellido paterno del usaurio.");
            entity.Property(e => e.Correo)
                .HasMaxLength(500)
                .HasComment("Correo electrónico del usuario.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre(s) del usuario.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<UsuarioRolProceso>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.AcreditadoraProcesoId, e.RolProcesoId, e.CarreraId });

            entity.ToTable("UsuarioRolProceso", tb => tb.HasComment("Asociación entre usuarios y roles por proceso."));

            entity.Property(e => e.UsuarioId)
                .HasComment("Identificador del usuario.")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso de acreditación.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol asociado.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que creó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación del registro.");

            entity.HasOne(d => d.Carrera).WithMany(p => p.UsuarioRolProcesos)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProceso_Carrera");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRolProcesos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProceso_Usuario");

            entity.HasOne(d => d.RolProceso).WithMany(p => p.UsuarioRolProcesos)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.RolProcesoId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProceso_RolProceso");

            entity.HasMany(d => d.Campuses).WithMany(p => p.UsuarioRolProcesos)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRolProcesoCampus",
                    r => r.HasOne<Campus>().WithMany()
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRolProcesoCampus_Campus"),
                    l => l.HasOne<UsuarioRolProceso>().WithMany()
                        .HasForeignKey("UsuarioId", "AcreditadoraProcesoId", "RolProcesoId", "CarreraId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRolProcesoCampus_UsuarioRolProceso"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "AcreditadoraProcesoId", "RolProcesoId", "CarreraId", "CampusId");
                        j.ToTable("UsuarioRolProcesoCampus", tb => tb.HasComment("Asociación entre usuario, rol y campus."));
                        j.IndexerProperty<Guid>("UsuarioId")
                            .HasComment("Identificador del usuario.")
                            .HasColumnName("UsuarioID");
                        j.IndexerProperty<int>("AcreditadoraProcesoId")
                            .HasComment("Identificador del proceso de acreditación.")
                            .HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("RolProcesoId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del rol asociado.")
                            .HasColumnName("RolProcesoID");
                        j.IndexerProperty<string>("CarreraId")
                            .HasMaxLength(50)
                            .HasColumnName("CarreraID");
                        j.IndexerProperty<string>("CampusId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del campus.")
                            .HasColumnName("CampusID");
                    });
        });

        modelBuilder.Entity<UsuarioRolProcesoCapitulo>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.AcreditadoraProcesoId, e.RolProcesoId, e.CarreraId, e.CapituloId });

            entity.ToTable("UsuarioRolProcesoCapitulo", tb => tb.HasComment("Asociación entre usaurio, rol y captíulos."));

            entity.Property(e => e.UsuarioId)
                .HasComment("Identificador del usuario.")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso de acreditación.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol asociado.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.CapituloId)
                .HasMaxLength(50)
                .HasComment("Identificador del capitulo.")
                .HasColumnName("CapituloID");

            entity.HasOne(d => d.Capitulo).WithMany(p => p.UsuarioRolProcesoCapitulos)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CapituloId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProcesoCapitulo_Capitulo");

            entity.HasOne(d => d.UsuarioRolProceso).WithMany(p => p.UsuarioRolProcesoCapitulos)
                .HasForeignKey(d => new { d.UsuarioId, d.AcreditadoraProcesoId, d.RolProcesoId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProcesoCapitulo_UsuarioRolProceso");
        });

        modelBuilder.Entity<UsuarioRolProcesoCriterio>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.AcreditadoraProcesoId, e.RolProcesoId, e.CarreraId, e.CriterioId });

            entity.ToTable("UsuarioRolProcesoCriterio", tb => tb.HasComment("Asociación entre usaurio, rol y captíulos."));

            entity.Property(e => e.UsuarioId)
                .HasComment("Identificador del usuario.")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso de acreditación.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol asociado.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Identificador del criterio")
                .HasColumnName("CriterioID");

            entity.HasOne(d => d.Criterio).WithMany(p => p.UsuarioRolProcesoCriterios)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CriterioId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProcesoCriterio_Criterio");

            entity.HasOne(d => d.UsuarioRolProceso).WithMany(p => p.UsuarioRolProcesoCriterios)
                .HasForeignKey(d => new { d.UsuarioId, d.AcreditadoraProcesoId, d.RolProcesoId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProcesoCriterio_UsuarioRolProceso");
        });

        modelBuilder.Entity<Vistum>(entity =>
        {
            entity.HasKey(e => e.VistaId);

            entity.ToTable(tb => tb.HasComment("Listado de vistas existentes en la plataforma."));

            entity.Property(e => e.VistaId)
                .HasMaxLength(50)
                .HasComment("Identificador interno de la vista.")
                .HasColumnName("VistaID");
            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre público de la vista.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
