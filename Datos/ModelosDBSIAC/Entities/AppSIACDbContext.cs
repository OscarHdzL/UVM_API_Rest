using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Capitulo> Capitulos { get; set; }

    public virtual DbSet<CatAcreditadora> CatAcreditadoras { get; set; }

    public virtual DbSet<CatAreaCorporativa> CatAreaCorporativas { get; set; }

    public virtual DbSet<CatAreaResponsable> CatAreaResponsables { get; set; }

    public virtual DbSet<CatCampus> CatCampuses { get; set; }

    public virtual DbSet<CatCapitulo> CatCapitulos { get; set; }

    public virtual DbSet<CatComponente> CatComponentes { get; set; }

    public virtual DbSet<CatElementoEvaluacion> CatElementoEvaluacions { get; set; }

    public virtual DbSet<CatEtapa> CatEtapas { get; set; }

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

    public virtual DbSet<CatTipoAcceso> CatTipoAccesos { get; set; }

    public virtual DbSet<CatTipoVistum> CatTipoVista { get; set; }

    public virtual DbSet<CatUsuario> CatUsuarios { get; set; }

    public virtual DbSet<CatVistum> CatVista { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<ComponenteUvm> ComponenteUvms { get; set; }

    public virtual DbSet<IndicadorUvm> IndicadorUvms { get; set; }

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

    public virtual DbSet<VwCatAreaResponsable> VwCatAreaResponsables { get; set; }

    public virtual DbSet<VwCatCampus> VwCatCampuses { get; set; }

    public virtual DbSet<VwCatCiclo> VwCatCiclos { get; set; }

    public virtual DbSet<VwCatEtapa> VwCatEtapas { get; set; }

    public virtual DbSet<VwCatMatrizUvm> VwCatMatrizUvms { get; set; }

    public virtual DbSet<VwCatPeriodoEvaluacion> VwCatPeriodoEvaluacions { get; set; }

    public virtual DbSet<VwCatPeriodoEvaluacionBase> VwCatPeriodoEvaluacionBases { get; set; }

    public virtual DbSet<VwCatPonderacion> VwCatPonderacions { get; set; }

    public virtual DbSet<VwCatTipoAcceso> VwCatTipoAccesos { get; set; }

    public virtual DbSet<VwComponenteUvm> VwComponenteUvms { get; set; }

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:dbsql-sgapi-qa-uvm.database.windows.net,1433;Initial Catalog=DBSIAC-Desa-UVM;Persist Security Info=False;User ID=appUser;Password=AdminM4n$pp5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcreditadoraProceso>(entity =>
        {
            entity.ToTable("AcreditadoraProceso");

            entity.Property(e => e.Nombre).HasMaxLength(500);
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
            entity.HasKey(e => new { e.ComponenteId, e.NivelModalidadId }).HasName("PK_cat_Ponderacion_1");

            entity.ToTable("cat_Ponderacion");

            entity.Property(e => e.ComponenteId).HasColumnName("Componente_Id");
            entity.Property(e => e.NivelModalidadId).HasColumnName("NivelModalidad_Id");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
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

        modelBuilder.Entity<VwCatAreaResponsable>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CatAreaResponsable");

            entity.Property(e => e.AreaResponsablePadre).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
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
        });

        modelBuilder.Entity<VwUsuarioBase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Usuario_Base");

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.Correo).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.NivelRevision).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Perfil).HasMaxLength(100);
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
