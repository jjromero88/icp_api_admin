USE [pcm_icp_eva]
GO
/****** Object:  StoredProcedure [dbo].[USP_INS_ENTIDADGRUPO]    Script Date: 11/06/2024 18:52:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER    PROCEDURE [dbo].[USP_INS_ENTIDADGRUPO]
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
 
	IF(@error = 0) 
	BEGIN
	
		-- insertamos el grupo de la entidad
		INSERT INTO dbo.[ENTIDADGRUPO] (
			codigo,
			abreviatura,
			descripcion,
			usuario_reg,
			fecha_reg
		)
		VALUES (
			(select RIGHT('00000' + CAST(MAX(entidadgrupo_id) + 1 AS VARCHAR(5)), 5) from dbo.[ENTIDADGRUPO] with(nolock)),
			TRIM(@abreviatura),
			TRIM(@descripcion),
			case when @usuario_reg is null then 'sys' else @usuario_reg end,
			GETDATE()
		);

		-- setemos el mensaje de salida
		set @message = 'Información registrada satisfactoriamente';

	END
END

