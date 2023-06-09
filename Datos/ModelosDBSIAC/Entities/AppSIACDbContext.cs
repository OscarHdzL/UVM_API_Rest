﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Datos.ModelosDBSIAC.Entities;

public partial class AppSIACDbContext : DbContext
{
    public AppSIACDbContext()
    {
    }

    public AppSIACDbContext(DbContextOptions<AppSIACDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcreditadoraProceso> AcreditadoraProcesos { get; set; }

    public virtual DbSet<AzureStorageFile> AzureStorageFiles { get; set; }

    public virtual DbSet<Capitulo> Capitulos { get; set; }

    public virtual DbSet<CatAcreditadora> CatAcreditadoras { get; set; }

    public virtual DbSet<CatAreaCorporativa> CatAreaCorporativas { get; set; }

    public virtual DbSet<CatAreaResponsable> CatAreaResponsables { get; set; }

    public virtual DbSet<CatCampus> CatCampuses { get; set; }

    public virtual DbSet<CatCapitulo> CatCapitulos { get; set; }

    public virtual DbSet<CatComponente> CatComponentes { get; set; }

    public virtual DbSet<CatDependenciaArea> CatDependenciaAreas { get; set; }

    public virtual DbSet<CatElementoEvaluacion> CatElementoEvaluacions { get; set; }

    public virtual DbSet<CatEscalaMedicion> CatEscalaMedicions { get; set; }

    public virtual DbSet<CatEtapa> CatEtapas { get; set; }

    public virtual DbSet<CatEvidencium> CatEvidencia { get; set; }

    public virtual DbSet<CatIndicadorSiac> CatIndicadorSiacs { get; set; }

    public virtual DbSet<CatInstitucion> CatInstitucions { get; set; }

    public virtual DbSet<CatMatrizUvm> CatMatrizUvms { get; set; }

    public virtual DbSet<CatNivelModalidad> CatNivelModalidads { get; set; }

    public virtual DbSet<CatNivelRevision> CatNivelRevisions { get; set; }

    public virtual DbSet<CatNormativa> CatNormativas { get; set; }

    public virtual DbSet<CatPeriodo> CatPeriodos { get; set; }

    public virtual DbSet<CatPeriodoEvaluacion> CatPeriodoEvaluacions { get; set; }

    public virtual DbSet<CatPonderacion> CatPonderacions { get; set; }

    public virtual DbSet<CatRegion> CatRegions { get; set; }

    public virtual DbSet<CatSede> CatSedes { get; set; }

    public virtual DbSet<CatSubAreaCorporativa> CatSubAreaCorporativas { get; set; }

    public virtual DbSet<CatTipoAcceso> CatTipoAccesos { get; set; }

    public virtual DbSet<CatTipoVistum> CatTipoVista { get; set; }

    public virtual DbSet<CatUsuario> CatUsuarios { get; set; }

    public virtual DbSet<CatVistum> CatVista { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<ComponenteUvm> ComponenteUvms { get; set; }

    public virtual DbSet<ConfElementoEvaluacion> ConfElementoEvaluacions { get; set; }

    public virtual DbSet<ConfEscalaMedicion> ConfEscalaMedicions { get; set; }

    public virtual DbSet<ConfIndicadorSiac> ConfIndicadorSiacs { get; set; }

    public virtual DbSet<ConfiguracionBienvenidum> ConfiguracionBienvenida { get; set; }

    public virtual DbSet<IndicadorUvm> IndicadorUvms { get; set; }

    public virtual DbSet<RelAreacorporativasubarea> RelAreacorporativasubareas { get; set; }

    public virtual DbSet<RelAreacorporativasubarea1> RelAreacorporativasubareas1 { get; set; }

    public virtual DbSet<RelArearesponsablenivelmodalidad> RelArearesponsablenivelmodalidads { get; set; }

    public virtual DbSet<RelCampusnivelmodalidad> RelCampusnivelmodalidads { get; set; }

    public virtual DbSet<RelConfelementoevaluacionfile> RelConfelementoevaluacionfiles { get; set; }

    public virtual DbSet<RelConfindicadorsiacfile> RelConfindicadorsiacfiles { get; set; }

    public virtual DbSet<RelEscalamedicioncondicion> RelEscalamedicioncondicions { get; set; }

    public virtual DbSet<RelEtapaPeriodoEvaluacion> RelEtapaPeriodoEvaluacions { get; set; }

    public virtual DbSet<RelPerfilvistatipoacceso> RelPerfilvistatipoaccesos { get; set; }

    public virtual DbSet<RelPerfilvistum> RelPerfilvista { get; set; }

    public virtual DbSet<RelUsuarioareacorporativa> RelUsuarioareacorporativas { get; set; }

    public virtual DbSet<RelUsuarioarearesponsable> RelUsuarioarearesponsables { get; set; }

    public virtual DbSet<RelUsuariocampus> RelUsuariocampuses { get; set; }

    public virtual DbSet<RelUsuarionivelmodalidad> RelUsuarionivelmodalidads { get; set; }

    public virtual DbSet<RelUsuarioregion> RelUsuarioregions { get; set; }

    public virtual DbSet<SubIndicadorUvm> SubIndicadorUvms { get; set; }

    public virtual DbSet<TblPerfil> TblPerfils { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VwAreaCorporativaSubarea> VwAreaCorporativaSubareas { get; set; }

    public virtual DbSet<VwAreaResponsableNivelModalidad> VwAreaResponsableNivelModalidads { get; set; }

    public virtual DbSet<VwAzureStorageFile> VwAzureStorageFiles { get; set; }

    public virtual DbSet<VwCampusNivelModalidad> VwCampusNivelModalidads { get; set; }

    public virtual DbSet<VwCatAreaCorporativa> VwCatAreaCorporativas { get; set; }

    public virtual DbSet<VwCatAreaResponsable> VwCatAreaResponsables { get; set; }

    public virtual DbSet<VwCatCampus> VwCatCampuses { get; set; }

    public virtual DbSet<VwCatCiclo> VwCatCiclos { get; set; }

    public virtual DbSet<VwCatDependenciaArea> VwCatDependenciaAreas { get; set; }

    public virtual DbSet<VwCatEscalaMedicion> VwCatEscalaMedicions { get; set; }

    public virtual DbSet<VwCatEtapa> VwCatEtapas { get; set; }

    public virtual DbSet<VwCatEvidencium> VwCatEvidencia { get; set; }

    public virtual DbSet<VwCatIndicadorSiac> VwCatIndicadorSiacs { get; set; }

    public virtual DbSet<VwCatInstitucion> VwCatInstitucions { get; set; }

    public virtual DbSet<VwCatMatrizUvm> VwCatMatrizUvms { get; set; }

    public virtual DbSet<VwCatNivelModalidad> VwCatNivelModalidads { get; set; }

    public virtual DbSet<VwCatPeriodoEvaluacion> VwCatPeriodoEvaluacions { get; set; }

    public virtual DbSet<VwCatPeriodoEvaluacionBase> VwCatPeriodoEvaluacionBases { get; set; }

    public virtual DbSet<VwCatPonderacion> VwCatPonderacions { get; set; }

    public virtual DbSet<VwCatRegion> VwCatRegions { get; set; }

    public virtual DbSet<VwCatSubAreaCorporativa> VwCatSubAreaCorporativas { get; set; }

    public virtual DbSet<VwCatTipoAcceso> VwCatTipoAccesos { get; set; }

    public virtual DbSet<VwComponenteUvm> VwComponenteUvms { get; set; }

    public virtual DbSet<VwConfElementoEvaluacion> VwConfElementoEvaluacions { get; set; }

    public virtual DbSet<VwConfElementoEvaluacionFile> VwConfElementoEvaluacionFiles { get; set; }

    public virtual DbSet<VwConfEscalaMedicionBase> VwConfEscalaMedicionBases { get; set; }

    public virtual DbSet<VwConfIndicadorSiac> VwConfIndicadorSiacs { get; set; }

    public virtual DbSet<VwConfIndicadorSiacFile> VwConfIndicadorSiacFiles { get; set; }

    public virtual DbSet<VwEscalaMedicionCondicion> VwEscalaMedicionCondicions { get; set; }

    public virtual DbSet<VwEscalaMedicionCondicionExcel> VwEscalaMedicionCondicionExcels { get; set; }

    public virtual DbSet<VwIndicadorUvm> VwIndicadorUvms { get; set; }

    public virtual DbSet<VwPerfilBase> VwPerfilBases { get; set; }

    public virtual DbSet<VwSubIndicadorUvm> VwSubIndicadorUvms { get; set; }

    public virtual DbSet<VwUsuario> VwUsuarios { get; set; }

    public virtual DbSet<VwUsuarioAreaCorporativa> VwUsuarioAreaCorporativas { get; set; }

    public virtual DbSet<VwUsuarioAreaResponsable> VwUsuarioAreaResponsables { get; set; }

    public virtual DbSet<VwUsuarioBase> VwUsuarioBases { get; set; }

    public virtual DbSet<VwUsuarioCampus> VwUsuarioCampuses { get; set; }

    public virtual DbSet<VwUsuarioNivelModalidad> VwUsuarioNivelModalidads { get; set; }

    public virtual DbSet<VwUsuarioRegion> VwUsuarioRegions { get; set; }

    public virtual DbSet<VwUsuariosSidebar> VwUsuariosSidebars { get; set; }

    public virtual DbSet<VwVistasPerfil> VwVistasPerfils { get; set; }

    public virtual DbSet<VwVistum> VwVista { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile("appsettings.json", optional: false).Build();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LibroFimpes"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcreditadoraProceso>(entity =>
        {
            entity.ToTable("AcreditadoraProceso");

            entity.Property(e => e.Nombre).HasMaxLength(500);
        });

        modelBuilder.Entity<AzureStorageFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AzureSto__3214EC075F344D0D");

            entity.ToTable("AzureStorageFile");

            entity.Property(e => e.ContentType).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Url).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
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

        modelBuilder.Entity<CatAcreditadora>(entity =>
        {
            entity.ToTable("cat_Acreditadora", tb => tb.HasComment("Listado de Acreditadoras"));

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

        modelBuilder.Entity<CatAreaCorporativa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AreaCorporativa");

            entity.ToTable("cat_AreaCorporativa", tb => tb.HasComment("Catálogo de la área corporativa."));

            entity.Property(e => e.Id).HasComment("Clave única de la área corporativa.");
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
            entity.Property(e => e.Siglas).HasMaxLength(5);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<CatAreaResponsable>(entity =>
        {
            entity.ToTable("cat_AreaResponsable");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.AreaResponsablePadreNavigation).WithMany(p => p.InverseAreaResponsablePadreNavigation)
                .HasForeignKey(d => d.AreaResponsablePadre)
                .HasConstraintName("FK_AreaResponsable_AreaResponsable1");
        });

        modelBuilder.Entity<CatCampus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Camp__3214EC072A5611D5");

            entity.ToTable("cat_Campus", tb => tb.HasComment("Catálogo de campus."));

            entity.Property(e => e.Id).HasComment("Clave única del campus. ");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Clave)
                .HasMaxLength(5)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del campus.");
            entity.Property(e => e.RegionId).HasComment("Región a la que pertenece este campus.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Region).WithMany(p => p.CatCampuses)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_cat_Campus_cat_Region");
        });

        modelBuilder.Entity<CatCapitulo>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.Id });

            entity.ToTable("cat_Capitulo", tb => tb.HasComment("Listado de cápitulos."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este cápitulo.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasComment("Número del cápitulo dentro del proceso.");
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

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.CatCapitulos)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cat_Capitulo_AcreditadoraProceso");
        });

        modelBuilder.Entity<CatComponente>(entity =>
        {
            entity.ToTable("cat_Componente");

            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatDependenciaArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Depe__3214EC07D7C5C3B4");

            entity.ToTable("cat_DependenciaArea");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<CatElementoEvaluacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Elem__3214EC0738FFEDBE");

            entity.ToTable("cat_ElementoEvaluacion");

            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatEscalaMedicion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Esca__3214EC0764770F32");

            entity.ToTable("cat_EscalaMedicion");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Escala).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatEtapa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Etap__3214EC073A8AE7D5");

            entity.ToTable("cat_Etapa");

            entity.Property(e => e.Etapa).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<CatEvidencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Evid__3214EC07586F5970");

            entity.ToTable("cat_Evidencia");

            entity.Property(e => e.Clave).HasMaxLength(10);
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatIndicadorSiac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Indi__3214EC0770D48EEB");

            entity.ToTable("cat_IndicadorSIAC");

            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatInstitucion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Inst__3214EC0712F68539");

            entity.ToTable("cat_Institucion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Institucion).HasMaxLength(200);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<CatMatrizUvm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cat_MatrizUvm");

            entity.ToTable("cat_MatrizUvm");

            entity.Property(e => e.Id).HasComment("Indentificador unico de matriz uvm");
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

            entity.HasOne(d => d.ComponenteUvm).WithMany(p => p.CatMatrizUvms)
                .HasForeignKey(d => d.ComponenteUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cat_MatrizUvm_ComponenteUvm");
        });

        modelBuilder.Entity<CatNivelModalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NivelModalidad");

            entity.ToTable("cat_NivelModalidad", tb => tb.HasComment("Listado de Nivel/Modalidad"));

            entity.HasIndex(e => e.Id, "PK__NivelModalidad").IsUnique();

            entity.Property(e => e.Id).HasComment("Siglas de identificación única para la Nivel/Modalidad.");
            entity.Property(e => e.Activo).HasComment("Indicador de activo/inactivo para el registro.");
            entity.Property(e => e.Clave)
                .HasMaxLength(5)
                .HasDefaultValueSql("('')");
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

        modelBuilder.Entity<CatNivelRevision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Nive__3214EC0757F8CD3A");

            entity.ToTable("cat_NivelRevision");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatNormativa>(entity =>
        {
            entity.ToTable("cat_Normativa");

            entity.Property(e => e.Clave).HasMaxLength(10);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatPeriodo>(entity =>
        {
            entity.ToTable("cat_Periodo");

            entity.Property(e => e.Etapa).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatPeriodoEvaluacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Peri__3214EC07B727E86D");

            entity.ToTable("cat_PeriodoEvaluacion");

            entity.Property(e => e.CicloId).HasColumnName("CicloID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Proceso).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.CatInstitucion).WithMany(p => p.CatPeriodoEvaluacions)
                .HasForeignKey(d => d.CatInstitucionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cat_Perio__CatIn__2C88998B");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.CatPeriodoEvaluacions)
                .HasForeignKey(d => d.CicloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cat_Perio__Ciclo__2B947552");
        });

        modelBuilder.Entity<CatPonderacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Pond__3214EC077A593D85");

            entity.ToTable("cat_Ponderacion");

            entity.Property(e => e.ComponenteId).HasColumnName("Componente_Id");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NivelModalidadId).HasColumnName("NivelModalidad_Id");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Componente).WithMany(p => p.CatPonderacions)
                .HasForeignKey(d => d.ComponenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cat_Ponderacion_cat_Componente");

            entity.HasOne(d => d.NivelModalidad).WithMany(p => p.CatPonderacions)
                .HasForeignKey(d => d.NivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cat_Ponderacion_cat_NivelModalidad");
        });

        modelBuilder.Entity<CatRegion>(entity =>
        {
            entity.ToTable("cat_Region", tb => tb.HasComment("Catálogo de regiones."));

            entity.Property(e => e.Id).HasComment("Clave única del región. ");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Clave)
                .HasMaxLength(5)
                .HasDefaultValueSql("('')");
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

            entity.HasOne(d => d.UsuarioDirectorRegional).WithMany(p => p.CatRegions)
                .HasForeignKey(d => d.UsuarioDirectorRegionalId)
                .HasConstraintName("FK__cat_Regio__Usuar__45544755");
        });

        modelBuilder.Entity<CatSede>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Sede__3214EC07B3E1B397");

            entity.ToTable("cat_Sede", tb => tb.HasComment("Catálogo de sedes."));

            entity.Property(e => e.Id).HasComment("Clave única de la sede. ");
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

        modelBuilder.Entity<CatSubAreaCorporativa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_SubA__3214EC0781E52A88");

            entity.ToTable("cat_SubAreaCorporativa");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Siglas).HasMaxLength(5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatTipoAcceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cat_Tipo__3214EC0735A7F38E");

            entity.ToTable("Cat_TipoAcceso");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatTipoVistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cat_Tipo__3214EC07680A7D5A");

            entity.ToTable("Cat_TipoVista");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__2B3DE798895CF517");

            entity.ToTable("cat_Usuario", tb => tb.HasComment("Listado de usaurios del sistema."));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Identificador único del usuario en el directorio activo.");
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
            entity.Property(e => e.PerfilId).HasColumnName("PerfilID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Perfil).WithMany(p => p.CatUsuarios)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Perfil");
        });

        modelBuilder.Entity<CatVistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cat_Vist__3214EC07FDCA5691");

            entity.ToTable("Cat_Vista");

            entity.Property(e => e.CatTipoVistaId).HasDefaultValueSql("((1))");
            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.CatTipoVista).WithMany(p => p.CatVista)
                .HasForeignKey(d => d.CatTipoVistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cat_Vista__CatTi__16CE6296");
        });

        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ciclo__3214EC072F809D3D");

            entity.ToTable("Ciclo");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<ComponenteUvm>(entity =>
        {
            entity.ToTable("ComponenteUvm");

            entity.Property(e => e.Id).HasComment("Clave única del componente uvm.");
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

        modelBuilder.Entity<ConfElementoEvaluacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__conf_Ele__3214EC07140287D5");

            entity.ToTable("conf_ElementoEvaluacion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.CatAreaCorporativa).WithMany(p => p.ConfElementoEvaluacions)
                .HasForeignKey(d => d.CatAreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Elem__CatAr__75035A77");

            entity.HasOne(d => d.CatAreaResponsable).WithMany(p => p.ConfElementoEvaluacions)
                .HasForeignKey(d => d.CatAreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Elem__CatAr__7132C993");

            entity.HasOne(d => d.CatComponente).WithMany(p => p.ConfElementoEvaluacions)
                .HasForeignKey(d => d.CatComponenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Elem__CatCo__731B1205");

            entity.HasOne(d => d.CatElementoEvaluacion).WithMany(p => p.ConfElementoEvaluacions)
                .HasForeignKey(d => d.CatElementoEvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Elem__CatEl__740F363E");

            entity.HasOne(d => d.CatNivelModalidad).WithMany(p => p.ConfElementoEvaluacions)
                .HasForeignKey(d => d.CatNivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Elem__CatNi__7226EDCC");

            entity.HasOne(d => d.CatPeriodoEvaluacion).WithMany(p => p.ConfElementoEvaluacions)
                .HasForeignKey(d => d.CatPeriodoEvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Elem__Usuar__703EA55A");

            entity.HasOne(d => d.CatSubAreaCorporativa).WithMany(p => p.ConfElementoEvaluacions)
                .HasForeignKey(d => d.CatSubAreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Elem__CatSu__7A8729A3");
        });

        modelBuilder.Entity<ConfEscalaMedicion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__conf_Esc__3214EC07EBD9DF21");

            entity.ToTable("conf_EscalaMedicion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.ConfIndicadorSiac).WithMany(p => p.ConfEscalaMedicions)
                .HasForeignKey(d => d.ConfIndicadorSiacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Esca__Usuar__0169315C");
        });

        modelBuilder.Entity<ConfIndicadorSiac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__conf_Ind__3214EC07FDB03AD1");

            entity.ToTable("conf_IndicadorSIAC");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.CatEvidencia).WithMany(p => p.ConfIndicadorSiacs)
                .HasForeignKey(d => d.CatEvidenciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Indi__CatEv__5C02A283");

            entity.HasOne(d => d.CatIndicadorSiac).WithMany(p => p.ConfIndicadorSiacs)
                .HasForeignKey(d => d.CatIndicadorSiacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Indi__CatIn__79C80F94");

            entity.HasOne(d => d.CatNormativa).WithMany(p => p.ConfIndicadorSiacs)
                .HasForeignKey(d => d.CatNormativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Indi__CatNo__5A1A5A11");

            entity.HasOne(d => d.ComponenteUvm).WithMany(p => p.ConfIndicadorSiacs)
                .HasForeignKey(d => d.ComponenteUvmId)
                .HasConstraintName("FK__conf_Indi__Compo__7ABC33CD");

            entity.HasOne(d => d.ConfElementoEvaluacion).WithMany(p => p.ConfIndicadorSiacs)
                .HasForeignKey(d => d.ConfElementoEvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__conf_Indi__Usuar__78D3EB5B");

            entity.HasOne(d => d.IndicadorUvm).WithMany(p => p.ConfIndicadorSiacs)
                .HasForeignKey(d => d.IndicadorUvmId)
                .HasConstraintName("FK__conf_Indi__Indic__7BB05806");

            entity.HasOne(d => d.SubindicadorUvm).WithMany(p => p.ConfIndicadorSiacs)
                .HasForeignKey(d => d.SubindicadorUvmId)
                .HasConstraintName("FK__conf_Indi__Subin__7CA47C3F");
        });

        modelBuilder.Entity<ConfiguracionBienvenidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC0768496D98");

            entity.ToTable("Configuracion_Bienvenida");

            entity.Property(e => e.HtmlBienvenida).HasColumnType("text");
        });

        modelBuilder.Entity<IndicadorUvm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Indicado__3214EC0787905E63");

            entity.ToTable("IndicadorUvm");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.ComponenteUvm).WithMany(p => p.IndicadorUvms)
                .HasForeignKey(d => d.ComponenteUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Indicador__Usuar__7FB5F314");
        });

        modelBuilder.Entity<RelAreacorporativasubarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_area__3214EC071BAA72D1");

            entity.ToTable("rel_areacorporativasubarea");

            entity.HasOne(d => d.CatAreaCorporativa).WithMany(p => p.RelAreacorporativasubareas)
                .HasForeignKey(d => d.CatAreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_areac__CatSu__320C68B7");

            entity.HasOne(d => d.CatSubAreaCorporativa).WithMany(p => p.RelAreacorporativasubareas)
                .HasForeignKey(d => d.CatSubAreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_areac__CatSu__33008CF0");
        });

        modelBuilder.Entity<RelAreacorporativasubarea1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_area__3214EC070610C0F1");

            entity.ToTable("rel_areacorporativasubareas");

            entity.Property(e => e.Subarea).HasMaxLength(150);

            entity.HasOne(d => d.CatAreaCorporativa).WithMany(p => p.RelAreacorporativasubarea1s)
                .HasForeignKey(d => d.CatAreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_areac__CatAr__63D8CE75");
        });

        modelBuilder.Entity<RelArearesponsablenivelmodalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_area__3214EC073E81A0E6");

            entity.ToTable("rel_arearesponsablenivelmodalidad");

            entity.HasOne(d => d.CatAreaResponsable).WithMany(p => p.RelArearesponsablenivelmodalidads)
                .HasForeignKey(d => d.CatAreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_arear__CatAr__5B438874");

            entity.HasOne(d => d.CatNivelModalidad).WithMany(p => p.RelArearesponsablenivelmodalidads)
                .HasForeignKey(d => d.CatNivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_arear__CatNi__5C37ACAD");
        });

        modelBuilder.Entity<RelCampusnivelmodalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_camp__3214EC0760833CF4");

            entity.ToTable("rel_campusnivelmodalidad");

            entity.HasOne(d => d.CatCampus).WithMany(p => p.RelCampusnivelmodalidads)
                .HasForeignKey(d => d.CatCampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_campu__CatNi__4FD1D5C8");

            entity.HasOne(d => d.CatNivelModalidad).WithMany(p => p.RelCampusnivelmodalidads)
                .HasForeignKey(d => d.CatNivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_campu__CatNi__50C5FA01");
        });

        modelBuilder.Entity<RelConfelementoevaluacionfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_conf__3214EC07A2797613");

            entity.ToTable("rel_confelementoevaluacionfile");

            entity.HasOne(d => d.AzureStorageFile).WithMany(p => p.RelConfelementoevaluacionfiles)
                .HasForeignKey(d => d.AzureStorageFileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_confe__Azure__4336F4B9");

            entity.HasOne(d => d.ConfElementoEvaluacion).WithMany(p => p.RelConfelementoevaluacionfiles)
                .HasForeignKey(d => d.ConfElementoEvaluacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_confe__Azure__4242D080");
        });

        modelBuilder.Entity<RelConfindicadorsiacfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_conf__3214EC07B24A916D");

            entity.ToTable("rel_confindicadorsiacfile");
        });

        modelBuilder.Entity<RelEscalamedicioncondicion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_esca__3214EC07B02A9BFF");

            entity.ToTable("rel_escalamedicioncondicion");

            entity.Property(e => e.Condicion).HasMaxLength(2000);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.CatEscalaMedicion).WithMany(p => p.RelEscalamedicioncondicions)
                .HasForeignKey(d => d.CatEscalaMedicionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_escal__CatEs__0BE6BFCF");

            entity.HasOne(d => d.ConfEscalaMedicion).WithMany(p => p.RelEscalamedicioncondicions)
                .HasForeignKey(d => d.ConfEscalaMedicionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_escal__Usuar__0AF29B96");
        });

        modelBuilder.Entity<RelEtapaPeriodoEvaluacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_Etap__3214EC07F23C6FFA");

            entity.ToTable("rel_EtapaPeriodoEvaluacion");

            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
        });

        modelBuilder.Entity<RelPerfilvistatipoacceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_perf__3214EC079C7A5463");

            entity.ToTable("rel_perfilvistatipoacceso");

            entity.HasOne(d => d.CatTipoAcceso).WithMany(p => p.RelPerfilvistatipoaccesos)
                .HasForeignKey(d => d.CatTipoAccesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__CatTi__7D0E9093");

            entity.HasOne(d => d.PerfilVista).WithMany(p => p.RelPerfilvistatipoaccesos)
                .HasForeignKey(d => d.PerfilVistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__CatTi__7C1A6C5A");
        });

        modelBuilder.Entity<RelPerfilvistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_perf__3214EC07E36B7BD2");

            entity.ToTable("rel_perfilvista");

            entity.HasOne(d => d.Perfil).WithMany(p => p.RelPerfilvista)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__Vista__6BE40491");

            entity.HasOne(d => d.Vista).WithMany(p => p.RelPerfilvista)
                .HasForeignKey(d => d.VistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__Vista__6CD828CA");
        });

        modelBuilder.Entity<RelUsuarioareacorporativa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuarioareacorporativa");

            entity.HasOne(d => d.CatAreaCorporativa).WithMany()
                .HasForeignKey(d => d.CatAreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatAr__2F9A1060");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatAr__2EA5EC27");
        });

        modelBuilder.Entity<RelUsuarioarearesponsable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuarioarearesponsable");

            entity.HasOne(d => d.CatAreaResponsable).WithMany()
                .HasForeignKey(d => d.CatAreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatAr__32767D0B");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatAr__318258D2");
        });

        modelBuilder.Entity<RelUsuariocampus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuariocampus");

            entity.HasOne(d => d.CatCampus).WithMany()
                .HasForeignKey(d => d.CatCampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatCa__29E1370A");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatCa__28ED12D1");
        });

        modelBuilder.Entity<RelUsuarionivelmodalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuarionivelmodalidad");

            entity.HasOne(d => d.CatNivelModalidad).WithMany()
                .HasForeignKey(d => d.CatNivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatNi__2CBDA3B5");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatNi__2BC97F7C");
        });

        modelBuilder.Entity<RelUsuarioregion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuarioregion");

            entity.HasOne(d => d.CatRegion).WithMany()
                .HasForeignKey(d => d.CatRegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatRe__2704CA5F");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatRe__2610A626");
        });

        modelBuilder.Entity<SubIndicadorUvm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubIndic__3214EC079DAB466F");

            entity.ToTable("SubIndicadorUvm");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreSubIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.IndicadorUvm).WithMany(p => p.SubIndicadorUvms)
                .HasForeignKey(d => d.IndicadorUvmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubIndica__Usuar__02925FBF");
        });

        modelBuilder.Entity<TblPerfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_perf__3214EC07FD1C6907");

            entity.ToTable("tbl_perfil");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC071EF477D5");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.Correo).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.CatNivelRevision).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.CatNivelRevisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__CatNive__2334397B");

            entity.HasOne(d => d.TblPerfil).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TblPerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__Usuario__22401542");
        });

        modelBuilder.Entity<VwAreaCorporativaSubarea>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AreaCorporativaSubareas");

            entity.Property(e => e.AreaCorporativa).HasMaxLength(150);
            entity.Property(e => e.Subarea).HasMaxLength(150);
        });

        modelBuilder.Entity<VwAreaResponsableNivelModalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AreaResponsableNivelModalidad");

            entity.Property(e => e.AreaResponsable).HasMaxLength(150);
            entity.Property(e => e.NivelModalidad).HasMaxLength(201);
        });

        modelBuilder.Entity<VwAzureStorageFile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AzureStorageFile");

            entity.Property(e => e.ContentType).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Url).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCampusNivelModalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CampusNivelModalidad");

            entity.Property(e => e.Campus).HasMaxLength(500);
            entity.Property(e => e.NivelModalidad).HasMaxLength(201);
        });

        modelBuilder.Entity<VwCatAreaCorporativa>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatAreaCorporativa");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Siglas).HasMaxLength(5);
            entity.Property(e => e.Subareas).HasMaxLength(4000);
            entity.Property(e => e.SubareasIds).HasMaxLength(4000);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatAreaResponsable>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatAreaResponsable");

            entity.Property(e => e.AreaResponsablePadre).HasMaxLength(150);
            entity.Property(e => e.DependenciaArea).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NivelModalidad).HasMaxLength(4000);
            entity.Property(e => e.NivelModalidadIds).HasMaxLength(4000);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatCampus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatCampus");

            entity.Property(e => e.Clave).HasMaxLength(5);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NivelModalidad).HasMaxLength(4000);
            entity.Property(e => e.NivelModalidadIds).HasMaxLength(4000);
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.Region).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatCiclo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatCiclo");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<VwCatDependenciaArea>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatDependenciaArea");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<VwCatEscalaMedicion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatEscalaMedicion");

            entity.Property(e => e.CatEsEscalaMedicionId).ValueGeneratedOnAdd();
            entity.Property(e => e.Escala).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatEtapa>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatEtapa");

            entity.Property(e => e.Etapa).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<VwCatEvidencium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatEvidencia");

            entity.Property(e => e.Clave).HasMaxLength(10);
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatIndicadorSiac>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatIndicadorSiac");

            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatInstitucion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatInstitucion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Institucion).HasMaxLength(200);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<VwCatMatrizUvm>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatMatrizUvm");

            entity.Property(e => e.ComponenteUvm).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatNivelModalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatNivelModalidad");

            entity.Property(e => e.Clave).HasMaxLength(5);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Modalidad).HasMaxLength(100);
            entity.Property(e => e.Nivel).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatPeriodoEvaluacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatPeriodoEvaluacion");

            entity.Property(e => e.Etapa).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Institucion).HasMaxLength(200);
            entity.Property(e => e.Proceso).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatPeriodoEvaluacionBase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatPeriodoEvaluacion_Base");

            entity.Property(e => e.Ciclo).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Institucion).HasMaxLength(200);
            entity.Property(e => e.Proceso).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatPonderacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatPonderacion");

            entity.Property(e => e.ComponenteId).HasColumnName("Componente_Id");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Modalidad).HasMaxLength(100);
            entity.Property(e => e.Nivel).HasMaxLength(100);
            entity.Property(e => e.NivelModalidad).HasMaxLength(201);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatRegion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatRegion");

            entity.Property(e => e.Clave).HasMaxLength(5);
            entity.Property(e => e.DirectorRegional).HasMaxLength(301);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatSubAreaCorporativa>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatSubAreaCorporativa");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Siglas).HasMaxLength(5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCatTipoAcceso>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatTipoAcceso");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwComponenteUvm>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ComponenteUvm");

            entity.Property(e => e.DescripcionComponenteUvm).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NombreComponenteUvm).HasMaxLength(200);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwConfElementoEvaluacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ConfElementoEvaluacion");

            entity.Property(e => e.AreaCorporativa).HasMaxLength(150);
            entity.Property(e => e.AreaResponsable).HasMaxLength(150);
            entity.Property(e => e.Ciclo).HasMaxLength(200);
            entity.Property(e => e.ClaveComponente).HasMaxLength(50);
            entity.Property(e => e.ClaveElementoEvaluacion).HasMaxLength(50);
            entity.Property(e => e.Componente).HasMaxLength(50);
            entity.Property(e => e.ElementoEvaluacion).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Institucion).HasMaxLength(200);
            entity.Property(e => e.NivelModalidad).HasMaxLength(201);
            entity.Property(e => e.Proceso).HasMaxLength(50);
            entity.Property(e => e.SiglasAreaCorporativa).HasMaxLength(5);
            entity.Property(e => e.SiglasSubAreaCorporativa).HasMaxLength(5);
            entity.Property(e => e.SubAreaCorporativa).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwConfElementoEvaluacionFile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ConfElementoEvaluacionFile");

            entity.Property(e => e.FileName).HasMaxLength(200);
        });

        modelBuilder.Entity<VwConfEscalaMedicionBase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ConfEscalaMedicionBase");

            entity.Property(e => e.AreaCorporativa).HasMaxLength(150);
            entity.Property(e => e.AreaResponsable).HasMaxLength(150);
            entity.Property(e => e.Ciclo).HasMaxLength(200);
            entity.Property(e => e.ClaveComponente).HasMaxLength(50);
            entity.Property(e => e.ClaveElementoEvaluacion).HasMaxLength(50);
            entity.Property(e => e.ClaveEvidencia).HasMaxLength(10);
            entity.Property(e => e.ClaveIndicadorSiac).HasMaxLength(50);
            entity.Property(e => e.ClaveNormativa).HasMaxLength(10);
            entity.Property(e => e.Componente).HasMaxLength(50);
            entity.Property(e => e.DescripcionComponenteUvm).HasMaxLength(500);
            entity.Property(e => e.DescripcionEvidencia).HasMaxLength(250);
            entity.Property(e => e.ElementoEvaluacion).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IndicadorSiac).HasMaxLength(500);
            entity.Property(e => e.Institucion).HasMaxLength(200);
            entity.Property(e => e.NivelModalidad).HasMaxLength(201);
            entity.Property(e => e.NombreComponenteUvm).HasMaxLength(200);
            entity.Property(e => e.NombreEvidencia).HasMaxLength(150);
            entity.Property(e => e.NombreIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.NombreNormativa).HasMaxLength(500);
            entity.Property(e => e.NombreSubIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.Proceso).HasMaxLength(50);
            entity.Property(e => e.SiglasAreaCorporativa).HasMaxLength(5);
            entity.Property(e => e.SiglasSubAreaCorporativa).HasMaxLength(5);
            entity.Property(e => e.SubAreaCorporativa).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwConfIndicadorSiac>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ConfIndicadorSIAC");

            entity.Property(e => e.AreaCorporativa).HasMaxLength(150);
            entity.Property(e => e.AreaResponsable).HasMaxLength(150);
            entity.Property(e => e.Ciclo).HasMaxLength(200);
            entity.Property(e => e.ClaveComponente).HasMaxLength(50);
            entity.Property(e => e.ClaveElementoEvaluacion).HasMaxLength(50);
            entity.Property(e => e.ClaveEvidencia).HasMaxLength(10);
            entity.Property(e => e.ClaveIndicadorSiac).HasMaxLength(50);
            entity.Property(e => e.ClaveNormativa).HasMaxLength(10);
            entity.Property(e => e.Componente).HasMaxLength(50);
            entity.Property(e => e.DescripcionComponenteUvm).HasMaxLength(500);
            entity.Property(e => e.DescripcionEvidencia).HasMaxLength(250);
            entity.Property(e => e.ElementoEvaluacion).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IndicadorSiac).HasMaxLength(500);
            entity.Property(e => e.Institucion).HasMaxLength(200);
            entity.Property(e => e.NivelModalidad).HasMaxLength(201);
            entity.Property(e => e.NombreComponenteUvm).HasMaxLength(200);
            entity.Property(e => e.NombreEvidencia).HasMaxLength(150);
            entity.Property(e => e.NombreIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.NombreNormativa).HasMaxLength(500);
            entity.Property(e => e.NombreSubIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.Proceso).HasMaxLength(50);
            entity.Property(e => e.SiglasAreaCorporativa).HasMaxLength(5);
            entity.Property(e => e.SiglasSubAreaCorporativa).HasMaxLength(5);
            entity.Property(e => e.SubAreaCorporativa).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwConfIndicadorSiacFile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ConfIndicadorSiacFile");

            entity.Property(e => e.FileName).HasMaxLength(200);
        });

        modelBuilder.Entity<VwEscalaMedicionCondicion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EscalaMedicionCondicion");

            entity.Property(e => e.Condicion).HasMaxLength(2000);
            entity.Property(e => e.Escala).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwEscalaMedicionCondicionExcel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EscalaMedicionCondicionExcel");

            entity.Property(e => e.ClaveIndicadorSiac).HasMaxLength(50);
            entity.Property(e => e.Condicion).HasMaxLength(2000);
            entity.Property(e => e.DescripcionComponenteUvm).HasMaxLength(500);
            entity.Property(e => e.Escala).HasMaxLength(100);
            entity.Property(e => e.IndicadorSiac).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.NombreComponenteUvm).HasMaxLength(200);
            entity.Property(e => e.NombreIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.NombreSubIndicadorUvm).HasMaxLength(500);
        });

        modelBuilder.Entity<VwIndicadorUvm>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_IndicadorUvm");

            entity.Property(e => e.DescripcionComponenteUvm).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreComponenteUvm).HasMaxLength(200);
            entity.Property(e => e.NombreIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwPerfilBase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Perfil_Base");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwSubIndicadorUvm>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SubIndicadorUvm");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NombreComponenteUvm).HasMaxLength(200);
            entity.Property(e => e.NombreIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.NombreSubIndicadorUvm).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwUsuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Usuario");

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.AreaCorporativa).HasMaxLength(150);
            entity.Property(e => e.AreaResponsable).HasMaxLength(150);
            entity.Property(e => e.Campus).HasMaxLength(500);
            entity.Property(e => e.Correo).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Modalidad).HasMaxLength(100);
            entity.Property(e => e.Nivel).HasMaxLength(100);
            entity.Property(e => e.NivelRevision).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Perfil).HasMaxLength(100);
            entity.Property(e => e.Region).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwUsuarioAreaCorporativa>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UsuarioAreaCorporativa");

            entity.Property(e => e.AreaCorporativa).HasMaxLength(150);
        });

        modelBuilder.Entity<VwUsuarioAreaResponsable>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UsuarioAreaResponsable");

            entity.Property(e => e.AreaResponsable).HasMaxLength(150);
            entity.Property(e => e.DependenciaArea).HasMaxLength(200);
        });

        modelBuilder.Entity<VwUsuarioBase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Usuario_Base");

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.AreaCorporativa).HasMaxLength(4000);
            entity.Property(e => e.AreaResponsable).HasMaxLength(4000);
            entity.Property(e => e.Campus).HasMaxLength(4000);
            entity.Property(e => e.Correo).HasMaxLength(500);
            entity.Property(e => e.DependenciaArea).HasMaxLength(4000);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NivelModalidad).HasMaxLength(4000);
            entity.Property(e => e.NivelRevision).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Perfil).HasMaxLength(100);
            entity.Property(e => e.Region).HasMaxLength(4000);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<VwUsuarioCampus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UsuarioCampus");

            entity.Property(e => e.Campus).HasMaxLength(500);
        });

        modelBuilder.Entity<VwUsuarioNivelModalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UsuarioNivelModalidad");

            entity.Property(e => e.Modalidad).HasMaxLength(100);
            entity.Property(e => e.Nivel).HasMaxLength(100);
        });

        modelBuilder.Entity<VwUsuarioRegion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UsuarioRegion");

            entity.Property(e => e.Region).HasMaxLength(500);
            entity.Property(e => e.Usuario).HasMaxLength(301);
        });

        modelBuilder.Entity<VwUsuariosSidebar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UsuariosSidebar");

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.Correo).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NivelRevision).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Perfil).HasMaxLength(100);
            entity.Property(e => e.TipoAcceso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoVista).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
            entity.Property(e => e.Vista).HasMaxLength(500);
        });

        modelBuilder.Entity<VwVistasPerfil>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_VistasPerfil");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Perfil).HasMaxLength(100);
            entity.Property(e => e.TipoAcceso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoAccesoDescripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TipoVista).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
            entity.Property(e => e.Vista).HasMaxLength(500);
        });

        modelBuilder.Entity<VwVistum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Vista");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.TipoVista).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
