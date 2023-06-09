/****** Object:  Database [DBSIAC-Dev-UVM]    Script Date: 02/06/2023 05:00:32 p. m. ******/
CREATE DATABASE [DBSIAC-Dev-UVM]  (EDITION = 'Standard', SERVICE_OBJECTIVE = 'S2', MAXSIZE = 250 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET  MULTI_USER 
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET ENCRYPTION ON
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET QUERY_STORE = ON
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  User [appUser]    Script Date: 02/06/2023 05:00:32 p. m. ******/
CREATE USER [appUser] WITH PASSWORD=N'j/fORzlqPIovZsYpAgXsJXGp1TsisnBULLJV7NS/x6Q=', DEFAULT_SCHEMA=[dbo]
GO
sys.sp_addrolemember @rolename = N'db_owner', @membername = N'appUser'
GO
/****** Object:  Table [dbo].[Acreditadora]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acreditadora](
	[AcreditadoraID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
	[EsFimpes] [bit] NULL,
 CONSTRAINT [PK_Acreditadora] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AcreditadoraProceso]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcreditadoraProceso](
	[AcreditadoraProcesoID] [int] IDENTITY(1,1) NOT NULL,
	[AcreditadoraID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_AcreditadoraProceso] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartado]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartado](
	[ApartadoID] [int] IDENTITY(1,1) NOT NULL,
	[ApartadoPadre] [int] NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[Titulo] [nvarchar](500) NOT NULL,
	[Especificaciones] [nvarchar](max) NULL,
	[Orden] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Apartado] PRIMARY KEY CLUSTERED 
(
	[ApartadoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AreaCorporativa]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaCorporativa](
	[AreaCorporativaID] [nvarchar](5) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_AreaCorporativa] PRIMARY KEY CLUSTERED 
(
	[AreaCorporativaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AreaResponsabilidad]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaResponsabilidad](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[AreaResponsabilidadID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[NivelAtencionID] [nvarchar](50) NOT NULL,
	[NivelOrganizacionalID] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_AreaResponsabilidad] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[AreaResponsabilidadID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AreaResponsable]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaResponsable](
	[AreaResponsableID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[AreaResponsablePadre] [int] NULL,
	[Generica] [bit] NOT NULL,
	[Consolidacion] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_AreaResponsable] PRIMARY KEY CLUSTERED 
(
	[AreaResponsableID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campus]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campus](
	[CampusID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[RegionID] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CampusID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Capitulo]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capitulo](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CapituloID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Descripcion] [nvarchar](1500) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Capitulo] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[CapituloID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[CarreraID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Plan] [nvarchar](15) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CarreraID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciclo]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciclo](
	[Nombre] [nvarchar](50) NOT NULL,
	[CicloID] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK__Ciclo] PRIMARY KEY CLUSTERED 
(
	[CicloID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComentarioSeguimiento]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComentarioSeguimiento](
	[ComentarioSeguimientoID] [int] IDENTITY(1,1) NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[Orden] [int] NOT NULL,
	[Titulo] [nvarchar](500) NULL,
	[Contenido] [nvarchar](max) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_ComentarioSeguimiento] PRIMARY KEY CLUSTERED 
(
	[ComentarioSeguimientoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConfiguracionSistema]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfiguracionSistema](
	[ConfiguracionSistemaID] [int] IDENTITY(1,1) NOT NULL,
	[MensajeBienvenida] [nvarchar](4000) NOT NULL,
	[UrlManual] [nvarchar](400) NOT NULL,
 CONSTRAINT [PK_ConfiguracionSistema] PRIMARY KEY CLUSTERED 
(
	[ConfiguracionSistemaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Criterio]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criterio](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CapituloID] [nvarchar](50) NOT NULL,
	[TipoEvidenciaID] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](1500) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Criterio] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[CriterioID] ASC,
	[CarreraID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evidencia]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evidencia](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
	[EvidenciaID] [int] NOT NULL,
	[AreaResponsabilidadID] [nvarchar](50) NULL,
	[TipoEvidenciaID] [nvarchar](50) NULL,
	[SedeID] [nvarchar](50) NULL,
	[NivelOrganizacionalID] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](1500) NOT NULL,
	[Especificaciones] [nvarchar](4000) NULL,
	[FechaCompromiso] [date] NOT NULL,
	[Responsable] [uniqueidentifier] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Evidencia] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[CarreraID] ASC,
	[CriterioID] ASC,
	[EvidenciaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvidenciaAnio]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvidenciaAnio](
	[AnioID] [int] NOT NULL,
	[EvidenciaID] [int] NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EvidenciaAnio] PRIMARY KEY CLUSTERED 
(
	[AnioID] ASC,
	[EvidenciaID] ASC,
	[AcreditadoraProcesoID] ASC,
	[CarreraID] ASC,
	[CriterioID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvidenciaCampus]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvidenciaCampus](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
	[EvidenciaID] [int] NOT NULL,
	[CampusID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EvidenciaCampus] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[CarreraID] ASC,
	[CriterioID] ASC,
	[EvidenciaID] ASC,
	[CampusID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvidenciaCiclo]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvidenciaCiclo](
	[EvidenciaID] [int] NOT NULL,
	[CicloID] [nvarchar](50) NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EvidenciaCiclo] PRIMARY KEY CLUSTERED 
(
	[EvidenciaID] ASC,
	[CicloID] ASC,
	[AcreditadoraProcesoID] ASC,
	[CriterioID] ASC,
	[CarreraID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvidenciaSubarea]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvidenciaSubarea](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
	[EvidenciaID] [int] NOT NULL,
	[SubareaID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EvidenciaSubarea] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[CarreraID] ASC,
	[CriterioID] ASC,
	[EvidenciaID] ASC,
	[SubareaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelAtencion]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelAtencion](
	[NivelAtencionID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[NivelAtencionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelModalidad]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelModalidad](
	[NivelModalidadID] [nvarchar](5) NOT NULL,
	[Nivel] [nvarchar](100) NOT NULL,
	[Modalidad] [nvarchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_NivelModalidad] PRIMARY KEY CLUSTERED 
(
	[NivelModalidadID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelOrganizacional]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelOrganizacional](
	[NivelOrganizacionalID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[NivelOrganizacionalID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[PerfilID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[VistaInicial] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[PerfilID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[RegionID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
	[DireccionRegional] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistroEvidencia]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroEvidencia](
	[RegistroEvidenciaID] [int] IDENTITY(1,1) NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
	[EvidenciaID] [int] NOT NULL,
	[SubareaID] [nvarchar](50) NOT NULL,
	[CampusID] [nvarchar](50) NOT NULL,
	[AnioID] [int] NULL,
	[CicloID] [nvarchar](50) NULL,
	[EsCargada] [bit] NULL,
	[EsAceptada] [bit] NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_RegistroEvidencia] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[CarreraID] ASC,
	[CriterioID] ASC,
	[EvidenciaID] ASC,
	[SubareaID] ASC,
	[CampusID] ASC,
	[RegistroEvidenciaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistroEvidenciaArchivo]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroEvidenciaArchivo](
	[RegistroEvidenciaArchivoID] [int] IDENTITY(1,1) NOT NULL,
	[RegistroEvidenciaID] [int] NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
	[EvidenciaID] [int] NOT NULL,
	[SubareaID] [nvarchar](50) NOT NULL,
	[CampusID] [nvarchar](50) NOT NULL,
	[EsUrl] [bit] NOT NULL,
	[NombreArchivo] [nvarchar](500) NULL,
	[Mime] [nvarchar](500) NULL,
	[Url] [nvarchar](1500) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_RegistroEvidenciaArchivo] PRIMARY KEY CLUSTERED 
(
	[RegistroEvidenciaArchivoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[RolID] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripción] [nvarchar](500) NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK__Rol__F92302D12D711E53] PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolProceso]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolProceso](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[RolProcesoID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[VistaInicial] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_RolProceso] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[RolProcesoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolProcesoVista]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolProcesoVista](
	[RolProcesoVistaID] [int] IDENTITY(1,1) NOT NULL,
	[RolProcesoID] [nvarchar](50) NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[VistaID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RolProcesoVista] PRIMARY KEY CLUSTERED 
(
	[RolProcesoVistaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolProcesoVistaTipoAcceso]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolProcesoVistaTipoAcceso](
	[RolProcesoVistaTipoAccesoID] [int] IDENTITY(1,1) NOT NULL,
	[RolProcesoVistaID] [int] NOT NULL,
	[TipoAccesoID] [char](1) NOT NULL,
 CONSTRAINT [PK_RolVistaTipoAcceso] PRIMARY KEY CLUSTERED 
(
	[RolProcesoVistaTipoAccesoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sede]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sede](
	[SedeID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SedeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subarea]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subarea](
	[SubareaID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
	[NivelOrganizacionalID] [nvarchar](50) NOT NULL,
	[NivelAtencionID] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubareaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAcceso]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAcceso](
	[TipoAccesoID] [char](1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoAcceso] PRIMARY KEY CLUSTERED 
(
	[TipoAccesoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEvidencia]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEvidencia](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[TipoEvidenciaID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[RegionID] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoEvidencia] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[TipoEvidenciaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Apellidos] [nvarchar](150) NOT NULL,
	[Correo] [nvarchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
	[NivelRevision] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[PerfilID] [int] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
	[EsAvisoAceptado] [bit] NULL,
 CONSTRAINT [PK__Usuario__2B3DE798895CF517] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioAreaCorporativa]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioAreaCorporativa](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[AreaCorporativaID] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_UsuarioAreaCorporativa] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[AreaCorporativaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioAreaResponsable]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioAreaResponsable](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[AreaResponsableID] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioAreaResponsable] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[AreaResponsableID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioCampus]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioCampus](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[CampusID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UsuarioCampus] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[CampusID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioNivelModalidad]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioNivelModalidad](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[NivelModalidadID] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_UsuarioNivelModalidad] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[NivelModalidadID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRegion]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRegion](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[RegionID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UsuarioRegion] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[RegionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRol](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[RolID] [int] NOT NULL,
 CONSTRAINT [PK__UsuarioR__6B90DCA8DF136C71] PRIMARY KEY CLUSTERED 
(
	[RolID] ASC,
	[UsuarioID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRolProceso]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRolProceso](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[RolProcesoID] [nvarchar](50) NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
 CONSTRAINT [PK_UsuarioRolProceso] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[AcreditadoraProcesoID] ASC,
	[RolProcesoID] ASC,
	[CarreraID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRolProcesoCampus]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRolProcesoCampus](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[RolProcesoID] [nvarchar](50) NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CampusID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UsuarioRolProcesoCampus] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[AcreditadoraProcesoID] ASC,
	[RolProcesoID] ASC,
	[CarreraID] ASC,
	[CampusID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRolProcesoCapitulo]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRolProcesoCapitulo](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[RolProcesoID] [nvarchar](50) NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CapituloID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UsuarioRolProcesoCapitulo] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[AcreditadoraProcesoID] ASC,
	[RolProcesoID] ASC,
	[CarreraID] ASC,
	[CapituloID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRolProcesoCriterio]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRolProcesoCriterio](
	[UsuarioID] [uniqueidentifier] NOT NULL,
	[AcreditadoraProcesoID] [int] NOT NULL,
	[RolProcesoID] [nvarchar](50) NOT NULL,
	[CarreraID] [nvarchar](50) NOT NULL,
	[CriterioID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UsuarioRolProcesoCriterio] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[AcreditadoraProcesoID] ASC,
	[RolProcesoID] ASC,
	[CarreraID] ASC,
	[CriterioID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vista]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vista](
	[VistaID] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](500) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [nvarchar](50) NOT NULL,
	[FechaModificacion] [datetime] NULL,
	[UsuarioModificacion] [nvarchar](50) NULL,
	[Clave] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vista] PRIMARY KEY CLUSTERED 
(
	[VistaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VistaRolProceso]    Script Date: 02/06/2023 05:00:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VistaRolProceso](
	[AcreditadoraProcesoID] [int] NOT NULL,
	[RolProcesoID] [nvarchar](50) NOT NULL,
	[VistaID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VistaRolProceso] PRIMARY KEY CLUSTERED 
(
	[AcreditadoraProcesoID] ASC,
	[RolProcesoID] ASC,
	[VistaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Acreditadora] ([AcreditadoraID], [Nombre], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [EsFimpes]) VALUES (N'1', N'POSTMAN2', 0, CAST(N'2023-06-02T00:00:00.000' AS DateTime), N'USUARIOTEST', CAST(N'2023-06-02T20:37:14.917' AS DateTime), N'POSTMAN2', 1)
INSERT [dbo].[Acreditadora] ([AcreditadoraID], [Nombre], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [EsFimpes]) VALUES (N'2', N'TEST', 1, CAST(N'2023-06-02T00:00:00.000' AS DateTime), N'USUARIOTEST', NULL, NULL, 1)
INSERT [dbo].[Acreditadora] ([AcreditadoraID], [Nombre], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [EsFimpes]) VALUES (N'3', N'TEST', 1, CAST(N'2023-06-02T00:00:00.000' AS DateTime), N'USUARIOTEST', NULL, NULL, 1)
INSERT [dbo].[Acreditadora] ([AcreditadoraID], [Nombre], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [EsFimpes]) VALUES (N'4', N'TEST', 1, CAST(N'2023-06-02T00:00:00.000' AS DateTime), N'USUARIOTEST', NULL, NULL, 1)
INSERT [dbo].[Acreditadora] ([AcreditadoraID], [Nombre], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [EsFimpes]) VALUES (N'5', N'TEST', 1, CAST(N'2023-06-02T00:00:00.000' AS DateTime), N'USUARIOTEST', NULL, NULL, 1)
INSERT [dbo].[Acreditadora] ([AcreditadoraID], [Nombre], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [EsFimpes]) VALUES (N'6', N'POSTMAN', 1, CAST(N'2023-06-02T20:37:14.917' AS DateTime), N'POSTMAN', NULL, NULL, 1)
INSERT [dbo].[Acreditadora] ([AcreditadoraID], [Nombre], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [EsFimpes]) VALUES (N'7', N'POSTMAN2', 1, CAST(N'2023-06-02T20:37:14.917' AS DateTime), N'POSTMAN2', NULL, NULL, 1)
INSERT [dbo].[Acreditadora] ([AcreditadoraID], [Nombre], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [EsFimpes]) VALUES (N'8', N'POSTMAN2', 1, CAST(N'2023-06-02T20:37:14.917' AS DateTime), N'POSTMAN2', NULL, NULL, 1)
GO
/****** Object:  Index [IX_AcreditadoraProceso]    Script Date: 02/06/2023 05:00:56 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_AcreditadoraProceso] ON [dbo].[AcreditadoraProceso]
(
	[AcreditadoraProcesoID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CL_APARTADO]    Script Date: 02/06/2023 05:00:56 p. m. ******/
CREATE NONCLUSTERED INDEX [CL_APARTADO] ON [dbo].[Apartado]
(
	[AcreditadoraProcesoID] ASC,
	[CarreraID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK__NivelModalidad]    Script Date: 02/06/2023 05:00:56 p. m. ******/
ALTER TABLE [dbo].[NivelModalidad] ADD  CONSTRAINT [PK__NivelModalidad] UNIQUE NONCLUSTERED 
(
	[NivelModalidadID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuario_Correo]    Script Date: 02/06/2023 05:00:56 p. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuario_Correo] ON [dbo].[Usuario]
(
	[Correo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AcreditadoraProceso]  WITH CHECK ADD  CONSTRAINT [FK_AcreditadoraProceso_Acreditadora] FOREIGN KEY([AcreditadoraID])
REFERENCES [dbo].[Acreditadora] ([AcreditadoraID])
GO
ALTER TABLE [dbo].[AcreditadoraProceso] CHECK CONSTRAINT [FK_AcreditadoraProceso_Acreditadora]
GO
ALTER TABLE [dbo].[Apartado]  WITH CHECK ADD  CONSTRAINT [FK_Apartado_Apartado] FOREIGN KEY([ApartadoPadre])
REFERENCES [dbo].[Apartado] ([ApartadoID])
GO
ALTER TABLE [dbo].[Apartado] CHECK CONSTRAINT [FK_Apartado_Apartado]
GO
ALTER TABLE [dbo].[Apartado]  WITH CHECK ADD  CONSTRAINT [FK_Apartado_Carrera] FOREIGN KEY([CarreraID])
REFERENCES [dbo].[Carrera] ([CarreraID])
GO
ALTER TABLE [dbo].[Apartado] CHECK CONSTRAINT [FK_Apartado_Carrera]
GO
ALTER TABLE [dbo].[Apartado]  WITH CHECK ADD  CONSTRAINT [FK_Apartado_Criterio] FOREIGN KEY([AcreditadoraProcesoID], [CriterioID], [CarreraID])
REFERENCES [dbo].[Criterio] ([AcreditadoraProcesoID], [CriterioID], [CarreraID])
GO
ALTER TABLE [dbo].[Apartado] CHECK CONSTRAINT [FK_Apartado_Criterio]
GO
ALTER TABLE [dbo].[AreaResponsabilidad]  WITH CHECK ADD  CONSTRAINT [FK_AreaResponsabilidad_AcreditadoraProceso] FOREIGN KEY([AcreditadoraProcesoID])
REFERENCES [dbo].[AcreditadoraProceso] ([AcreditadoraProcesoID])
GO
ALTER TABLE [dbo].[AreaResponsabilidad] CHECK CONSTRAINT [FK_AreaResponsabilidad_AcreditadoraProceso]
GO
ALTER TABLE [dbo].[AreaResponsabilidad]  WITH CHECK ADD  CONSTRAINT [FK_AreaResponsabilidad_NivelAtencion] FOREIGN KEY([NivelAtencionID])
REFERENCES [dbo].[NivelAtencion] ([NivelAtencionID])
GO
ALTER TABLE [dbo].[AreaResponsabilidad] CHECK CONSTRAINT [FK_AreaResponsabilidad_NivelAtencion]
GO
ALTER TABLE [dbo].[AreaResponsabilidad]  WITH CHECK ADD  CONSTRAINT [FK_AreaResponsabilidad_NivelOrganizacional] FOREIGN KEY([NivelOrganizacionalID])
REFERENCES [dbo].[NivelOrganizacional] ([NivelOrganizacionalID])
GO
ALTER TABLE [dbo].[AreaResponsabilidad] CHECK CONSTRAINT [FK_AreaResponsabilidad_NivelOrganizacional]
GO
ALTER TABLE [dbo].[AreaResponsable]  WITH CHECK ADD  CONSTRAINT [FK_AreaResponsable_AreaResponsable1] FOREIGN KEY([AreaResponsablePadre])
REFERENCES [dbo].[AreaResponsable] ([AreaResponsableID])
GO
ALTER TABLE [dbo].[AreaResponsable] CHECK CONSTRAINT [FK_AreaResponsable_AreaResponsable1]
GO
ALTER TABLE [dbo].[Campus]  WITH CHECK ADD  CONSTRAINT [FK_Campus_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO
ALTER TABLE [dbo].[Campus] CHECK CONSTRAINT [FK_Campus_Region]
GO
ALTER TABLE [dbo].[Capitulo]  WITH CHECK ADD  CONSTRAINT [FK_Capitulo_AcreditadoraProceso] FOREIGN KEY([AcreditadoraProcesoID])
REFERENCES [dbo].[AcreditadoraProceso] ([AcreditadoraProcesoID])
GO
ALTER TABLE [dbo].[Capitulo] CHECK CONSTRAINT [FK_Capitulo_AcreditadoraProceso]
GO
ALTER TABLE [dbo].[ComentarioSeguimiento]  WITH CHECK ADD  CONSTRAINT [FK_ComentarioSeguimiento_AcreditadoraProceso] FOREIGN KEY([AcreditadoraProcesoID])
REFERENCES [dbo].[AcreditadoraProceso] ([AcreditadoraProcesoID])
GO
ALTER TABLE [dbo].[ComentarioSeguimiento] CHECK CONSTRAINT [FK_ComentarioSeguimiento_AcreditadoraProceso]
GO
ALTER TABLE [dbo].[ComentarioSeguimiento]  WITH CHECK ADD  CONSTRAINT [FK_ComentarioSeguimiento_Carrera] FOREIGN KEY([CarreraID])
REFERENCES [dbo].[Carrera] ([CarreraID])
GO
ALTER TABLE [dbo].[ComentarioSeguimiento] CHECK CONSTRAINT [FK_ComentarioSeguimiento_Carrera]
GO
ALTER TABLE [dbo].[Criterio]  WITH CHECK ADD  CONSTRAINT [FK_Criterio_AcreditadoraProceso] FOREIGN KEY([AcreditadoraProcesoID])
REFERENCES [dbo].[AcreditadoraProceso] ([AcreditadoraProcesoID])
GO
ALTER TABLE [dbo].[Criterio] CHECK CONSTRAINT [FK_Criterio_AcreditadoraProceso]
GO
ALTER TABLE [dbo].[Criterio]  WITH CHECK ADD  CONSTRAINT [FK_Criterio_Capitulo] FOREIGN KEY([AcreditadoraProcesoID], [CapituloID])
REFERENCES [dbo].[Capitulo] ([AcreditadoraProcesoID], [CapituloID])
GO
ALTER TABLE [dbo].[Criterio] CHECK CONSTRAINT [FK_Criterio_Capitulo]
GO
ALTER TABLE [dbo].[Criterio]  WITH CHECK ADD  CONSTRAINT [FK_Criterio_Carrera] FOREIGN KEY([CarreraID])
REFERENCES [dbo].[Carrera] ([CarreraID])
GO
ALTER TABLE [dbo].[Criterio] CHECK CONSTRAINT [FK_Criterio_Carrera]
GO
ALTER TABLE [dbo].[Criterio]  WITH CHECK ADD  CONSTRAINT [FK_Criterio_TipoEvidencia] FOREIGN KEY([AcreditadoraProcesoID], [TipoEvidenciaID])
REFERENCES [dbo].[TipoEvidencia] ([AcreditadoraProcesoID], [TipoEvidenciaID])
GO
ALTER TABLE [dbo].[Criterio] CHECK CONSTRAINT [FK_Criterio_TipoEvidencia]
GO
ALTER TABLE [dbo].[Evidencia]  WITH CHECK ADD  CONSTRAINT [FK_Evidencia_AcreditadoraProceso] FOREIGN KEY([AcreditadoraProcesoID])
REFERENCES [dbo].[AcreditadoraProceso] ([AcreditadoraProcesoID])
GO
ALTER TABLE [dbo].[Evidencia] CHECK CONSTRAINT [FK_Evidencia_AcreditadoraProceso]
GO
ALTER TABLE [dbo].[Evidencia]  WITH CHECK ADD  CONSTRAINT [FK_Evidencia_AreaResponsabilidad] FOREIGN KEY([AcreditadoraProcesoID], [AreaResponsabilidadID])
REFERENCES [dbo].[AreaResponsabilidad] ([AcreditadoraProcesoID], [AreaResponsabilidadID])
GO
ALTER TABLE [dbo].[Evidencia] CHECK CONSTRAINT [FK_Evidencia_AreaResponsabilidad]
GO
ALTER TABLE [dbo].[Evidencia]  WITH CHECK ADD  CONSTRAINT [FK_Evidencia_Carrera] FOREIGN KEY([CarreraID])
REFERENCES [dbo].[Carrera] ([CarreraID])
GO
ALTER TABLE [dbo].[Evidencia] CHECK CONSTRAINT [FK_Evidencia_Carrera]
GO
ALTER TABLE [dbo].[Evidencia]  WITH CHECK ADD  CONSTRAINT [FK_Evidencia_Criterio] FOREIGN KEY([AcreditadoraProcesoID], [CriterioID], [CarreraID])
REFERENCES [dbo].[Criterio] ([AcreditadoraProcesoID], [CriterioID], [CarreraID])
GO
ALTER TABLE [dbo].[Evidencia] CHECK CONSTRAINT [FK_Evidencia_Criterio]
GO
ALTER TABLE [dbo].[Evidencia]  WITH CHECK ADD  CONSTRAINT [FK_Evidencia_NivelOrganizacional] FOREIGN KEY([NivelOrganizacionalID])
REFERENCES [dbo].[NivelOrganizacional] ([NivelOrganizacionalID])
GO
ALTER TABLE [dbo].[Evidencia] CHECK CONSTRAINT [FK_Evidencia_NivelOrganizacional]
GO
ALTER TABLE [dbo].[Evidencia]  WITH CHECK ADD  CONSTRAINT [FK_Evidencia_Sede] FOREIGN KEY([SedeID])
REFERENCES [dbo].[Sede] ([SedeID])
GO
ALTER TABLE [dbo].[Evidencia] CHECK CONSTRAINT [FK_Evidencia_Sede]
GO
ALTER TABLE [dbo].[Evidencia]  WITH CHECK ADD  CONSTRAINT [FK_Evidencia_TipoEvidencia] FOREIGN KEY([AcreditadoraProcesoID], [TipoEvidenciaID])
REFERENCES [dbo].[TipoEvidencia] ([AcreditadoraProcesoID], [TipoEvidenciaID])
GO
ALTER TABLE [dbo].[Evidencia] CHECK CONSTRAINT [FK_Evidencia_TipoEvidencia]
GO
ALTER TABLE [dbo].[Evidencia]  WITH CHECK ADD  CONSTRAINT [FK_Evidencia_Usuario] FOREIGN KEY([Responsable])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Evidencia] CHECK CONSTRAINT [FK_Evidencia_Usuario]
GO
ALTER TABLE [dbo].[EvidenciaAnio]  WITH CHECK ADD  CONSTRAINT [FK_EvidenciaAnio_Evidencia] FOREIGN KEY([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
REFERENCES [dbo].[Evidencia] ([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
GO
ALTER TABLE [dbo].[EvidenciaAnio] CHECK CONSTRAINT [FK_EvidenciaAnio_Evidencia]
GO
ALTER TABLE [dbo].[EvidenciaCampus]  WITH CHECK ADD  CONSTRAINT [FK_EvidenciaCampus_Campus] FOREIGN KEY([CampusID])
REFERENCES [dbo].[Campus] ([CampusID])
GO
ALTER TABLE [dbo].[EvidenciaCampus] CHECK CONSTRAINT [FK_EvidenciaCampus_Campus]
GO
ALTER TABLE [dbo].[EvidenciaCampus]  WITH CHECK ADD  CONSTRAINT [FK_EvidenciaCampus_Evidencia] FOREIGN KEY([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
REFERENCES [dbo].[Evidencia] ([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
GO
ALTER TABLE [dbo].[EvidenciaCampus] CHECK CONSTRAINT [FK_EvidenciaCampus_Evidencia]
GO
ALTER TABLE [dbo].[EvidenciaCiclo]  WITH CHECK ADD  CONSTRAINT [FK_EvidenciaCiclo_Ciclo] FOREIGN KEY([CicloID])
REFERENCES [dbo].[Ciclo] ([CicloID])
GO
ALTER TABLE [dbo].[EvidenciaCiclo] CHECK CONSTRAINT [FK_EvidenciaCiclo_Ciclo]
GO
ALTER TABLE [dbo].[EvidenciaCiclo]  WITH CHECK ADD  CONSTRAINT [FK_EvidenciaCiclo_Evidencia] FOREIGN KEY([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
REFERENCES [dbo].[Evidencia] ([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
GO
ALTER TABLE [dbo].[EvidenciaCiclo] CHECK CONSTRAINT [FK_EvidenciaCiclo_Evidencia]
GO
ALTER TABLE [dbo].[EvidenciaSubarea]  WITH CHECK ADD  CONSTRAINT [FK_EvidenciaSubarea_Evidencia] FOREIGN KEY([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
REFERENCES [dbo].[Evidencia] ([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
GO
ALTER TABLE [dbo].[EvidenciaSubarea] CHECK CONSTRAINT [FK_EvidenciaSubarea_Evidencia]
GO
ALTER TABLE [dbo].[EvidenciaSubarea]  WITH CHECK ADD  CONSTRAINT [FK_EvidenciaSubarea_Subarea] FOREIGN KEY([SubareaID])
REFERENCES [dbo].[Subarea] ([SubareaID])
GO
ALTER TABLE [dbo].[EvidenciaSubarea] CHECK CONSTRAINT [FK_EvidenciaSubarea_Subarea]
GO
ALTER TABLE [dbo].[Perfil]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Vista] FOREIGN KEY([VistaInicial])
REFERENCES [dbo].[Vista] ([VistaID])
GO
ALTER TABLE [dbo].[Perfil] CHECK CONSTRAINT [FK_Perfil_Vista]
GO
ALTER TABLE [dbo].[RegistroEvidencia]  WITH CHECK ADD  CONSTRAINT [FK_RegistroEvidencia_AcreditadoraProceso] FOREIGN KEY([AcreditadoraProcesoID])
REFERENCES [dbo].[AcreditadoraProceso] ([AcreditadoraProcesoID])
GO
ALTER TABLE [dbo].[RegistroEvidencia] CHECK CONSTRAINT [FK_RegistroEvidencia_AcreditadoraProceso]
GO
ALTER TABLE [dbo].[RegistroEvidencia]  WITH CHECK ADD  CONSTRAINT [FK_RegistroEvidencia_Campus] FOREIGN KEY([CampusID])
REFERENCES [dbo].[Campus] ([CampusID])
GO
ALTER TABLE [dbo].[RegistroEvidencia] CHECK CONSTRAINT [FK_RegistroEvidencia_Campus]
GO
ALTER TABLE [dbo].[RegistroEvidencia]  WITH CHECK ADD  CONSTRAINT [FK_RegistroEvidencia_Ciclo] FOREIGN KEY([CicloID])
REFERENCES [dbo].[Ciclo] ([CicloID])
GO
ALTER TABLE [dbo].[RegistroEvidencia] CHECK CONSTRAINT [FK_RegistroEvidencia_Ciclo]
GO
ALTER TABLE [dbo].[RegistroEvidencia]  WITH CHECK ADD  CONSTRAINT [FK_RegistroEvidencia_Criterio] FOREIGN KEY([AcreditadoraProcesoID], [CriterioID], [CarreraID])
REFERENCES [dbo].[Criterio] ([AcreditadoraProcesoID], [CriterioID], [CarreraID])
GO
ALTER TABLE [dbo].[RegistroEvidencia] CHECK CONSTRAINT [FK_RegistroEvidencia_Criterio]
GO
ALTER TABLE [dbo].[RegistroEvidencia]  WITH CHECK ADD  CONSTRAINT [FK_RegistroEvidencia_Evidencia] FOREIGN KEY([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
REFERENCES [dbo].[Evidencia] ([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID])
GO
ALTER TABLE [dbo].[RegistroEvidencia] CHECK CONSTRAINT [FK_RegistroEvidencia_Evidencia]
GO
ALTER TABLE [dbo].[RegistroEvidencia]  WITH CHECK ADD  CONSTRAINT [FK_RegistroEvidencia_Subarea] FOREIGN KEY([SubareaID])
REFERENCES [dbo].[Subarea] ([SubareaID])
GO
ALTER TABLE [dbo].[RegistroEvidencia] CHECK CONSTRAINT [FK_RegistroEvidencia_Subarea]
GO
ALTER TABLE [dbo].[RegistroEvidenciaArchivo]  WITH CHECK ADD  CONSTRAINT [FK_RegistroEvidenciaArchivo_RegistroEvidencia] FOREIGN KEY([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID], [SubareaID], [CampusID], [RegistroEvidenciaID])
REFERENCES [dbo].[RegistroEvidencia] ([AcreditadoraProcesoID], [CarreraID], [CriterioID], [EvidenciaID], [SubareaID], [CampusID], [RegistroEvidenciaID])
GO
ALTER TABLE [dbo].[RegistroEvidenciaArchivo] CHECK CONSTRAINT [FK_RegistroEvidenciaArchivo_RegistroEvidencia]
GO
ALTER TABLE [dbo].[RolProceso]  WITH CHECK ADD  CONSTRAINT [FK_RolProceso_AcreditadoraProceso] FOREIGN KEY([AcreditadoraProcesoID])
REFERENCES [dbo].[AcreditadoraProceso] ([AcreditadoraProcesoID])
GO
ALTER TABLE [dbo].[RolProceso] CHECK CONSTRAINT [FK_RolProceso_AcreditadoraProceso]
GO
ALTER TABLE [dbo].[RolProceso]  WITH CHECK ADD  CONSTRAINT [FK_RolProceso_Vista] FOREIGN KEY([VistaInicial])
REFERENCES [dbo].[Vista] ([VistaID])
GO
ALTER TABLE [dbo].[RolProceso] CHECK CONSTRAINT [FK_RolProceso_Vista]
GO
ALTER TABLE [dbo].[RolProcesoVista]  WITH CHECK ADD  CONSTRAINT [FK_RolProcesoVista_RolProceso] FOREIGN KEY([AcreditadoraProcesoID], [RolProcesoID])
REFERENCES [dbo].[RolProceso] ([AcreditadoraProcesoID], [RolProcesoID])
GO
ALTER TABLE [dbo].[RolProcesoVista] CHECK CONSTRAINT [FK_RolProcesoVista_RolProceso]
GO
ALTER TABLE [dbo].[RolProcesoVista]  WITH CHECK ADD  CONSTRAINT [FK_RolProcesoVista_Vista] FOREIGN KEY([VistaID])
REFERENCES [dbo].[Vista] ([VistaID])
GO
ALTER TABLE [dbo].[RolProcesoVista] CHECK CONSTRAINT [FK_RolProcesoVista_Vista]
GO
ALTER TABLE [dbo].[RolProcesoVistaTipoAcceso]  WITH CHECK ADD  CONSTRAINT [FK_RolProcesoVistaTipoAcceso_RolProcesoVista] FOREIGN KEY([RolProcesoVistaID])
REFERENCES [dbo].[RolProcesoVista] ([RolProcesoVistaID])
GO
ALTER TABLE [dbo].[RolProcesoVistaTipoAcceso] CHECK CONSTRAINT [FK_RolProcesoVistaTipoAcceso_RolProcesoVista]
GO
ALTER TABLE [dbo].[RolProcesoVistaTipoAcceso]  WITH CHECK ADD  CONSTRAINT [FK_RolProcesoVistaTipoAcceso_TipoAcceso] FOREIGN KEY([TipoAccesoID])
REFERENCES [dbo].[TipoAcceso] ([TipoAccesoID])
GO
ALTER TABLE [dbo].[RolProcesoVistaTipoAcceso] CHECK CONSTRAINT [FK_RolProcesoVistaTipoAcceso_TipoAcceso]
GO
ALTER TABLE [dbo].[Subarea]  WITH CHECK ADD  CONSTRAINT [FK_Subarea_NivelAtencion] FOREIGN KEY([NivelAtencionID])
REFERENCES [dbo].[NivelAtencion] ([NivelAtencionID])
GO
ALTER TABLE [dbo].[Subarea] CHECK CONSTRAINT [FK_Subarea_NivelAtencion]
GO
ALTER TABLE [dbo].[Subarea]  WITH CHECK ADD  CONSTRAINT [FK_Subarea_NivelOrganizacional] FOREIGN KEY([NivelOrganizacionalID])
REFERENCES [dbo].[NivelOrganizacional] ([NivelOrganizacionalID])
GO
ALTER TABLE [dbo].[Subarea] CHECK CONSTRAINT [FK_Subarea_NivelOrganizacional]
GO
ALTER TABLE [dbo].[TipoEvidencia]  WITH CHECK ADD  CONSTRAINT [FK_TipoEvidencia_AcreditadoraProces] FOREIGN KEY([AcreditadoraProcesoID])
REFERENCES [dbo].[AcreditadoraProceso] ([AcreditadoraProcesoID])
GO
ALTER TABLE [dbo].[TipoEvidencia] CHECK CONSTRAINT [FK_TipoEvidencia_AcreditadoraProces]
GO
ALTER TABLE [dbo].[TipoEvidencia]  WITH CHECK ADD  CONSTRAINT [FK_TipoEvidencia_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO
ALTER TABLE [dbo].[TipoEvidencia] CHECK CONSTRAINT [FK_TipoEvidencia_Region]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([PerfilID])
REFERENCES [dbo].[Perfil] ([PerfilID])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
ALTER TABLE [dbo].[UsuarioAreaCorporativa]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioAreaCorporativa_AreaCorporativa] FOREIGN KEY([AreaCorporativaID])
REFERENCES [dbo].[AreaCorporativa] ([AreaCorporativaID])
GO
ALTER TABLE [dbo].[UsuarioAreaCorporativa] CHECK CONSTRAINT [FK_UsuarioAreaCorporativa_AreaCorporativa]
GO
ALTER TABLE [dbo].[UsuarioAreaCorporativa]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioAreaCorporativa_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[UsuarioAreaCorporativa] CHECK CONSTRAINT [FK_UsuarioAreaCorporativa_Usuario]
GO
ALTER TABLE [dbo].[UsuarioAreaResponsable]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioAreaResponsable_AreaResponsable] FOREIGN KEY([AreaResponsableID])
REFERENCES [dbo].[AreaResponsable] ([AreaResponsableID])
GO
ALTER TABLE [dbo].[UsuarioAreaResponsable] CHECK CONSTRAINT [FK_UsuarioAreaResponsable_AreaResponsable]
GO
ALTER TABLE [dbo].[UsuarioAreaResponsable]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioAreaResponsable_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[UsuarioAreaResponsable] CHECK CONSTRAINT [FK_UsuarioAreaResponsable_Usuario]
GO
ALTER TABLE [dbo].[UsuarioCampus]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCampus_Campus] FOREIGN KEY([CampusID])
REFERENCES [dbo].[Campus] ([CampusID])
GO
ALTER TABLE [dbo].[UsuarioCampus] CHECK CONSTRAINT [FK_UsuarioCampus_Campus]
GO
ALTER TABLE [dbo].[UsuarioCampus]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCampus_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[UsuarioCampus] CHECK CONSTRAINT [FK_UsuarioCampus_Usuario]
GO
ALTER TABLE [dbo].[UsuarioNivelModalidad]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioNivelModalidad_NivelModalidad] FOREIGN KEY([NivelModalidadID])
REFERENCES [dbo].[NivelModalidad] ([NivelModalidadID])
GO
ALTER TABLE [dbo].[UsuarioNivelModalidad] CHECK CONSTRAINT [FK_UsuarioNivelModalidad_NivelModalidad]
GO
ALTER TABLE [dbo].[UsuarioNivelModalidad]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioNivelModalidad_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[UsuarioNivelModalidad] CHECK CONSTRAINT [FK_UsuarioNivelModalidad_Usuario]
GO
ALTER TABLE [dbo].[UsuarioRegion]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRegion_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO
ALTER TABLE [dbo].[UsuarioRegion] CHECK CONSTRAINT [FK_UsuarioRegion_Region]
GO
ALTER TABLE [dbo].[UsuarioRegion]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRegion_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[UsuarioRegion] CHECK CONSTRAINT [FK_UsuarioRegion_Usuario]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Rol] FOREIGN KEY([RolID])
REFERENCES [dbo].[Rol] ([RolID])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Rol]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Usuario]
GO
ALTER TABLE [dbo].[UsuarioRolProceso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProceso_Carrera] FOREIGN KEY([CarreraID])
REFERENCES [dbo].[Carrera] ([CarreraID])
GO
ALTER TABLE [dbo].[UsuarioRolProceso] CHECK CONSTRAINT [FK_UsuarioRolProceso_Carrera]
GO
ALTER TABLE [dbo].[UsuarioRolProceso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProceso_RolProceso] FOREIGN KEY([AcreditadoraProcesoID], [RolProcesoID])
REFERENCES [dbo].[RolProceso] ([AcreditadoraProcesoID], [RolProcesoID])
GO
ALTER TABLE [dbo].[UsuarioRolProceso] CHECK CONSTRAINT [FK_UsuarioRolProceso_RolProceso]
GO
ALTER TABLE [dbo].[UsuarioRolProceso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProceso_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[UsuarioRolProceso] CHECK CONSTRAINT [FK_UsuarioRolProceso_Usuario]
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCampus]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProcesoCampus_Campus] FOREIGN KEY([CampusID])
REFERENCES [dbo].[Campus] ([CampusID])
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCampus] CHECK CONSTRAINT [FK_UsuarioRolProcesoCampus_Campus]
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCampus]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProcesoCampus_UsuarioRolProceso] FOREIGN KEY([UsuarioID], [AcreditadoraProcesoID], [RolProcesoID], [CarreraID])
REFERENCES [dbo].[UsuarioRolProceso] ([UsuarioID], [AcreditadoraProcesoID], [RolProcesoID], [CarreraID])
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCampus] CHECK CONSTRAINT [FK_UsuarioRolProcesoCampus_UsuarioRolProceso]
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCapitulo]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProcesoCapitulo_Capitulo] FOREIGN KEY([AcreditadoraProcesoID], [CapituloID])
REFERENCES [dbo].[Capitulo] ([AcreditadoraProcesoID], [CapituloID])
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCapitulo] CHECK CONSTRAINT [FK_UsuarioRolProcesoCapitulo_Capitulo]
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCapitulo]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProcesoCapitulo_UsuarioRolProceso] FOREIGN KEY([UsuarioID], [AcreditadoraProcesoID], [RolProcesoID], [CarreraID])
REFERENCES [dbo].[UsuarioRolProceso] ([UsuarioID], [AcreditadoraProcesoID], [RolProcesoID], [CarreraID])
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCapitulo] CHECK CONSTRAINT [FK_UsuarioRolProcesoCapitulo_UsuarioRolProceso]
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCriterio]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProcesoCriterio_Criterio] FOREIGN KEY([AcreditadoraProcesoID], [CriterioID], [CarreraID])
REFERENCES [dbo].[Criterio] ([AcreditadoraProcesoID], [CriterioID], [CarreraID])
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCriterio] CHECK CONSTRAINT [FK_UsuarioRolProcesoCriterio_Criterio]
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCriterio]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRolProcesoCriterio_UsuarioRolProceso] FOREIGN KEY([UsuarioID], [AcreditadoraProcesoID], [RolProcesoID], [CarreraID])
REFERENCES [dbo].[UsuarioRolProceso] ([UsuarioID], [AcreditadoraProcesoID], [RolProcesoID], [CarreraID])
GO
ALTER TABLE [dbo].[UsuarioRolProcesoCriterio] CHECK CONSTRAINT [FK_UsuarioRolProcesoCriterio_UsuarioRolProceso]
GO
ALTER TABLE [dbo].[VistaRolProceso]  WITH CHECK ADD  CONSTRAINT [FK_VistaRolProceso_RolProceso] FOREIGN KEY([AcreditadoraProcesoID], [RolProcesoID])
REFERENCES [dbo].[RolProceso] ([AcreditadoraProcesoID], [RolProcesoID])
GO
ALTER TABLE [dbo].[VistaRolProceso] CHECK CONSTRAINT [FK_VistaRolProceso_RolProceso]
GO
ALTER TABLE [dbo].[VistaRolProceso]  WITH CHECK ADD  CONSTRAINT [FK_VistaRolProceso_Vista] FOREIGN KEY([VistaID])
REFERENCES [dbo].[Vista] ([VistaID])
GO
ALTER TABLE [dbo].[VistaRolProceso] CHECK CONSTRAINT [FK_VistaRolProceso_Vista]
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Acreditora]    Script Date: 02/06/2023 05:00:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SP_Actualizar_Acreditora]
(
    -- Add the parameters for the stored procedure here
	@AcreditadoraID int ,
	@Nombre nvarchar(500),
	@FechaModificacion datetime,
	@UsuarioModificacion nvarchar(50),
	@EsFimpes bit NULL,
	@id int OUTPUT,
	@exito int OUTPUT,
	@mensaje nvarchar(max) OUTPUT
)
AS
BEGIN TRY
	DECLARE @IdNuevo int = ISNULL((select max(AcreditadoraID) from Acreditadora),0) ;
	
	UPDATE [dbo].[Acreditadora] SET 	
		Nombre = @Nombre, 
		FechaModificacion = @FechaModificacion,
		UsuarioModificacion = @UsuarioModificacion,
		EsFimpes = @EsFimpes
		WHERE 
		AcreditadoraID = @AcreditadoraID
	
	SET @id = @AcreditadoraID
	SET @exito = 1
	SET @mensaje = 'Se actualizó correctamente'

  END TRY
  BEGIN CATCH
	SET @id = 0
	SET @exito = 0
	SET @mensaje = ERROR_MESSAGE()

	

	--SE PUEDE CONSIDERAR UNA TABLA PARA ERRORES
	  --  INSERT INTO dbo.DB_Errors
	  --  VALUES
	  --(SUSER_SNAME(),
	  -- ERROR_NUMBER(),
	  -- ERROR_STATE(),
	  -- ERROR_SEVERITY(),
	  -- ERROR_LINE(),
	  -- ERROR_PROCEDURE(),
	  -- ERROR_MESSAGE(),
	  -- GETDATE());
  END CATCH
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_Acreditora]    Script Date: 02/06/2023 05:00:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Add_Acreditora]
            @Nombre nvarchar(500),
			--@Activo bit,
			@FechaCreacion datetime,
			@UsuarioCreacion nvarchar(50),
			--@FechaModificacion datetime NULL,
			--@UsuarioModificacion nvarchar(50) NULL,
			@EsFimpes bit NULL,
			@id int output
        AS

        BEGIN
			DECLARE @IdNuevo int = ISNULL((select max(AcreditadoraID) from Acreditadora),0) ;
			

			INSERT INTO [dbo].[Acreditadora] (AcreditadoraID, Nombre, Activo,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion,EsFimpes)
			SELECT (@IdNuevo+1), @Nombre, 1, @FechaCreacion, @UsuarioCreacion, NULL, NULL, @EsFimpes

			SET @id = @IdNuevo
        END
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Acreditora]    Script Date: 02/06/2023 05:00:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SP_Eliminar_Acreditora]
(
    -- Add the parameters for the stored procedure here
	@AcreditadoraID int,
	@id int OUTPUT,
	@exito int OUTPUT,
	@mensaje nvarchar(max) OUTPUT
)
AS
BEGIN TRY
	
	UPDATE [dbo].[Acreditadora] SET 	
		Activo = 0
		WHERE 
		AcreditadoraID = @AcreditadoraID
	
	SET @id = @AcreditadoraID
	SET @exito = 1
	SET @mensaje = 'Se eliminó correctamente'

  END TRY
  BEGIN CATCH
	SET @id = 0
	SET @exito = 0
	SET @mensaje = ERROR_MESSAGE()

	

	--SE PUEDE CONSIDERAR UNA TABLA PARA ERRORES
	  --  INSERT INTO dbo.DB_Errors
	  --  VALUES
	  --(SUSER_SNAME(),
	  -- ERROR_NUMBER(),
	  -- ERROR_STATE(),
	  -- ERROR_SEVERITY(),
	  -- ERROR_LINE(),
	  -- ERROR_PROCEDURE(),
	  -- ERROR_MESSAGE(),
	  -- GETDATE());
  END CATCH
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_Acreditora]    Script Date: 02/06/2023 05:00:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[SP_Insertar_Acreditora]
(
    -- Add the parameters for the stored procedure here
	@Nombre nvarchar(500),
	@FechaCreacion datetime,
	@UsuarioCreacion nvarchar(50),
	@EsFimpes bit NULL,
	@id int OUTPUT,
	@exito int OUTPUT,
	@mensaje nvarchar(max) OUTPUT
)
AS
BEGIN TRY
	DECLARE @IdNuevo int = ISNULL((select max(AcreditadoraID) from Acreditadora),0) ;
	
	INSERT INTO [dbo].[Acreditadora] (
		AcreditadoraID, 
		Nombre, 
		Activo,
		FechaCreacion,
		UsuarioCreacion,
		FechaModificacion,
		UsuarioModificacion,
		EsFimpes)
	SELECT 
		(@IdNuevo+1), 
		@Nombre, 
		1, 
		@FechaCreacion, 
		@UsuarioCreacion, 
		NULL, 
		NULL, 
		@EsFimpes
	
	SET @id = @IdNuevo
	SET @exito = 1
	SET @mensaje = 'Se agregó correctamente'

  END TRY
  BEGIN CATCH
	SET @id = 0
	SET @exito = 0
	SET @mensaje = ERROR_MESSAGE()




	--SE PUEDE CONSIDERAR UNA TABLA PARA ERRORES
	  --  INSERT INTO dbo.DB_Errors
	  --  VALUES
	  --(SUSER_SNAME(),
	  -- ERROR_NUMBER(),
	  -- ERROR_STATE(),
	  -- ERROR_SEVERITY(),
	  -- ERROR_LINE(),
	  -- ERROR_PROCEDURE(),
	  -- ERROR_MESSAGE(),
	  -- GETDATE());
  END CATCH
GO
/****** Object:  StoredProcedure [dbo].[SP_SeleccionarAcreditora]    Script Date: 02/06/2023 05:00:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_SeleccionarAcreditora]
            @id int null,
			@numPagina int,
			@numRegistros int
        AS
        BEGIN
			SELECT 
			   [AcreditadoraID]
			  ,[Nombre]
			  ,[Activo]
			  ,[FechaCreacion]
			  ,[UsuarioCreacion]
			  ,[FechaModificacion]
			  ,[UsuarioModificacion]
			  ,[EsFimpes]
		  FROM [dbo].[Acreditadora]
			WHERE 
				AcreditadoraID = @id or @id is null
				and Activo = 1
			ORDER BY AcreditadoraID
			OFFSET @numPagina*@numRegistros ROWS
			FETCH NEXT @numRegistros ROW ONLY


        END
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectAcreditora]    Script Date: 02/06/2023 05:00:56 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_SelectAcreditora]
            @id int null,
			@numPagina int,
			@numRegistros int
        AS
        BEGIN
			SELECT 
			   [AcreditadoraID]
			  ,[Nombre]
			  ,[Activo]
			  ,[FechaCreacion]
			  ,[UsuarioCreacion]
			  ,[FechaModificacion]
			  ,[UsuarioModificacion]
			  ,[EsFimpes]
		  FROM [dbo].[Acreditadora]
			WHERE 
				AcreditadoraID = @id or @id is null
			ORDER BY AcreditadoraID
			OFFSET @numPagina*@numRegistros ROWS
			FETCH NEXT @numRegistros ROW ONLY


        END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Siglas de identificación única para la acreditadora.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acreditadora', @level2type=N'COLUMN',@level2name=N'AcreditadoraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la acreditadora.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acreditadora', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador de activo/inactivo para el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acreditadora', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acreditadora', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acreditadora', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acreditadora', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que realizó la última modificación sobre el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acreditadora', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de Acreditadoras' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Acreditadora'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la acreditadora a la que perteneces este proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'AcreditadoraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del proceso. Usualmente es un año seguido de un ciclo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de inicio del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'FechaInicio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de fin del proceso. Limite para generar y documentar evidencias.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'FechaFin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que realizó la última modificación sobre el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de procesos por acreditadora.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AcreditadoraProceso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del apartado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'ApartadoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del padre de este apartado. NULL en caso de ser un apartado de primer nivel.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'ApartadoPadre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece este apartado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del criterio al que se asocia este apartado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'CriterioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la carrera a la que se asocia este apartado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Titulo del apartado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'Titulo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido en HTML del apartado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'Especificaciones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica el orden de despliegue de los apartados. Se ordenan de menor a mayor, agrupados por niveles herárquicos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'Orden'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apartados del libro electrónico.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Apartado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única de la área corporativa.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaCorporativa', @level2type=N'COLUMN',@level2name=N'AreaCorporativaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la área corporativa.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaCorporativa', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaCorporativa', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaCorporativa', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaCorporativa', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaCorporativa', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaCorporativa', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de la área corporativa.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaCorporativa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece esta área.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Siglas de la área de responsabilidad dentro del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'AreaResponsabilidadID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del área de responsabilidad.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del nivel de atención asociado a esta área.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'NivelAtencionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del nivel de organizacional asociado a esta área.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'NivelOrganizacionalID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de áreas de reponsabilidad.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsabilidad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única del Área responsable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'AreaResponsableID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del área responsable' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del Área responsable padre al que pertenece este Área responsable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'AreaResponsablePadre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el Área responsable es genérica.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'Generica'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si la información se va a consolidar los resultados de la etapa de Autoevaluación.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'Consolidacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de áreas responsables.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaResponsable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única del campus. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus', @level2type=N'COLUMN',@level2name=N'CampusID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del campus.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Región a la que pertenece este campus.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus', @level2type=N'COLUMN',@level2name=N'RegionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de campus.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Campus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece este cápitulo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número del cápitulo dentro del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo', @level2type=N'COLUMN',@level2name=N'CapituloID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del cápitulo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción larga del cápitulo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de cápitulos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Capitulo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Siglas de identificación única para la carrera.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre descriptivo de la carrera.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Plan de la carrera.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera', @level2type=N'COLUMN',@level2name=N'Plan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador de activo/inactivo para el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que realizó la última modificación sobre el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de carreras.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carrera'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del ciclo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ciclo', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única del ciclo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ciclo', @level2type=N'COLUMN',@level2name=N'CicloID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ciclo', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ciclo', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ciclo', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ciclo', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de ciclos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ciclo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del comentario de seguimiento.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'ComentarioSeguimientoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece este comentario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la carrera a la que se asocia este comentario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Titulo del comentario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'Titulo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido del comentario. Texto abierto.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'Contenido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comentarios de seguimiento sobre un proceso de acreditación.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ComentarioSeguimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro de configuración.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConfiguracionSistema', @level2type=N'COLUMN',@level2name=N'ConfiguracionSistemaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mensaje de bienvenida en el portal FIMPES' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConfiguracionSistema', @level2type=N'COLUMN',@level2name=N'MensajeBienvenida'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL donde se puedes descargar el manual de la plataforma FIMPES' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConfiguracionSistema', @level2type=N'COLUMN',@level2name=N'UrlManual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Configuración de mensaje de mensaje de bienvenida.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ConfiguracionSistema'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece este criterio.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número del criterio dentro del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'CriterioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la carrera a la que se asocia este criterio. Null significa que no aplica.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del cápitulo al que se asocia este criterio.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'CapituloID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del tipo de evidencia que se usará para este criterio.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'TipoEvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción larga del criterio.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de Criterios por Proceso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Criterio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece esta evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'CriterioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número del evidencia dentro del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'EvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción larga de la evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Especificaciones para capturar la evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'Especificaciones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha compromiso para el registro de las evidencias. Debe ser inferior a la fecha de fin del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'FechaCompromiso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del responsable general de estas evidencias.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'Responsable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indice de evidencias por proceso y carrera.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Evidencia'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relación entre evidencias y años' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaAnio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece esta evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaCampus', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaCampus', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaCampus', @level2type=N'COLUMN',@level2name=N'CriterioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número del evidencia dentro del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaCampus', @level2type=N'COLUMN',@level2name=N'EvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relación entre evidencias y campuses.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaCampus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relación entre evidencias y ciclos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaCiclo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece esta evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaSubarea', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaSubarea', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaSubarea', @level2type=N'COLUMN',@level2name=N'CriterioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número del evidencia dentro del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaSubarea', @level2type=N'COLUMN',@level2name=N'EvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relación entre evidencias y subáreas.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EvidenciaSubarea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única del nivel de atención. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelAtencion', @level2type=N'COLUMN',@level2name=N'NivelAtencionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del nivel de atención.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelAtencion', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelAtencion', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelAtencion', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelAtencion', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelAtencion', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelAtencion', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de niveles de atención.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelAtencion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Siglas de identificación única para la Nivel/Modalidad.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad', @level2type=N'COLUMN',@level2name=N'NivelModalidadID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nivel  de Nivel/Modalidad.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad', @level2type=N'COLUMN',@level2name=N'Nivel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Modalidad de Nivel/Modalidad.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad', @level2type=N'COLUMN',@level2name=N'Modalidad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador de activo/inactivo para el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que realizó la última modificación sobre el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de Nivel/Modalidad' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelModalidad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única del nivel organizacional. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelOrganizacional', @level2type=N'COLUMN',@level2name=N'NivelOrganizacionalID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del nivel organizacional.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelOrganizacional', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelOrganizacional', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelOrganizacional', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelOrganizacional', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelOrganizacional', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelOrganizacional', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de niveles organizacionales.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NivelOrganizacional'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única del región. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Region', @level2type=N'COLUMN',@level2name=N'RegionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del región.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Region', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Region', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Region', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Region', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Region', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Region', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de regiones.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Region'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador unico del registro de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'RegistroEvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece esta evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'CriterioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número del evidencia dentro del proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'EvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave de subárea a la cual se asocia este registro de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'SubareaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave de campus a la cual se asocia este registro de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'CampusID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Año asignado a este registro de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'AnioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ciclo asignado a este registro de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'CicloID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si la evidencia ya fue registrada y esta lista para ser validada.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'EsCargada'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si la evidencia fue aceptada y ya solo puede ser editada por el validador.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'EsAceptada'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla donde se generan los registros de evidencia en base los indices.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidencia'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del archivo registrado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'RegistroEvidenciaArchivoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'RegistroEvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece este archivo de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la carrera a la que se asocia este archivo de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'CarreraID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del criterio al que se asocia este archivo de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'CriterioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número del evidencia dentro del proceso al que pertence este archivo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'EvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la subárea a la que pertence este archivo de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'SubareaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del campus al que pertenece este archivo de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'CampusID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador de si el registro es un archivo o una URL.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'EsUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'En el caso de archivos, el nombre físico del archivo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'NombreArchivo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'En el caso de archivos, el mime type del tipo de archivo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'Mime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'En caso de ser URL, esta es la dirección de la evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de archivos registrados como evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RegistroEvidenciaArchivo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del rol.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol', @level2type=N'COLUMN',@level2name=N'RolID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del rol.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del rol.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol', @level2type=N'COLUMN',@level2name=N'Descripción'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de roles del sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Rol'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece este rol.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProceso', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del rol para el proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProceso', @level2type=N'COLUMN',@level2name=N'RolProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del rol.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProceso', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProceso', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProceso', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProceso', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProceso', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de Roles por Proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProceso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único de la relación rol y vista.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProcesoVista', @level2type=N'COLUMN',@level2name=N'RolProcesoVistaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del rol.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProcesoVista', @level2type=N'COLUMN',@level2name=N'RolProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la vista.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProcesoVista', @level2type=N'COLUMN',@level2name=N'VistaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de Vistas por Rol.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProcesoVista'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asociación entre rol, vista y tipo de acceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolProcesoVistaTipoAcceso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única de la sede. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sede', @level2type=N'COLUMN',@level2name=N'SedeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la sede.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sede', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sede', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sede', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sede', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sede', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sede', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de sedes.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sede'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única de la subarea. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'SubareaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la subarea.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nivel organizacional al que pertence esta subarea.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'NivelOrganizacionalID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nivel de atención al que pertence esta subarea.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'NivelAtencionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de subareas.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Subarea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del tipo de acceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso', @level2type=N'COLUMN',@level2name=N'TipoAccesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del tipo acceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del tipo acceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de tipo de acceso del sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoAcceso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece este tipo de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clave única del tipo de evidencia. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'TipoEvidenciaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del tipo de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Región a la que pertenece este tipo de evidencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'RegionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Catálogo de tipo de evidencias.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoEvidencia'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del usuario en el directorio activo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre(s) del usuario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apellido paterno del usaurio.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Apellidos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo electrónico del usuario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Correo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si el registro se encuentra activo en el sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'Activo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de usaurios del sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asociación entre usuarios y roles del sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRol'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProceso', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso de acreditación.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProceso', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del rol asociado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProceso', @level2type=N'COLUMN',@level2name=N'RolProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProceso', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProceso', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProceso', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que realizó la última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProceso', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asociación entre usuarios y roles por proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProceso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCampus', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso de acreditación.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCampus', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del rol asociado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCampus', @level2type=N'COLUMN',@level2name=N'RolProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del campus.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCampus', @level2type=N'COLUMN',@level2name=N'CampusID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asociación entre usuario, rol y campus.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCampus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCapitulo', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso de acreditación.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCapitulo', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del rol asociado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCapitulo', @level2type=N'COLUMN',@level2name=N'RolProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del capitulo.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCapitulo', @level2type=N'COLUMN',@level2name=N'CapituloID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asociación entre usaurio, rol y captíulos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCapitulo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCriterio', @level2type=N'COLUMN',@level2name=N'UsuarioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso de acreditación.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCriterio', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del rol asociado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCriterio', @level2type=N'COLUMN',@level2name=N'RolProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del criterio' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCriterio', @level2type=N'COLUMN',@level2name=N'CriterioID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asociación entre usaurio, rol y captíulos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuarioRolProcesoCriterio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador interno de la vista.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vista', @level2type=N'COLUMN',@level2name=N'VistaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre público de la vista.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vista', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que fue creado el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vista', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que generó el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vista', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vista', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario de última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vista', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listado de vistas existentes en la plataforma.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vista'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del proceso al que pertenece este rol.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VistaRolProceso', @level2type=N'COLUMN',@level2name=N'AcreditadoraProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del rol para el proceso.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VistaRolProceso', @level2type=N'COLUMN',@level2name=N'RolProcesoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asociación entre vistas y roles.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VistaRolProceso'
GO
ALTER DATABASE [DBSIAC-Dev-UVM] SET  READ_WRITE 
GO
