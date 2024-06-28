USE [pcm_icp_seg]
GO
/****** Object:  Table [dbo].[BLOQUEOUSUARIO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BLOQUEOUSUARIO](
	[bloqueousuario_id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_id] [int] NULL,
	[fecha_bloqueo] [datetime] NULL,
	[fecha_desbloqueo] [datetime] NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuactio_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[bloqueousuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOG_ACCESO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOG_ACCESO](
	[logacceso_id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_id] [int] NULL,
	[username] [varchar](20) NULL,
	[password] [varchar](15) NULL,
	[login_exitoso] [bit] NULL,
	[login_fecha] [datetime] NULL,
	[login_message] [varchar](500) NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuactio_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[logacceso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOG_BLOQUEO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOG_BLOQUEO](
	[logbloqueo_id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_id] [int] NULL,
	[fecha_bloqueo] [datetime] NULL,
	[fecha_desbloqueo] [datetime] NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuactio_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[logbloqueo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OPCIONPERMISOS]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPCIONPERMISOS](
	[opcionpermiso_id] [int] IDENTITY(1,1) NOT NULL,
	[perfilopcion_id] [int] NULL,
	[permiso_id] [int] NULL,
	[habilitado] [bit] NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuario_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[opcionpermiso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERFIL]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERFIL](
	[perfil_id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](10) NULL,
	[abreviatura] [varchar](50) NULL,
	[descripcion] [varchar](150) NULL,
	[interno] [bit] NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuario_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
 CONSTRAINT [PK__PERFIL__638DD32C3B43AA4B] PRIMARY KEY CLUSTERED 
(
	[perfil_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERFILOPCION]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERFILOPCION](
	[perfilopcion_id] [int] IDENTITY(1,1) NOT NULL,
	[perfil_id] [int] NOT NULL,
	[sistemaopcion_id] [int] NOT NULL,
	[habilitado] [bit] NOT NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuario_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[perfilopcion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERMISOS]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISOS](
	[permiso_id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](10) NULL,
	[nombre] [varchar](50) NULL,
	[descripcion] [varchar](150) NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuario_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
 CONSTRAINT [PK__PERMISOS__60B569CD040C4793] PRIMARY KEY CLUSTERED 
(
	[permiso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SISTEMAOPCION]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SISTEMAOPCION](
	[sistemaopcion_id] [int] IDENTITY(1,1) NOT NULL,
	[padre_id] [int] NULL,
	[codigo] [varchar](10) NULL,
	[abreviatura] [varchar](50) NULL,
	[descripcion] [varchar](150) NULL,
	[num_orden] [int] NULL,
	[url_opcion] [varchar](250) NULL,
	[icono_opcion] [varchar](50) NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuario_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
 CONSTRAINT [PK__SISTEMAO__447E12DF1C864108] PRIMARY KEY CLUSTERED 
(
	[sistemaopcion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[persona_id] [int] NULL,
	[username] [varchar](20) NULL,
	[password] [varchar](150) NULL,
	[numdocumento] [varchar](20) NULL,
	[nombre_completo] [varchar](100) NULL,
	[interno] [bit] NULL,
	[habilitado] [bit] NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuario_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
 CONSTRAINT [PK__USUARIO__2ED7D2AF33C5DD61] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOPERFIL]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOPERFIL](
	[usuarioperfil_id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_id] [int] NULL,
	[perfil_id] [int] NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuario_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[usuarioperfil_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OPCIONPERMISOS] ON 
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (2, 2, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (3, 2, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (4, 2, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (5, 2, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (6, 2, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (7, 3, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (8, 3, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (9, 3, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (10, 3, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (11, 3, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (12, 4, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (13, 4, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (14, 4, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (15, 4, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (16, 4, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (17, 5, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (18, 5, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (19, 5, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (20, 5, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (21, 5, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (22, 6, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (23, 6, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (24, 6, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (25, 6, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (26, 6, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (27, 7, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (28, 8, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (29, 9, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (30, 9, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (31, 9, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (32, 10, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (33, 11, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (34, 11, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (35, 11, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (36, 11, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (37, 11, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (38, 12, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (39, 12, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (40, 12, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (41, 13, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (42, 13, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (43, 13, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (44, 13, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (45, 13, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (46, 13, 19, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (47, 14, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (48, 15, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (49, 15, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (50, 15, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (51, 15, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (52, 15, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (53, 16, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (54, 16, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (55, 16, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (56, 16, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (57, 16, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (58, 17, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (59, 17, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (60, 17, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (61, 17, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (62, 17, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (63, 18, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (64, 18, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (65, 18, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (66, 18, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (67, 19, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (68, 20, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (69, 21, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (70, 22, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (71, 23, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (72, 23, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (73, 23, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (74, 23, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (75, 23, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (76, 24, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (77, 25, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (78, 26, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (79, 26, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (80, 26, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (81, 26, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (82, 27, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (83, 27, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (84, 27, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (85, 27, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (86, 27, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (87, 28, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (88, 29, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (89, 30, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (90, 31, 11, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (91, 31, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (92, 31, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (93, 31, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (94, 31, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (95, 32, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (96, 32, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (97, 32, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (98, 32, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (99, 33, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (100, 33, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (101, 33, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (102, 33, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (103, 34, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (104, 35, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (105, 36, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (106, 37, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (107, 37, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (108, 37, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (109, 37, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (110, 38, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (111, 39, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (112, 40, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (113, 41, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (114, 41, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (115, 42, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (116, 42, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (117, 42, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (118, 42, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (119, 42, 20, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (120, 42, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (121, 43, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (122, 44, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (123, 45, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (124, 45, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (125, 46, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (126, 47, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (127, 47, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (128, 48, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (129, 49, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (130, 49, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (131, 50, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (132, 51, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (133, 51, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (134, 51, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (135, 51, 20, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (136, 51, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (137, 52, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (138, 53, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (139, 54, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (140, 55, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (141, 55, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[OPCIONPERMISOS] ([opcionpermiso_id], [perfilopcion_id], [permiso_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (142, 55, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:25:57.520' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[OPCIONPERMISOS] OFF
GO
SET IDENTITY_INSERT [dbo].[PERFIL] ON 
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (1, N'00001', N'Admin', N'Administrador', 1, 1, N'sys', CAST(N'2024-06-03T15:43:34.653' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (2, N'00002', N'Sectorista', N'Sectorista', 1, 1, N'sys', CAST(N'2024-06-03T15:46:14.130' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (3, N'00004', N'Supervisor', N'Supervisor', 1, 1, N'sys', CAST(N'2024-06-18T23:48:49.310' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (4, N'00005', N'Coordinador AT', N'Coordinador de asistencias técnicas', 1, 1, N'sys', CAST(N'2024-06-20T11:40:59.013' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (5, N'00006', N'Coordinador EV', N'Coordinador de Evaluación', 1, 1, N'sys', CAST(N'2024-06-20T11:40:59.013' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (6, N'00007', N'Evaluador', N'Evaluador', 1, 1, N'sys', CAST(N'2024-06-20T11:40:59.013' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (7, N'00008', N'Sub Monitoreo IP', N'Subsecretaría de Monitoreo de la Integridad Pública', 1, 1, N'sys', CAST(N'2024-06-20T11:40:59.017' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (8, N'00013', N'SIP', N'Secretaria de Integridad Pública', 1, 1, N'sys', CAST(N'2024-06-20T11:46:56.220' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (9, N'00009', N'Oficial', N'Oficial de Integridad', 0, 1, N'sys', CAST(N'2024-06-20T11:40:59.017' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (10, N'00010', N'Operador', N'Operador de la Entidad', 0, 1, N'sys', CAST(N'2024-06-20T11:40:59.017' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (11, N'00011', N'Maxima Autoridad', N'Máxima Autoridad Administrativa', 0, 1, N'sys', CAST(N'2024-06-20T11:40:59.017' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFIL] ([perfil_id], [codigo], [abreviatura], [descripcion], [interno], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (12, N'00012', N'Titutlar', N'Titular', 0, 1, N'sys', CAST(N'2024-06-20T11:40:59.017' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[PERFIL] OFF
GO
SET IDENTITY_INSERT [dbo].[PERFILOPCION] ON 
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (2, 1, 6, 1, 1, N'sys', CAST(N'2024-06-20T13:41:21.560' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (3, 1, 7, 1, 1, N'sys', CAST(N'2024-06-20T13:43:22.730' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (4, 1, 8, 1, 1, N'sys', CAST(N'2024-06-20T13:43:48.757' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (5, 1, 9, 1, 1, N'sys', CAST(N'2024-06-20T13:44:08.667' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (6, 1, 10, 1, 1, N'sys', CAST(N'2024-06-20T13:44:24.627' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (7, 1, 11, 1, 1, N'sys', CAST(N'2024-06-20T13:44:49.570' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (8, 4, 12, 1, 1, N'sys', CAST(N'2024-06-20T13:47:24.667' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (9, 4, 13, 1, 1, N'sys', CAST(N'2024-06-20T13:48:14.357' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (10, 4, 17, 1, 1, N'sys', CAST(N'2024-06-20T13:49:20.853' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (11, 2, 9, 1, 1, N'sys', CAST(N'2024-06-20T13:50:52.663' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (12, 2, 12, 1, 1, N'sys', CAST(N'2024-06-20T13:51:55.523' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (13, 2, 13, 1, 1, N'sys', CAST(N'2024-06-20T13:52:27.470' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (14, 2, 17, 1, 1, N'sys', CAST(N'2024-06-20T13:53:39.910' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (15, 5, 11, 1, 1, N'sys', CAST(N'2024-06-20T13:55:19.900' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (16, 5, 14, 1, 1, N'sys', CAST(N'2024-06-20T13:56:23.573' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (17, 5, 15, 1, 1, N'sys', CAST(N'2024-06-20T13:56:44.843' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (18, 5, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:00:09.380' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (19, 5, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:00:54.563' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (20, 5, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:01:17.220' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (21, 5, 19, 1, 1, N'sys', CAST(N'2024-06-20T14:01:36.553' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (22, 6, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:03:14.213' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (23, 6, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:04:34.400' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (24, 6, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:05:23.207' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (25, 6, 19, 1, 1, N'sys', CAST(N'2024-06-20T14:05:39.723' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (26, 3, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:07:36.963' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (27, 3, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:08:05.950' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (28, 7, 10, 1, 1, N'sys', CAST(N'2024-06-20T14:13:36.280' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (29, 7, 12, 1, 1, N'sys', CAST(N'2024-06-20T14:13:48.693' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (30, 7, 13, 1, 1, N'sys', CAST(N'2024-06-20T14:13:59.797' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (31, 7, 14, 1, 1, N'sys', CAST(N'2024-06-20T14:14:18.970' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (32, 7, 15, 1, 1, N'sys', CAST(N'2024-06-20T14:14:42.643' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (33, 7, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:15:10.590' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (34, 7, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:15:25.633' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (35, 7, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:15:33.700' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (36, 7, 19, 1, 1, N'sys', CAST(N'2024-06-20T14:15:43.543' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (37, 8, 16, 1, 1, N'sys', CAST(N'2024-06-20T14:16:36.473' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (38, 8, 17, 1, 1, N'sys', CAST(N'2024-06-20T14:16:58.450' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (39, 8, 18, 1, 1, N'sys', CAST(N'2024-06-20T14:17:03.827' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (40, 8, 19, 1, 1, N'sys', CAST(N'2024-06-20T14:17:08.237' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (41, 9, 20, 1, 1, N'sys', CAST(N'2024-06-20T14:18:00.463' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (42, 9, 21, 1, 1, N'sys', CAST(N'2024-06-20T14:18:24.703' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (43, 9, 22, 1, 1, N'sys', CAST(N'2024-06-20T14:18:43.333' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (44, 9, 23, 1, 1, N'sys', CAST(N'2024-06-20T14:19:01.647' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (45, 9, 24, 1, 1, N'sys', CAST(N'2024-06-20T14:19:16.650' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (46, 10, 20, 1, 1, N'sys', CAST(N'2024-06-20T14:20:14.717' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (47, 10, 20, 1, 1, N'sys', CAST(N'2024-06-20T14:20:28.303' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (48, 10, 22, 1, 1, N'sys', CAST(N'2024-06-20T14:20:51.067' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (49, 10, 24, 1, 1, N'sys', CAST(N'2024-06-20T14:21:19.770' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (50, 11, 20, 1, 1, N'sys', CAST(N'2024-06-20T14:22:05.343' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (51, 11, 21, 1, 1, N'sys', CAST(N'2024-06-20T14:22:21.043' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (52, 11, 22, 1, 1, N'sys', CAST(N'2024-06-20T14:22:39.600' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (53, 11, 23, 1, 1, N'sys', CAST(N'2024-06-20T14:22:51.307' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (54, 12, 20, 1, 1, N'sys', CAST(N'2024-06-20T14:23:26.347' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (55, 12, 21, 1, 1, N'sys', CAST(N'2024-06-20T14:24:18.830' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (56, 1, 1, 1, 1, N'x', CAST(N'2024-06-21T01:13:35.070' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (57, 4, 2, 1, 1, N'x', CAST(N'2024-06-21T01:19:56.933' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (58, 4, 4, 1, 1, N'x', CAST(N'2024-06-21T01:20:19.617' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (59, 2, 1, 1, 1, N'x', CAST(N'2024-06-21T01:20:59.317' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (60, 2, 2, 1, 1, N'x', CAST(N'2024-06-21T01:21:18.547' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (61, 2, 4, 1, 1, N'x', CAST(N'2024-06-21T01:21:39.590' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (62, 5, 1, 1, 1, N'x', CAST(N'2024-06-21T01:22:14.020' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (64, 5, 3, 1, 1, N'x', CAST(N'2024-06-21T01:24:49.910' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (65, 5, 4, 1, 1, N'x', CAST(N'2024-06-21T01:25:09.097' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (66, 6, 3, 1, 1, N'x', CAST(N'2024-06-21T01:26:00.160' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (67, 6, 4, 1, 1, N'x', CAST(N'2024-06-21T01:26:22.827' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (68, 3, 3, 1, 1, N'x', CAST(N'2024-06-21T01:27:03.513' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (69, 7, 1, 1, 1, N'x', CAST(N'2024-06-21T01:28:46.930' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (70, 7, 2, 1, 1, N'x', CAST(N'2024-06-21T01:28:46.930' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (71, 7, 3, 1, 1, N'x', CAST(N'2024-06-21T01:28:46.930' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (72, 7, 4, 1, 1, N'x', CAST(N'2024-06-21T01:28:46.930' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (73, 8, 3, 1, 1, N'x', CAST(N'2024-06-21T01:29:48.863' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (74, 8, 4, 1, 1, N'x', CAST(N'2024-06-21T01:30:14.057' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (75, 8, 9, 1, 1, N'x', CAST(N'2024-06-21T01:31:29.917' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (76, 8, 10, 1, 1, N'x', CAST(N'2024-06-21T01:31:29.917' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (77, 8, 11, 1, 1, N'x', CAST(N'2024-06-21T01:31:29.917' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERFILOPCION] ([perfilopcion_id], [perfil_id], [sistemaopcion_id], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (78, 8, 12, 1, 1, N'x', CAST(N'2024-06-21T01:31:29.917' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[PERFILOPCION] OFF
GO
SET IDENTITY_INSERT [dbo].[PERMISOS] ON 
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (11, N'AG', N'Agregar', N'Permite ingresar un nuevo registro según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (12, N'M', N'Modificar', N'Permite modificar cada uno de los registros según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (13, N'E', N'Eliminar', N'Permite eliminar o dar de baja el registro que se desee según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (14, N'C', N'Consultar', N'Permite buscar los registros según los filtros y la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (15, N'EX', N'Exportar', N'Permite exportar los datos según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (16, N'AP', N'Aprobar', N'Permite aprobar los registros según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (17, N'I', N'Imprimir', N'Permite imprimir los datos según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (18, N'F', N'Firmar', N'Permite firmar los datos según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (19, N'IMP', N'Importar', N'Permite importar los registros según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PERMISOS] ([permiso_id], [codigo], [nombre], [descripcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (20, N'EN', N'Enviar', N'Permite enviar los registros según la funcionalidad.', 1, N'sys', CAST(N'2024-06-20T11:36:30.040' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[PERMISOS] OFF
GO
SET IDENTITY_INSERT [dbo].[SISTEMAOPCION] ON 
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (1, NULL, N'00001', N'Administración', N'Administración', 1, NULL, N'bx bx-cube', 1, N'sys', CAST(N'2024-06-20T11:54:48.113' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (2, NULL, N'00002', N'Asistencias Técnicas', N'Asistencias Técnicas', 2, NULL, N'bx bx-wrench', 1, N'sys', CAST(N'2024-06-20T11:54:48.113' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (3, NULL, N'00003', N'Evaluación ICP', N'Evaluación ICP', 3, NULL, N'bx bx-objects-horizontal-right', 1, N'sys', CAST(N'2024-06-20T11:54:48.113' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (4, NULL, N'00004', N'Reportes', N'Reportes', 4, NULL, N'bx bx-bar-chart-alt-2', 1, N'sys', CAST(N'2024-06-20T11:54:48.113' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (5, NULL, N'00005', N'ICP', N'ICP', 5, NULL, N'bx bx-objects-horizontal-right', 1, N'sys', CAST(N'2024-06-20T11:54:48.113' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (6, 1, N'00006', N'Gestión de Usuarios', N'Gestión de Usuarios', 1, N'usuarios', NULL, 1, N'sys', CAST(N'2024-06-20T11:59:22.107' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (7, 1, N'00007', N'Configurar usuarios', N'Configurar usuarios', 2, N'roles', NULL, 1, N'sys', CAST(N'2024-06-20T11:59:22.107' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (8, 1, N'00008', N'Asignar evaluador - supervisor', N'Asignar evaluador - supervisor', 3, N'evaluadores', NULL, 1, N'sys', CAST(N'2024-06-20T11:59:22.107' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (9, 1, N'00009', N'Gestión de datos generales de la entidad', N'Gestión de datos generales de la entidad', 4, N'entidades', NULL, 1, N'sys', CAST(N'2024-06-20T11:59:22.107' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (10, 1, N'00010', N'Asignar entidades a sectortista', N'Asignar entidades a sectortista', 5, N'sectoristasentidad', NULL, 1, N'sys', CAST(N'2024-06-20T11:59:22.107' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (11, 1, N'00011', N'Configurar ficha de evaluación ICP', N'Configurar ficha de evaluación ICP', 6, N'configuracionficha', NULL, 1, N'sys', CAST(N'2024-06-20T11:59:22.107' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (12, 2, N'00012', N'Bandeja de entidades asignadas', N'Bandeja de entidades asignadas', 1, N'entiadesasignadas', NULL, 1, N'sys', CAST(N'2024-06-20T12:09:25.647' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (13, 2, N'00013', N'Registrar asistencia técnica', N'Registrar asistencia técnica', 2, N'asistenciatecnica', NULL, 1, N'sys', CAST(N'2024-06-20T12:09:25.647' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (14, 3, N'00014', N'Asignar ficha ICP por etapa a entidad', N'Asignar ficha ICP por etapa a entidad', 1, N'asignarentidadetapa', NULL, 1, N'sys', CAST(N'2024-06-20T12:10:20.087' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (15, 3, N'00015', N'Asignar ficha ICP por etapa entidad a evaluador', N'Asignar ficha ICP por etapa entidad a evaluador', 2, N'asignarentidadevaluador', NULL, 1, N'sys', CAST(N'2024-06-20T12:10:20.087' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (16, 3, N'00016', N'Ficha de reporte de evaluación ICP', N'Ficha de reporte de evaluación ICP', 3, N'fichareporte', NULL, 1, N'sys', CAST(N'2024-06-20T12:10:20.087' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (17, 4, N'00017', N'Generar reporte de Ficha Informativa de Entidad', N'Generar reporte de Ficha Informativa de Entidad', 1, N'fichainformativa', NULL, 1, N'sys', CAST(N'2024-06-20T12:11:04.177' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (18, 4, N'00018', N'Generar reporte general por filtros', N'Generar reporte general por filtros', 2, N'reportegeneral', NULL, 1, N'sys', CAST(N'2024-06-20T12:11:04.177' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (19, 4, N'00019', N'Generar reporte nacional por filtros', N'Generar reporte nacional por filtros', 3, N'reportenacional', NULL, 1, N'sys', CAST(N'2024-06-20T12:11:04.177' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (20, 5, N'00020', N'Actualizar datos generales de la entidad', N'Actualizar datos generales de la entidad', 1, N'entidadgenerales', NULL, 1, N'sys', CAST(N'2024-06-20T12:13:29.023' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (21, 5, N'00021', N'Actualizar ficha de evaluación ICP', N'Actualizar ficha de evaluación ICP', 2, N'actualizarficha', NULL, 1, N'sys', CAST(N'2024-06-20T12:13:29.023' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (22, 5, N'00022', N'Generar reporte preliminar del ICP', N'Generar reporte preliminar del ICP', 3, N'reportepreliminar', NULL, 1, N'sys', CAST(N'2024-06-20T12:13:29.023' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (23, 5, N'00023', N'Generar reporte final del ICP', N'Generar reporte final del ICP', 4, N'reportefinal', NULL, 1, N'sys', CAST(N'2024-06-20T12:13:29.023' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[SISTEMAOPCION] ([sistemaopcion_id], [padre_id], [codigo], [abreviatura], [descripcion], [num_orden], [url_opcion], [icono_opcion], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (24, 5, N'00024', N'Registrar asistencia a reunión de AT', N'Registrar asistencia a reunión de AT', 5, N'asistenciasat', NULL, 1, N'sys', CAST(N'2024-06-20T12:13:29.023' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[SISTEMAOPCION] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIO] ON 
GO
INSERT [dbo].[USUARIO] ([usuario_id], [persona_id], [username], [password], [numdocumento], [nombre_completo], [interno], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (9, 1, N'jjromero88', N'tZ72XkenUqJgv9rpKkF+Pg==', N'45338843', N'Juan Jose Romero Lizano', 1, 1, 1, N'jjromero88', CAST(N'2024-06-13T20:30:27.310' AS DateTime), N'jjromero88', CAST(N'2024-06-17T22:39:35.643' AS DateTime))
GO
INSERT [dbo].[USUARIO] ([usuario_id], [persona_id], [username], [password], [numdocumento], [nombre_completo], [interno], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (18, 2, N'45802558', N'M2YfqtWgLV8Hr+YETCtO1Q==', N'45802558', N'Jose Miguel Sanchez Peredo', 0, 1, 1, N'jjromero88', CAST(N'2024-06-22T12:43:06.620' AS DateTime), N'jjromero88', CAST(N'2024-06-22T12:48:08.490' AS DateTime))
GO
INSERT [dbo].[USUARIO] ([usuario_id], [persona_id], [username], [password], [numdocumento], [nombre_completo], [interno], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (19, 3, N'45855525', N'UiPzAOFgidQ45FcQL86f1w==', N'45855525', N'Kelly Ocorspoma Reynada', 1, 1, 1, N'jjromero88', CAST(N'2024-06-24T19:15:13.093' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[USUARIO] ([usuario_id], [persona_id], [username], [password], [numdocumento], [nombre_completo], [interno], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (20, 4, N'45875587', N'h9hJG5AyVYEdYp19TWWN9A==', N'45875587', N'Jose Martinez Pineda', 1, 1, 1, N'jjromero88', CAST(N'2024-06-25T10:26:37.980' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[USUARIO] ([usuario_id], [persona_id], [username], [password], [numdocumento], [nombre_completo], [interno], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (21, 5, N'48550214', N'xOELYg3eyoDHi6vBN3nYhA==', N'48550214', N'Maria Ramirez Tejada', 0, 1, 1, N'jjromero88', CAST(N'2024-06-25T10:27:33.587' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[USUARIO] ([usuario_id], [persona_id], [username], [password], [numdocumento], [nombre_completo], [interno], [habilitado], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (22, 6, N'45874587', N'HobuP9TvQ0QcpX4gwKDT6g==', N'45874587', N'jose martinez tejada', 0, 1, 1, N'jjromero88', CAST(N'2024-06-25T10:43:31.413' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIOPERFIL] ON 
GO
INSERT [dbo].[USUARIOPERFIL] ([usuarioperfil_id], [usuario_id], [perfil_id], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (1, 9, 1, 1, N'sys', CAST(N'2024-06-20T15:33:01.207' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[USUARIOPERFIL] ([usuarioperfil_id], [usuario_id], [perfil_id], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (5, 18, 2, 1, N'jjromero88', CAST(N'2024-06-22T12:43:06.620' AS DateTime), N'jjromero88', CAST(N'2024-06-22T12:48:08.493' AS DateTime))
GO
INSERT [dbo].[USUARIOPERFIL] ([usuarioperfil_id], [usuario_id], [perfil_id], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (6, 19, 6, 1, N'jjromero88', CAST(N'2024-06-24T19:15:13.097' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[USUARIOPERFIL] ([usuarioperfil_id], [usuario_id], [perfil_id], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (7, 20, 4, 1, N'jjromero88', CAST(N'2024-06-25T10:26:37.983' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[USUARIOPERFIL] ([usuarioperfil_id], [usuario_id], [perfil_id], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (8, 21, 5, 1, N'jjromero88', CAST(N'2024-06-25T10:27:33.587' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[USUARIOPERFIL] ([usuarioperfil_id], [usuario_id], [perfil_id], [estado], [usuario_reg], [fecha_reg], [usuario_act], [fecha_act]) VALUES (9, 22, 12, 1, N'jjromero88', CAST(N'2024-06-25T10:43:31.417' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[USUARIOPERFIL] OFF
GO
ALTER TABLE [dbo].[BLOQUEOUSUARIO] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[BLOQUEOUSUARIO] ADD  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[BLOQUEOUSUARIO] ADD  DEFAULT (getdate()) FOR [fecha_reg]
GO
ALTER TABLE [dbo].[LOG_ACCESO] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[LOG_ACCESO] ADD  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[LOG_ACCESO] ADD  DEFAULT (getdate()) FOR [fecha_reg]
GO
ALTER TABLE [dbo].[LOG_BLOQUEO] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[LOG_BLOQUEO] ADD  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[LOG_BLOQUEO] ADD  DEFAULT (getdate()) FOR [fecha_reg]
GO
ALTER TABLE [dbo].[PERFIL] ADD  CONSTRAINT [DF__PERFIL__estado__4D94879B]  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[PERFIL] ADD  CONSTRAINT [DF__PERFIL__usuario___4E88ABD4]  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[PERFIL] ADD  CONSTRAINT [DF__PERFIL__fecha_re__4F7CD00D]  DEFAULT (getdate()) FOR [fecha_reg]
GO
ALTER TABLE [dbo].[PERFILOPCION] ADD  DEFAULT ((1)) FOR [habilitado]
GO
ALTER TABLE [dbo].[PERFILOPCION] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[PERFILOPCION] ADD  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[PERFILOPCION] ADD  DEFAULT (getdate()) FOR [fecha_reg]
GO
ALTER TABLE [dbo].[SISTEMAOPCION] ADD  CONSTRAINT [DF__SISTEMAOP__num_o__38996AB5]  DEFAULT ((0)) FOR [num_orden]
GO
ALTER TABLE [dbo].[SISTEMAOPCION] ADD  CONSTRAINT [DF__SISTEMAOP__estad__398D8EEE]  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[SISTEMAOPCION] ADD  CONSTRAINT [DF__SISTEMAOP__usuar__3A81B327]  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[SISTEMAOPCION] ADD  CONSTRAINT [DF__SISTEMAOP__fecha__3B75D760]  DEFAULT (getdate()) FOR [fecha_reg]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF__USUARIO__estado__4AB81AF0]  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF__USUARIO__usuario__4BAC3F29]  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF__USUARIO__fecha_r__4CA06362]  DEFAULT (getdate()) FOR [fecha_reg]
GO
ALTER TABLE [dbo].[USUARIOPERFIL] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[USUARIOPERFIL] ADD  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[USUARIOPERFIL] ADD  DEFAULT (getdate()) FOR [fecha_reg]
GO
ALTER TABLE [dbo].[BLOQUEOUSUARIO]  WITH CHECK ADD  CONSTRAINT [FK__BLOQUEOUS__usuar__5629CD9C] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[USUARIO] ([usuario_id])
GO
ALTER TABLE [dbo].[BLOQUEOUSUARIO] CHECK CONSTRAINT [FK__BLOQUEOUS__usuar__5629CD9C]
GO
ALTER TABLE [dbo].[BLOQUEOUSUARIO]  WITH CHECK ADD  CONSTRAINT [FK__BLOQUEOUS__usuar__7C4F7684] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[USUARIO] ([usuario_id])
GO
ALTER TABLE [dbo].[BLOQUEOUSUARIO] CHECK CONSTRAINT [FK__BLOQUEOUS__usuar__7C4F7684]
GO
ALTER TABLE [dbo].[LOG_ACCESO]  WITH CHECK ADD  CONSTRAINT [FK__LOG_ACCES__usuar__5BE2A6F2] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[USUARIO] ([usuario_id])
GO
ALTER TABLE [dbo].[LOG_ACCESO] CHECK CONSTRAINT [FK__LOG_ACCES__usuar__5BE2A6F2]
GO
ALTER TABLE [dbo].[LOG_ACCESO]  WITH CHECK ADD  CONSTRAINT [FK__LOG_ACCES__usuar__7D439ABD] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[USUARIO] ([usuario_id])
GO
ALTER TABLE [dbo].[LOG_ACCESO] CHECK CONSTRAINT [FK__LOG_ACCES__usuar__7D439ABD]
GO
ALTER TABLE [dbo].[LOG_BLOQUEO]  WITH CHECK ADD  CONSTRAINT [FK__LOG_BLOQU__usuar__619B8048] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[USUARIO] ([usuario_id])
GO
ALTER TABLE [dbo].[LOG_BLOQUEO] CHECK CONSTRAINT [FK__LOG_BLOQU__usuar__619B8048]
GO
ALTER TABLE [dbo].[LOG_BLOQUEO]  WITH CHECK ADD  CONSTRAINT [FK__LOG_BLOQU__usuar__7E37BEF6] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[USUARIO] ([usuario_id])
GO
ALTER TABLE [dbo].[LOG_BLOQUEO] CHECK CONSTRAINT [FK__LOG_BLOQU__usuar__7E37BEF6]
GO
ALTER TABLE [dbo].[OPCIONPERMISOS]  WITH CHECK ADD  CONSTRAINT [FK__OPCIONPER__permi__07C12930] FOREIGN KEY([permiso_id])
REFERENCES [dbo].[PERMISOS] ([permiso_id])
GO
ALTER TABLE [dbo].[OPCIONPERMISOS] CHECK CONSTRAINT [FK__OPCIONPER__permi__07C12930]
GO
ALTER TABLE [dbo].[OPCIONPERMISOS]  WITH CHECK ADD  CONSTRAINT [FK_OPCIONPERMISOS_PERFILOPCION] FOREIGN KEY([perfilopcion_id])
REFERENCES [dbo].[PERFILOPCION] ([perfilopcion_id])
GO
ALTER TABLE [dbo].[OPCIONPERMISOS] CHECK CONSTRAINT [FK_OPCIONPERMISOS_PERFILOPCION]
GO
ALTER TABLE [dbo].[PERFILOPCION]  WITH CHECK ADD  CONSTRAINT [FK__PERFILOPC__perfi__6383C8BA] FOREIGN KEY([perfil_id])
REFERENCES [dbo].[PERFIL] ([perfil_id])
GO
ALTER TABLE [dbo].[PERFILOPCION] CHECK CONSTRAINT [FK__PERFILOPC__perfi__6383C8BA]
GO
ALTER TABLE [dbo].[PERFILOPCION]  WITH CHECK ADD  CONSTRAINT [FK__PERFILOPC__siste__00200768] FOREIGN KEY([sistemaopcion_id])
REFERENCES [dbo].[SISTEMAOPCION] ([sistemaopcion_id])
GO
ALTER TABLE [dbo].[PERFILOPCION] CHECK CONSTRAINT [FK__PERFILOPC__siste__00200768]
GO
ALTER TABLE [dbo].[SISTEMAOPCION]  WITH CHECK ADD  CONSTRAINT [FK__SISTEMAOP__padre__01142BA1] FOREIGN KEY([padre_id])
REFERENCES [dbo].[SISTEMAOPCION] ([sistemaopcion_id])
GO
ALTER TABLE [dbo].[SISTEMAOPCION] CHECK CONSTRAINT [FK__SISTEMAOP__padre__01142BA1]
GO
ALTER TABLE [dbo].[USUARIOPERFIL]  WITH CHECK ADD  CONSTRAINT [FK__USUARIOPE__perfi__693CA210] FOREIGN KEY([perfil_id])
REFERENCES [dbo].[PERFIL] ([perfil_id])
GO
ALTER TABLE [dbo].[USUARIOPERFIL] CHECK CONSTRAINT [FK__USUARIOPE__perfi__693CA210]
GO
ALTER TABLE [dbo].[USUARIOPERFIL]  WITH CHECK ADD  CONSTRAINT [FK__USUARIOPE__usuar__4F7CD00D] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[USUARIO] ([usuario_id])
GO
ALTER TABLE [dbo].[USUARIOPERFIL] CHECK CONSTRAINT [FK__USUARIOPE__usuar__4F7CD00D]
GO
/****** Object:  StoredProcedure [dbo].[USP_DEL_PERFIL]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[USP_DEL_PERFIL](
	@perfil_id int = NULL,
	@usuario_act varchar(20) = NULL,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN
	SET @error = 0;

	-- validamos si existe el perfil que desea eliminar
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[perfil] AS t1 WITH(NOLOCK) WHERE t1.perfil_id = @perfil_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'El perfil que desea Eliminar no existe';
	END
	
	IF(@error = 0)
	BEGIN

		--Se elimina el perfil actualizando sus datos de auditoria

		UPDATE 
		[dbo].PERFIL
		SET 
		estado = 0,
		usuario_act = @usuario_act
		WHERE
		perfil_id = @perfil_id

		-- setemos el mensaje de salida
		set @message = 'Información eliminada satisfactoriamente';

	END


END

GO
/****** Object:  StoredProcedure [dbo].[USP_DEL_USUARIO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[USP_DEL_USUARIO](
	@usuario_id int = NULL,
	@usuario_act varchar(20) = NULL,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN
	SET @error = 0;

	-- validamos si existe el usuario que desea eliminar
	IF NOT EXISTS(SELECT TOP(1) t1.* FROM [dbo].USUARIO AS t1 WITH(NOLOCK) WHERE t1.usuario_id = @usuario_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'El usuario que desea Eliminar no existe';
	END
	
	IF(@error = 0)
	BEGIN

		--Se elimina el perfil actualizando sus datos de auditoria
		UPDATE 
		[dbo].USUARIO
		SET 
		estado = 0,
		usuario_act = @usuario_act
		WHERE
		usuario_id = @usuario_id;

		-- desactivamos los perfiles asociados al usuario
		UPDATE USUARIOPERFIL SET estado = 0, usuario_act = @usuario_act, fecha_act = GETDATE() where usuario_id = @usuario_id and estado = 1;

		-- setemos el mensaje de salida
		set @message = 'Información eliminada satisfactoriamente';

	END


END

GO
/****** Object:  StoredProcedure [dbo].[USP_GET_PERFIL]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[USP_GET_PERFIL](
	@perfil_id INT,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0

	-- validamos si existe el perfil que desea consultar
	IF NOT EXISTS(SELECT TOP(1) t1.* FROM [dbo].[perfil] AS t1 WITH(NOLOCK) WHERE t1.perfil_id = @perfil_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'El perfil que desea consultar no existe';
	END
	
	IF(@error = 0)
	BEGIN
		SELECT
			 T1.perfil_id, 
			 T1.codigo, 
			 T1.abreviatura, 
			 T1.descripcion, 
			 T1.interno,
			 T1.estado, 
			 T1.usuario_reg, 
			 T1.fecha_reg, 
			 T1.usuario_act, 
			 T1.fecha_act 
		FROM 
			[dbo].PERFIL  T1 WITH(NOLOCK)
		WHERE
			T1.perfil_id = @perfil_id;

		set @message = 'Consulta exitosa';
	END


END

GO
/****** Object:  StoredProcedure [dbo].[USP_GET_USUARIO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[USP_GET_USUARIO](
	@usuario_id INT,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0

	-- validamos si existe el usuario que desea consultar
	IF NOT EXISTS(SELECT TOP(1) t1.* FROM [dbo].USUARIO AS t1 WITH(NOLOCK) WHERE t1.usuario_id = @usuario_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'El usuario que desea consultar no existe';
	END
	
	IF(@error = 0)
	BEGIN
		SELECT
			T1.usuario_id,
			T1.persona_id, 
			T1.username, 
			T1.password, 
			T1.numdocumento, 
			T1.nombre_completo, 
			T1.interno,
			T1.habilitado,
			T1.estado, 
			T1.usuario_reg, 
			T1.fecha_reg, 
			T1.usuario_act, 
			T1.fecha_act 
		FROM 
			[dbo].USUARIO  T1 WITH(NOLOCK)
		WHERE
			T1.usuario_id = @usuario_id;

		set @message = 'Consulta exitosa';
	END


END

GO
/****** Object:  StoredProcedure [dbo].[USP_GET_USUARIO_ACCESOS]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
 * Procedimiento	: dbo.USP_GET_USUARIO_ACCESOS
 * Proposito		: Obtener lista de accesos por perfil de usuario
 * Input/Output		: Ninguna
 * Modificaciones	: Ninguna
 * Creado por		: Juan Jose Romero
 * Fecha			: 06/06/2024
 * */

CREATE       PROCEDURE [dbo].[USP_GET_USUARIO_ACCESOS](
	@usuario_id int,
	@perfil_id int,
	@usuarioAccesos nvarchar(max) = null output,
	@error bit = null output,
	@message nvarchar(500) = null output
)
AS
BEGIN
	
	--el error empieza en false
	set @error = 0

	--declaramos el usuarioperfil
	declare
	@usuarioperfil_id int = null;


	/*	inicio de validaciones	*/

	BEGIN
	

		--verifica que el usuario exista
		IF NOT EXISTS(select top(1) * from USUARIO as t1 with(nolock) where t1.estado = 1 and t1.usuario_id = @usuario_id)
		BEGIN
			set @error = 1;
			set @message = 'El usuario ingresado no existe';
		END

		--verifica que el perfil exista
		IF NOT EXISTS(select top(1) * from PERFIL as t1 with(nolock) where t1.estado = 1 and t1.perfil_id = @perfil_id)
		BEGIN
			set @error = 1;
			set @message = 'El perfil ingresado no existe';
		END

		----verificar que el usuario tenga asociado por lo menos un perfil
		ELSE IF NOT EXISTS (
		SELECT T1.* FROM DBO.USUARIOPERFIL T1 with(nolock)
		INNER JOIN DBO.USUARIO T2 ON T1.usuario_id = T2.usuario_id
		WHERE T1.usuario_id = @usuario_id and T1.estado = 1
		)
		BEGIN 
			set @error = 1;
			set @message = 'El usuario ingresado no tiene asociado un perfil, comuniquese con el administrador del sistema';
		END

		--validar que el perfil tenga por lo menos una opcion del sistema
		IF NOT EXISTS (SELECT T1.* FROM SISTEMAOPCION T1 with(nolock) INNER JOIN PERFILOPCION T2 with(nolock) ON T1.sistemaopcion_id = T2.sistemaopcion_id  WHERE T2.perfil_id = @perfil_id AND T1.estado= 1 and T2.estado = 1 and T2.habilitado = 1)
		BEGIN
			SET @error = 1
			SET @message = 'El perfil no cuenta con opciones del sistema'
		END

		--buscamos el usuarioperfil correspondiente
		select top(1) @usuarioperfil_id =  t1.usuarioperfil_id from USUARIOPERFIL as t1 with(nolock) where t1.estado = 1 and t1.usuario_id = @usuario_id and t1.perfil_id = @perfil_id;

		--validamos que exista el usaurioperfil
		IF(@usuarioperfil_id IS NULL)
		BEGIN
			SET @error = 1
			SET @message = 'El perfil y el usuario ingresados no se encuentran configurados correctamente, comuniquese con el administrador del sistema'
		END
	
	END

	/*	fin de validaciones	 */


	--si no hubo ningun error se procede al login
	IF(@error = 0 and @usuario_id is not null and @perfil_id is not null)
	BEGIN

		declare 
		@jsonAccesos varchar(max) = null;


		-- obtenemos en una tabla temporal los accesos asociados al perfil
		SELECT
			T1.*
		INTO 
			#SISTEMAOPCIONES_TEMP
		FROM 
			SISTEMAOPCION T1 with(nolock)
			INNER JOIN PERFILOPCION T2 with(nolock) ON T1.sistemaopcion_id = T2.sistemaopcion_id AND T2.estado = 1 AND T2.habilitado = 1
			INNER JOIN PERFIL T3 with(nolock) ON T2.perfil_id = T3.perfil_id AND T3.estado = 1
			INNER JOIN USUARIOPERFIL T4 with(nolock) ON T4.perfil_id = T3.perfil_id AND T4.estado = 1
		WHERE 
			T1.estado = 1 AND
			(T4.perfil_id = @perfil_id) AND
			(T4.usuario_id = @usuario_id) AND
			(T4.USUARIOPERFIL_ID = @usuarioperfil_id)
		ORDER BY 
			T1.num_orden;

		--declaramos variables locales
		DECLARE @MAX INT = 4 -- DEFINIMOS EL NIVEL MAXIMO DEL ARBOL
		DECLARE @CONT INT = @MAX
		DECLARE @ALIAS_AC VARCHAR(5)
		DECLARE @ALIAS_AN VARCHAR(5)
		DECLARE @QUERY NVARCHAR(MAX)		
		DECLARE @OPCIONESCOLUMN NVARCHAR(MAX) = '$.[codigo], $.[descripcion], $.[abreviatura], $.[url_opcion], $.[icono_opcion], $.[num_orden]';
		DECLARE @COLUMNS NVARCHAR(MAX) = '';


		--obtencion de numero de niveles de manera dinamica

		WHILE @CONT > 0 AND @CONT <= @MAX
		BEGIN
			SET @ALIAS_AC = CONCAT('SO',@CONT)
			SET @ALIAS_AN = CONCAT('SO',(@CONT - 1))
			
			SET @COLUMNS = (SELECT REPLACE(@OPCIONESCOLUMN,'$',@ALIAS_AC));

			IF @CONT = @MAX
			BEGIN
				SET @QUERY =
				'
				SELECT
					'+@COLUMNS + ' 
				FROM dbo.#SISTEMAOPCIONES_TEMP '+@ALIAS_AC+'
				WHERE '+@ALIAS_AC+'.padre_id = '+@ALIAS_AN+'.sistemaopcion_id
				ORDER BY '+@ALIAS_AC+'.num_orden
				FOR JSON PATH
				'
			END
			ELSE IF @CONT > 1
			BEGIN
				SET @QUERY =
				'
				SELECT 
					'+@COLUMNS + ',
					(
						'+@QUERY+'
					) AS ''ListaAccesos''
				FROM dbo.#SISTEMAOPCIONES_TEMP '+@ALIAS_AC+'
				WHERE '+@ALIAS_AC+'.padre_id = '+@ALIAS_AN+'.sistemaopcion_id
				ORDER BY '+@ALIAS_AC+'.num_orden
				FOR JSON PATH
				'
			END
			ELSE
			BEGIN
				SET @QUERY =
				'
				SELECT 
					'+@COLUMNS + ',
					(
						'+@QUERY+'
					) AS ''ListaAccesos''
				FROM dbo.#SISTEMAOPCIONES_TEMP '+@ALIAS_AC+'
				WHERE '+@ALIAS_AC+'.padre_id IS NULL
				ORDER BY '+@ALIAS_AC+'.num_orden
				FOR JSON PATH
				'
			END

			SET @CONT -= 1
		END
		

		SET @QUERY =
		'
		SELECT
		(
			'+@QUERY+'
		) AS LISTAJSON'



		-- insertamos en una tabla el json que resulto de la consulta
		DECLARE @TABLAACCESOS AS TABLE (LISTAJSON VARCHAR(MAX));
		INSERT INTO @TABLAACCESOS exec sp_executesql @QUERY;

		-- asignamos la columna de la tabla a la variable de salida
		SELECT @usuarioAccesos = LISTAJSON FROM @TABLAACCESOS;

		-- eliminamos la tabla temporal creada
		drop table #SISTEMAOPCIONES_TEMP

		select @usuarioAccesos;

		--actualizamos el mensaje de salida
		set @message = 'Consulta exitosa';

	END
	ELSE BEGIN 
		set @error = ISNULL(@error, 1);
		set @message = ISNULL(@message, 'Ocurrio un error al intentar iniciar sesión, comuniquese con el administrador del sistema.');
	END

END


GO
/****** Object:  StoredProcedure [dbo].[USP_GET_USUARIO_LOGIN]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
 * Procedimiento	: dbo.USP_GET_USUARIO_LOGIN
 * Proposito		: Autenticar usuario interno
 * Input/Output		: Ninguna
 * Modificaciones	: Ninguna
 * Creado por		: Juan Jose Romero
 * Fecha			: 04/06/2024
 * */

CREATE     PROCEDURE [dbo].[USP_GET_USUARIO_LOGIN](
	@username varchar(20),
	@password varchar(150),
	@usuarioLogin nvarchar(max) = null output,
	@error bit = null output,
	@message nvarchar(500) = null output
)
AS
BEGIN
	
	--el error empieza en false
	set @error = 0

	--declaramos las variables a utilizar
	declare
	@MAX_INTENTOS_ACCESO INT;

	--asignamos los valores a las variables declaradas
	set @MAX_INTENTOS_ACCESO = 6;


	/*	inicio de validaciones	*/

	BEGIN

		DECLARE @usuario_id int = null;

		--se obtiene el id usuario mediante las credenciales
		SELECT TOP 1 @usuario_id = T1.usuario_id FROM usuario T1 WITH (NOLOCK)
		WHERE T1.estado = 1 AND
		LOWER(TRIM(T1.username)) = LOWER(TRIM(@username));

		--verifica que el usuario exista
		IF (@usuario_id IS NULL)
		BEGIN
			set @error = 1;
			set @message = 'El usuario ingresado no existe';
		END

		--verifica que el usuario no este deshabilitado
		IF EXISTS (SELECT TOP 1 * FROM USUARIO AS t1 WITH(NOLOCK) WHERE t1.usuario_id = @usuario_id AND t1.habilitado = 0)
		BEGIN
			set @error = 1;
			set @message = 'El usuario ingresado no se encuentra activo';
		END

		--verifivar que la contraseña de usuario sea la correcta
		ELSE IF NOT EXISTS (SELECT TOP 1 * FROM DBO.USUARIO T1 WITH(NOLOCK) WHERE T1.usuario_id = @usuario_id AND TRIM(T1.password) = TRIM(@password))
		BEGIN
			set @error = 1;
			set @message = 'La contraseña ingresada es incorrecta';
		END
	
		--verificar que el usuario no se encuentre bloqueado
		ELSE IF EXISTS (
		SELECT TOP 1 T1.* FROM BLOQUEOUSUARIO T1
		WHERE T1.usuario_id = @usuario_id
		AND T1.fecha_desbloqueo > GETDATE()
		)
		BEGIN
			set @error = 1;
			set @message = 'El usuario se encuentra bloqueado';
		END
	
		----verificar que el usuario tenga asociado por lo menos un perfil
		ELSE IF NOT EXISTS (
		SELECT T1.* FROM DBO.USUARIOPERFIL T1
		INNER JOIN DBO.USUARIO T2 ON T1.usuario_id = T2.usuario_id
		WHERE T1.usuario_id = @usuario_id and T1.estado = 1
		)
		BEGIN 
			set @error = 1;
			set @message = 'El usuario ingresado no tiene asociado un perfil, comuniquese con el administrador del sistema';
		END

	END

	/*	fin de validaciones	 */


	--si no hubo ningun error se procede al login
	IF(@error = 0 and @usuario_id is not null)
	BEGIN

		declare 
		@jsonUsuario varchar(max) = null,
		@jsonPerfiles varchar(max) = null;


		--obtenemos los datos del usuario
		set @jsonUsuario = (
		SELECT
			  usuario_id
			, username
			, password
			, interno
			, numdocumento
			, nombre_completo
		FROM 
			[dbo].[USUARIO] AS T1 WITH(NOLOCK)
		WHERE
			T1.usuario_id = @usuario_id
			and T1.interno = 1
		FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
		);


		--buscamos los perfiles asociados del usuarios

		set @jsonPerfiles = (
			select
				  t1.perfil_id
				, t1.codigo
				, t1.abreviatura
				, t1.descripcion
			from 
				PERFIL as t1
				inner join USUARIOPERFIL as t2 on t1.perfil_id = t2.perfil_id
				inner join USUARIO as t3 on t2.usuario_id = t3.usuario_id
			where
					t1.estado = 1
				and t2.estado = 1
				and t3.usuario_id = @usuario_id
			FOR JSON PATH, INCLUDE_NULL_VALUES
		);

		--agregamos la propiedad de modulos al json de usuario
		SET @jsonUsuario = JSON_MODIFY(@jsonUsuario, '$.lista_perfiles', JSON_QUERY(@jsonPerfiles));

		--seteamos el valor del json de salida
		SET @usuarioLogin = @jsonUsuario;

		--actualizamos el mensaje de salida
		set @message = 'Acceso exitoso';

	END
	ELSE BEGIN 
		set @error = ISNULL(@error, 1);
		set @message = ISNULL(@message, 'Ocurrio un error al intentar iniciar sesión, comuniquese con el administrador del sistema.');
	END

END


GO
/****** Object:  StoredProcedure [dbo].[USP_INS_PERFIL]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[USP_INS_PERFIL]
	--@opciones_id varchar(max) = NULL,
	@codigo varchar(10) = NULL,
	@abreviatura varchar(50) = NULL, 
	@descripcion varchar(150) = NULL,
	@interno bit = null,
	@usuario_reg varchar(20) = NULL,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
AS
BEGIN
	
	--Inicializa como false
	SET @error = 0;

	---- verificamos que venga mas de una opcion para el perfil
	--IF ((select COUNT(*) from string_split(@opciones_id, ',')) <= 0)
	--BEGIN
	--	SET @error = 1;
	--	SET @message = 'Debe seleccionar por lo menos una opcion del sistema';
	--END

	-- validamos si existe un perfil con la misma descripcion
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[perfil] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@descripcion)) = TRIM(LOWER(t1.descripcion))) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un perfil registrado con la descripción ' + TRIM(LOWER(@descripcion));
	END

	-- validamos si existe un perfil con la misma abreviatura
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[perfil] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@abreviatura)) = TRIM(LOWER(t1.abreviatura))) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un perfil registrado con la abreviatura ' + TRIM(LOWER(@abreviatura));
	END

	-- validamos la cantidad de digitos del codigo
	IF ((select LEN(TRIM(@codigo))) <> 5)
	BEGIN
		SET @error = 1;
		SET @message = 'El campo codigo debe tener 5 digitos';
	END

	-- validamos si existe el mismo codigo de perfil
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[perfil] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@codigo)) = TRIM(LOWER(t1.codigo))) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un perfil registrado con el codigo ' + TRIM(LOWER(@abreviatura));
	END
 
	IF(@error = 0) 
	BEGIN

		--declaramos el id de perfil
		--Declare @perfil_id int = null;
		--Declare @habilitado bit = 1;

		--insertamos el perfil
		INSERT INTO dbo.[perfil] (
			codigo,
			abreviatura,
			descripcion,
			interno,
			usuario_reg,
			fecha_reg
		)
		VALUES (
			@codigo,
			TRIM(@abreviatura),
			TRIM(@descripcion),
			@interno,
			case when @usuario_reg is null then 'sys' else @usuario_reg end,
			GETDATE()
		);

		---- capturamos el id del perfil creado
		--set @perfil_id = @@IDENTITY;

		----insertamos las opciones del perfil
		--INSERT INTO [dbo].PERFILOPCION 
		--(perfil_id, sistemaopcion_id, habilitado, estado, usuario_reg, fecha_reg) select
		--@perfil_id, value, @habilitado, 1, @usuario_reg, GETDATE()
		--from string_split(@opciones_id, ',')


		-- setemos el mensaje de salida
		set @message = 'Información registrada satisfactoriamente';

	END

END

GO
/****** Object:  StoredProcedure [dbo].[USP_INS_PERFILOPCION]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE      PROCEDURE [dbo].[USP_INS_PERFILOPCION]
	@perfil_id varchar(10) = null,
	@sistemaopciones_id varchar(max) = null,	
	@usuario_reg varchar(20) = null,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
AS
BEGIN
	
	--Inicializa como false
	SET @error = 0; 

	-- validamos si existe un perfil con la misma descripcion
	IF ((SELECT COUNT(*) FROM string_split(@sistemaopciones_id,',')) <= 0)
	BEGIN
		SET @error = 1;
		SET @message = 'Por lo menos debe seleccionar una opcion del sistema';
	END
 
	IF(@error = 0) 
	BEGIN

		-- 1. desactivamos las opciones del sistema existentes asociadas al perfil
		UPDATE PERFILOPCION
		SET 
		estado = 0,
		habilitado = 0,
		fecha_act = getdate(),
		usuario_act = @usuario_reg
		WHERE 
		perfil_id = @perfil_id;
		
		--formamos una tabla temporal con la lista de opciones del sistema
		DECLARE @SISTEMAOPCIONES TABLE(sistemaopcion_id INT);

		--insertamos los valores en la tabla
		insert into @SISTEMAOPCIONES (sistemaopcion_id)
		select value from string_split(@sistemaopciones_id, ',');

		--seteamos el valor por default del estaco habilitado
		Declare @habilitado bit = null;
		SET @habilitado = 1;

		--declaramos variables por dfault
		Declare @estado bit = 1;

		-- 2. Insertamos las opciones del sistema nuevas
		INSERT INTO PERFILOPCION(
			perfil_id,
			sistemaopcion_id,
			habilitado,
			estado,
			usuario_reg,
			fecha_reg
		)
		SELECT
			@perfil_id,
			T2.sistemaopcion_id,
			@habilitado,
			@estado,
			@usuario_reg,
			getdate()
		FROM	[dbo].PERFILOPCION AS T1 WITH(NOLOCK)
		RIGHT JOIN @SISTEMAOPCIONES T2 ON T1.sistemaopcion_id = T2.sistemaopcion_id AND T1.perfil_id = @perfil_id
		WHERE	T1.perfilopcion_id IS NULL;

		-- 3. Se actualizan las opciones de perfil que ya existen
		UPDATE T1
		SET 				  
		  T1.perfil_id = @perfil_id
		, T1.sistemaopcion_id = T2.sistemaopcion_id
		, T1.habilitado = @habilitado
		, T1.USUARIO_ACT = @usuario_reg
		, T1.ESTADO = @estado
		, T1.FECHA_ACT = GETDATE()
		FROM [dbo].PERFILOPCION AS T1 WITH(NOLOCK)
		INNER JOIN @SISTEMAOPCIONES AS T2 ON T1.sistemaopcion_id = T2.sistemaopcion_id AND T1.perfil_id = @perfil_id;



		-- setemos el mensaje de salida
		set @message = 'Información registrada satisfactoriamente';

	END

END

GO
/****** Object:  StoredProcedure [dbo].[USP_INS_USUARIO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[USP_INS_USUARIO]
	@persona_id int = null,
	@username varchar(20) = null,
	@password varchar(150) = null,
	@numdocumento varchar(20) = null,
	@nombre_completo varchar(100) = null,
	@interno bit = null,
	@habilitado bit = null,
	@perfiles varchar(max) = null,
	@usuario_reg varchar(20) = null,
	@error BIT = null OUTPUT,
	@message NVARCHAR(500) = null OUTPUT
AS
BEGIN
	
	--Inicializa como false
	SET @error = 0;

	-- validamos si el nombre de usuario ya existe
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[USUARIO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@username)) = TRIM(LOWER(t1.username))) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un usuario con el nombre ' + TRIM(LOWER(@username));
	END

	-- validamos si existe un usuario para el mismo persona_id
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[USUARIO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  @persona_id = T1.persona_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'La persona que intenta registrar ya tiene un usuario asociado';
	END

	-- validamos si existe un usuario con el mismo numero de documento asociado
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[USUARIO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@numdocumento)) = TRIM(LOWER(t1.numdocumento))) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un usuario registrado con el número de documento ' + TRIM(LOWER(@numdocumento));
	END

	-- validamos la cantidad de digitos del usuario
	IF ((select LEN(TRIM(@username))) < 5)
	BEGIN
		SET @error = 1;
		SET @message = 'El nombre de usuario debe tener como mínimo 5 digitos';
	END

	-- validamos que tenga por lo menos un perfil
	IF( (select COUNT(*) from string_split(@perfiles, ',')) <= 0 )
	BEGIN
		SET @error = 1;
		SET @message = 'Debe seleccionar un perfil como mínimo';
	END
 
	IF(@error = 0) 
	BEGIN

		Declare @usuario_id int = null;

		INSERT INTO dbo.USUARIO(
			persona_id,
			username,
			password,
			numdocumento,
			nombre_completo,
			interno,
			habilitado,
			usuario_reg,
			fecha_reg
		)
		VALUES (
			@persona_id,
			TRIM(LOWER(@username)),
			TRIM(@password),
			TRIM(@numdocumento),
			TRIM(@nombre_completo),
			@interno,
			@habilitado,
			case when @usuario_reg is null then 'sys' else @usuario_reg end,
			GETDATE()
		);

		-- seteamos el id del usuario recien insertado
		set @usuario_id = @@IDENTITY;

		-- insertamos los perfiles del usuario en UsuarioPerfil
		insert into dbo.USUARIOPERFIL
		(usuario_id, perfil_id, estado, usuario_reg, fecha_reg)
		select @usuario_id, value, 1, @usuario_reg, GETDATE() from string_split(@perfiles, ',')

		-- setemos el mensaje de salida
		set @message = 'Información registrada satisfactoriamente';

	END
END

GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_PERFIL]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[USP_SEL_PERFIL](
	@perfil_id INT,
	@filtro varchar(max) = null,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;

	SELECT
		T1.perfil_id, 
		T1.codigo, 
		T1.abreviatura, 
		T1.descripcion, 
		T1.interno,
		T1.estado, 
		T1.usuario_reg, 
		T1.fecha_reg, 
		T1.usuario_act, 
		T1.fecha_act 
	FROM 
		[dbo].PERFIL  T1 WITH(NOLOCK)
	WHERE
		(T1.estado = 1) AND
		(@perfil_id IS NULL OR T1.perfil_id = @perfil_id) AND
		(@FILTRO IS NULL OR (RTRIM(LTRIM(ISNULL(T1.codigo, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.abreviatura, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.descripcion, '')))) LIKE '%' + @filtro + '%' COLLATE Latin1_General_CI_AI);

		-- seteamos mensaje de salida
		set @message = 'Consulta exitosa';


END

GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_PERFILOPCION]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[USP_SEL_PERFILOPCION](
	@perfil_id INT,
	@jsonSistemaOpciones VARCHAR(MAX) = NULL OUTPUT,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;

	SELECT 
		t1.[sistemaopcion_id], 
		t1.[padre_id], 
		t1.[codigo], 
		t1.[descripcion], 
		t1.[abreviatura], 
		t1.[url_opcion], 
		t1.[icono_opcion], 
		t1.[num_orden], 
		t1.[estado], 
		t1.[usuario_reg], 
		t1.[fecha_reg], 
		t1.[usuario_act], 
		t1.[fecha_act],
		ISNULL(t2.habilitado, 0) habilitado
	INTO #SISTEMAOPCIONES
	FROM SISTEMAOPCION t1
	LEFT JOIN PERFILOPCION t2 ON t1.sistemaopcion_id = t2.sistemaopcion_id
	AND t2.perfil_id = @perfil_id AND t2.estado = 1 AND t1.estado = 1
	ORDER BY t1.padre_id, t1.num_orden;

	--formamos el query dinamico que genera la consulta anidada

	DECLARE @MAX INT = 4
	DECLARE @CONT INT = @MAX
	DECLARE @ALIAS_AC VARCHAR(5)
	DECLARE @ALIAS_AN VARCHAR(5)
	DECLARE @QUERY NVARCHAR(MAX)		
	DECLARE @OPCIONESCOLUMN NVARCHAR(MAX) = '$.[sistemaopcion_id], $.[codigo], $.[descripcion], $.[abreviatura], $.[icono_opcion], $.[num_orden], $.[habilitado]';
	DECLARE @COLUMNS NVARCHAR(MAX) = '';



	--obtencion de numero de niveles de manera dinamica

	WHILE @CONT > 0 AND @CONT <= @MAX
	BEGIN
		SET @ALIAS_AC = CONCAT('SO',@CONT)
		SET @ALIAS_AN = CONCAT('SO',(@CONT - 1))
			
		SET @COLUMNS = (SELECT REPLACE(@OPCIONESCOLUMN,'$',@ALIAS_AC));

		IF @CONT = @MAX
		BEGIN
			SET @QUERY =
			'
			SELECT
				'+@COLUMNS + ' 
			FROM dbo.#SISTEMAOPCIONES '+@ALIAS_AC+'
			WHERE '+@ALIAS_AC+'.padre_id = '+@ALIAS_AN+'.sistemaopcion_id
			ORDER BY '+@ALIAS_AC+'.num_orden
			FOR JSON PATH
			'
		END
		ELSE IF @CONT > 1
		BEGIN
			SET @QUERY =
			'
			SELECT 
				'+@COLUMNS + ',
				(
					'+@QUERY+'
				) AS ''ListaAccesos''
			FROM dbo.#SISTEMAOPCIONES '+@ALIAS_AC+'
			WHERE '+@ALIAS_AC+'.padre_id = '+@ALIAS_AN+'.sistemaopcion_id
			ORDER BY '+@ALIAS_AC+'.num_orden
			FOR JSON PATH
			'
		END
		ELSE
		BEGIN
			SET @QUERY =
			'
			SELECT 
				'+@COLUMNS + ',
				(
					'+@QUERY+'
				) AS ''ListaAccesos''
			FROM dbo.#SISTEMAOPCIONES '+@ALIAS_AC+'
			WHERE '+@ALIAS_AC+'.padre_id IS NULL
			ORDER BY '+@ALIAS_AC+'.num_orden
			FOR JSON PATH
			'
		END

		SET @CONT -= 1
	END
		

	SET @QUERY =
	'
	SELECT
	(
		'+@QUERY+'
	) AS LISTAJSON'


	-- insertamos en una tabla el json que resulto de la consulta
		DECLARE @TABLA AS TABLE (LISTAJSON VARCHAR(MAX))
		INSERT INTO @TABLA exec sp_executesql @QUERY

		-- asignamos la columna de la tabla a la variable de salida
		SELECT @jsonSistemaOpciones = LISTAJSON FROM @TABLA;

		-- eliminamos la tabla temporal creada
		drop table #SISTEMAOPCIONES;


	-- seteamos mensaje de salida
	set @message = 'Consulta exitosa';

END

GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_PERFILOPCION_HIJO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[USP_SEL_PERFILOPCION_HIJO](
	@perfil_id INT = null,
	@padre_id INT = null,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;
		
		select 
			t2.sistemaopcion_id ,
			t2.descripcion
		from 
			PERFILOPCION as t1 with(nolock)
			inner join SISTEMAOPCION as t2 with(nolock) on t1.sistemaopcion_id = t2.sistemaopcion_id
		where
			t1.habilitado = 1 and
			t1.estado = 1 and
			t2.estado = 1 and
			t1.perfil_id  = @perfil_id and
			t2.padre_id = @padre_id


	-- seteamos mensaje de salida
	set @message = 'Consulta exitosa';


END

GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_PERFILOPCION_PADRE]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[USP_SEL_PERFILOPCION_PADRE](
	@perfil_id INT = null,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;

		select 
			t3.sistemaopcion_id ,
			t3.descripcion
		from 
					   PERFILOPCION as t1 with(nolock)
			inner join SISTEMAOPCION as t2 with(nolock) on t1.sistemaopcion_id = t2.sistemaopcion_id
			inner join SISTEMAOPCION as t3 with(nolock) on t2.padre_id = t3.sistemaopcion_id
		where
			t1.habilitado = 1 and
			t1.estado = 1 and
			t2.estado = 1 and
			t1.perfil_id  = @perfil_id
		group by 
			t3.sistemaopcion_id ,
			t3.descripcion

	-- seteamos mensaje de salida
	set @message = 'Consulta exitosa';


END

GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_PERMISOS]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[USP_SEL_PERMISOS](
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;
		
		
		select
			t1.[permiso_id], 
			t1.[codigo], 
			t1.[nombre], 
			t1.[descripcion], 
			t1.[estado], 
			t1.[usuario_reg], 
			t1.[fecha_reg], 
			t1.[usuario_act], 
			t1.[fecha_act]
		from
			[dbo].[PERMISOS] as t1 with (nolock)
		where
			t1.estado = 1


	-- seteamos mensaje de salida
	set @message = 'Consulta exitosa';


END

GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_PERMISOS_OPCIONPERMISOS]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[USP_SEL_PERMISOS_OPCIONPERMISOS](
	@perfil_id INT = null,
	@sistemaopcion_id INT = null,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;
		
		select 
			tt1.*, ISNULL(sq.habilitado, 0) habilitado
		from
			PERMISOS as tt1 with(nolock)
			left outer join (
				select t2.* 
				from PERFILOPCION as t1 with(nolock)
				inner join OPCIONPERMISOS as t2 with(nolock) on t1.perfilopcion_id = t2.perfilopcion_id
				where
				t1.perfil_id = @perfil_id and
				t1.sistemaopcion_id = @sistemaopcion_id and
				t1.estado = 1 and t2.estado = 1) as sq on sq.permiso_id = tt1.permiso_id
		where tt1.estado = 1


	-- seteamos mensaje de salida
	set @message = 'Consulta exitosa';


END

GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_SISTEMAOPCION_PERMISOS]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE       PROCEDURE [dbo].[USP_SEL_SISTEMAOPCION_PERMISOS](
	@usuario_id int = null,
	@perfil_id int = null,
	@permisosJson nvarchar(max) = null output,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;
				
		select @permisosJson = (
			SELECT 
				so.descripcion AS opcion_descripcion,
				so.url_opcion AS url_opcion,
				so.codigo AS opcion_codigo,
				(
					SELECT 
						p.codigo AS permiso_codigo
					FROM 
						OPCIONPERMISOS op with(nolock)
					INNER JOIN 
						PERMISOS p with(nolock) ON op.permiso_id = p.permiso_id
					INNER JOIN 
						PERFILOPCION po with(nolock) ON op.perfilopcion_id = po.perfilopcion_id
					WHERE 
						po.perfil_id = @perfil_id
						AND po.sistemaopcion_id = so.sistemaopcion_id
						AND po.estado = 1
						AND op.estado = 1
						AND op.habilitado = 1
						AND po.habilitado = 1
					FOR JSON PATH
				) AS opcion_permisos
			FROM 
				SISTEMAOPCION so
			INNER JOIN 
				PERFILOPCION po with(nolock) ON so.sistemaopcion_id = po.sistemaopcion_id
			INNER JOIN 
				USUARIOPERFIL up with(nolock) ON po.perfil_id = up.perfil_id
			WHERE 
				up.usuario_id = @usuario_id
				AND up.perfil_id = @perfil_id
				AND so.padre_id IS NOT NULL  -- Considerando que solo los hijos tienen permisos
				AND so.estado = 1
				AND po.estado = 1
				AND up.estado = 1
				AND po.habilitado = 1
			FOR JSON PATH
		);

	-- seteamos mensaje de salida
	set @message = 'Consulta exitosa';


END

GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_USUARIO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[USP_SEL_USUARIO](
	@usuario_id int = null,
	@persona_id int = null,
	@numdocumento varchar(20) = null,
	@filtro varchar(max) = null,
	@habilitado bit = null,
	@interno bit = null,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;

	SELECT
		T1.usuario_id,
		T1.persona_id, 
		T1.username, 
		T1.password, 
		T1.numdocumento, 
		T1.nombre_completo, 
		T1.interno,
		T1.habilitado,
		T1.estado, 
		T1.usuario_reg, 
		T1.fecha_reg, 
		T1.usuario_act, 
		T1.fecha_act,
		(SELECT 
				P.perfil_id,
				P.codigo,
				P.descripcion,
				P.abreviatura
			FROM  [dbo].USUARIOPERFIL UP
			JOIN  [dbo].PERFIL P ON UP.perfil_id = P.perfil_id
			WHERE  UP.usuario_id = T1.usuario_id AND UP.estado = 1
			FOR JSON PATH
		) AS json_perfiles
	FROM 
		[dbo].USUARIO  T1 WITH(NOLOCK)
	WHERE
		(T1.estado = 1) AND
		(@usuario_id IS NULL OR T1.usuario_id = @usuario_id) AND
		(@persona_id IS NULL OR T1.persona_id = @persona_id) AND
		(@interno IS NULL OR T1.interno = @interno) AND
		(@habilitado IS NULL OR T1.habilitado = @habilitado) AND
		(@numdocumento IS NULL OR TRIM(T1.numdocumento) = TRIM(@numdocumento)) AND
		(@FILTRO IS NULL OR (RTRIM(LTRIM(ISNULL(T1.username, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.nombre_completo, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.numdocumento, '')))) LIKE '%' + @filtro + '%' COLLATE Latin1_General_CI_AI);

		-- seteamos mensaje de salida
		set @message = 'Consulta exitosa';


END
 
GO
/****** Object:  StoredProcedure [dbo].[USP_UPD_PERFIL]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[USP_UPD_PERFIL]
	@perfil_id int = NULL,
	--@opciones_id varchar(max) = NULL,
	@codigo varchar(10) = NULL,
	@abreviatura varchar(50) = NULL, 
	@descripcion varchar(150) = NULL,
	@interno bit = null,
	@usuario_act varchar(20) = NULL,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
AS
BEGIN
	
	--Inicializa como false
	SET @error = 0;

	---- verificamos que venga mas de una opcion para el perfil
	--IF ((select COUNT(*) from string_split(@opciones_id, ',')) <= 0)
	--BEGIN
	--	SET @error = 1;
	--	SET @message = 'Debe seleccionar por lo menos una opcion del sistema';
	--END

	-- validamos si existe un perfil con la misma descripcion
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[perfil] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@descripcion)) = TRIM(LOWER(t1.descripcion)) AND @perfil_id <> t1.perfil_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un perfil registrado con la descripción ' + TRIM(LOWER(@descripcion));
	END

	-- validamos si existe un perfil con la misma abreviatura
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[perfil] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@abreviatura)) = TRIM(LOWER(t1.abreviatura)) AND @perfil_id <> t1.perfil_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un perfil registrado con la abreviatura ' + TRIM(LOWER(@abreviatura));
	END

	-- validamos la cantidad de digitos del codigo
	IF ((select LEN(TRIM(@codigo))) <> 5)
	BEGIN
		SET @error = 1;
		SET @message = 'El campo codigo debe tener 5 digitos';
	END

	-- validamos si existe el mismo codigo de perfil
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[perfil] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@codigo)) = TRIM(LOWER(t1.codigo)) AND @perfil_id <> t1.perfil_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un perfil registrado con el codigo ' + TRIM(LOWER(@abreviatura));
	END
 
	IF(@error = 0) 
	BEGIN

		-- 1. actrualizamos los datos del perfil
		UPDATE dbo.[perfil]
		set 
			codigo = @codigo,
			abreviatura = @abreviatura,
			descripcion = @descripcion,
			interno = @interno,
			usuario_act = @usuario_act,
			fecha_act = GETDATE()
		where
			perfil_id = @perfil_id;

		---- 2. actualizamos los datos de las opciones de usuario

		----desactivamos las opciones actuales del perfil
		--update PERFILOPCION set estado = 0, usuario_act = @usuario_act, fecha_act = GETDATE() where perfil_id = @perfil_id and estado = 1;

		----Declaramos una tabla temporal
		--DECLARE @perfilopciones TABLE (perfil_id int, sistemaopcion_id int, habilitado bit)

		----insertamos los perfiles en la tabla temporal
		--insert into @perfilopciones (perfil_id, sistemaopcion_id, habilitado)
		--select @perfil_id, value, 1 from string_split(@opciones_id, ',');

		----2.1 Insertamos las opciones nuevas
		--insert into dbo.PERFILOPCION
		--(perfil_id, sistemaopcion_id, habilitado, estado, usuario_reg, fecha_act)
		--select 
		--@perfil_id, T2.sistemaopcion_id, T2.habilitado, 1, @usuario_act, GETDATE()
		--FROM
		--dbo.PERFILOPCION AS T1 WITH(NOLOCK)
		--RIGHT JOIN @perfilopciones T2 ON T1.perfil_id = T2.perfil_id AND T1.sistemaopcion_id = T2.sistemaopcion_id
		--WHERE	T1.perfil_id IS NULL AND T1.sistemaopcion_id IS NULL

		---- 2.2 Actualizamos las opciones del perfil que ya existian
		--UPDATE T1
		--SET 				  
		--  T1.sistemaopcion_id = T2.sistemaopcion_id
		--, T1.perfil_id = T2.perfil_id
		--, T1.ESTADO = 1
		--, T1.usuario_act = @usuario_act
		--, T1.FECHA_ACT = GETDATE()
		--FROM dbo.PERFILOPCION AS T1 WITH(NOLOCK)
		--INNER JOIN @perfilopciones AS T2 ON T1.perfil_id = T2.perfil_id  AND T1.sistemaopcion_id = T2.sistemaopcion_id


		-- setemos el mensaje de salida
		set @message = 'Información actualizada satisfactoriamente';

	END
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UPD_USUARIO]    Script Date: 28/06/2024 01:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE      PROCEDURE [dbo].[USP_UPD_USUARIO]
	@usuario_id int = null,
	@persona_id int = null,
	@username varchar(20) = null,
	@password varchar(150) = null,
	@numdocumento varchar(20) = null,
	@nombre_completo varchar(100) = null,
	@interno bit = null,
	@habilitado bit = null,
	@perfiles varchar(max) = null,
	@usuario_act varchar(20) = NULL,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
AS
BEGIN
	
	--Inicializa como false
	SET @error = 0;

	-- validamos si existe el usuario que desea actualizar
	IF NOT EXISTS(SELECT TOP(1) t1.* FROM [dbo].USUARIO AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  @usuario_id = t1.usuario_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'El usuario que intenta actualizar no existe';
	END

	-- validamos si el nombre de usuario ya existe
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[USUARIO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@username)) = TRIM(LOWER(t1.username)) and t1.usuario_id <> @usuario_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un usuario con el nombre ' + TRIM(LOWER(@username));
	END

	-- validamos si existe un usuario para el mismo persona_id
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[USUARIO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  @persona_id = T1.persona_id and t1.usuario_id <> @usuario_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'La persona que intenta registrar ya tiene un usuario asociado';
	END

	-- validamos si existe un usuario con el mismo numero de documento asociado
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[USUARIO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@numdocumento)) = TRIM(LOWER(t1.numdocumento)) and t1.usuario_id <> @usuario_id)
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un usuario registrado con el número de documento ' + TRIM(LOWER(@numdocumento));
	END

	-- validamos la cantidad de digitos del usuario
	IF ((select LEN(TRIM(@username))) < 5)
	BEGIN
		SET @error = 1;
		SET @message = 'El nombre de usuario debe tener como mínimo 5 digitos';
	END

	-- validamos que tenga por lo menos un perfil
	IF( (select COUNT(*) from string_split(@perfiles, ',')) <= 0 )
	BEGIN
		SET @error = 1;
		SET @message = 'Debe seleccionar un perfil como mínimo';
	END

 
	IF(@error = 0) 
	BEGIN
		
		-- 1. actualizamos la informacion del usuario
		
		UPDATE dbo.USUARIO
		set 
			persona_id = @persona_id,
			username = TRIM(LOWER(@username)),
			password = TRIM(@password),
			numdocumento = TRIM(@numdocumento),
			nombre_completo = TRIM(@nombre_completo),
			interno = @interno,
			habilitado = @habilitado,
			usuario_act = @usuario_act,
			fecha_act = GETDATE()
		where
			usuario_id = @usuario_id;


		-- 2. actualizamos los perfiles del usuario

		--Desactivamos los perfiles actuales del usuario
		update USUARIOPERFIL SET estado = 0, FECHA_ACT = GETDATE(), usuario_act = @usuario_act WHERE usuario_id = @usuario_id;

		--Declaramos una tabla temporal
		DECLARE @UsuarioPerfil TABLE
		(usuario_id int, perfil_id int)

		--insertamos los perfiles en la tabla temporal
		insert into @UsuarioPerfil (usuario_id, perfil_id)
		select @usuario_id, value from string_split(@perfiles, ',');

		--2.1 Insertamos los perfiles nuevos
		insert into dbo.USUARIOPERFIL
		(usuario_id, perfil_id, estado, usuario_reg, fecha_act)
		select 
		@usuario_id, T2.perfil_id, 1, @usuario_act, GETDATE()
		FROM
		dbo.USUARIOPERFIL AS T1 WITH(NOLOCK)
		RIGHT JOIN @UsuarioPerfil T2 ON T1.usuario_id = T2.usuario_id  AND T1.perfil_id = T2.perfil_id
		WHERE	T1.usuario_id IS NULL AND T1.perfil_id IS NULL

		-- 2.2 Actualizamos los perfiles de usuario que ya existian
		UPDATE T1
		SET 				  
		  T1.usuario_id = T2.usuario_id
		, T1.perfil_id = T2.perfil_id
		, T1.usuario_act = @usuario_act
		, T1.ESTADO = 1
		, T1.FECHA_ACT = GETDATE()
		FROM dbo.USUARIOPERFIL AS T1 WITH(NOLOCK)
		INNER JOIN @UsuarioPerfil AS T2 ON T1.usuario_id = T2.usuario_id  AND T1.perfil_id = T2.perfil_id

		-- setemos el mensaje de salida
		set @message = 'Información actualizada satisfactoriamente';

	END
END

GO
