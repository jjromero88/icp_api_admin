USE [pcm_icp_eva]
GO
/****** Object:  Table [dbo].[ENTIDADGRUPO]    Script Date: 10/06/2024 20:12:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ENTIDADGRUPO](
	[entidadgrupo_id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](10) NULL,
	[abreviatura] [varchar](50) NULL,
	[descripcion] [varchar](150) NULL,
	[estado] [bit] NULL,
	[usuario_reg] [varchar](20) NULL,
	[fecha_reg] [datetime] NULL,
	[usuario_act] [varchar](20) NULL,
	[fecha_act] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[entidadgrupo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ENTIDADGRUPO] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[ENTIDADGRUPO] ADD  DEFAULT ('sys') FOR [usuario_reg]
GO
ALTER TABLE [dbo].[ENTIDADGRUPO] ADD  DEFAULT (getdate()) FOR [fecha_reg]
GO
/****** Object:  StoredProcedure [dbo].[USP_INS_ENTIDADGRUPO]    Script Date: 10/06/2024 20:12:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE      PROCEDURE [dbo].[USP_INS_ENTIDADGRUPO]
	@codigo varchar(10) = NULL,
	@abreviatura varchar(50) = NULL, 
	@descripcion varchar(150) = NULL,
	@usuario_reg varchar(20) = NULL,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
AS
BEGIN
	
	--Inicializa como false
	SET @error = 0;

	-- validamos si existe un ENTIDADGRUPO con la misma descripcion
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[ENTIDADGRUPO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@descripcion)) = TRIM(LOWER(t1.descripcion))) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un grupo registrado con la descripción ' + TRIM(LOWER(@descripcion));
	END

	-- validamos si existe un ENTIDADGRUPO con la misma abreviatura
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[ENTIDADGRUPO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@abreviatura)) = TRIM(LOWER(t1.abreviatura))) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un grupo registrado con la abreviatura ' + TRIM(LOWER(@abreviatura));
	END

	-- validamos la cantidad de digitos del codigo
	IF ((select LEN(TRIM(@codigo))) <> 5)
	BEGIN
		SET @error = 1;
		SET @message = 'El campo codigo debe tener 5 digitos';
	END

	-- validamos si existe el mismo codigo de ENTIDADGRUPO
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[ENTIDADGRUPO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@codigo)) = TRIM(LOWER(t1.codigo))) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un grupo registrado con el codigo ' + TRIM(LOWER(@abreviatura));
	END
 
	IF(@error = 0) 
	BEGIN

		INSERT INTO dbo.[ENTIDADGRUPO] (
			codigo,
			abreviatura,
			descripcion,
			usuario_reg,
			fecha_reg
		)
		VALUES (
			@codigo,
			TRIM(@abreviatura),
			TRIM(@descripcion),
			case when @usuario_reg is null then 'sys' else @usuario_reg end,
			GETDATE()
		);

		-- setemos el mensaje de salida
		set @message = 'Información registrada satisfactoriamente';

	END
END

GO
