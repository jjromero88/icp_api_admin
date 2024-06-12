USE [pcm_icp_eva]
GO
/****** Object:  StoredProcedure [dbo].[USP_UPD_ENTIDADGRUPO]    Script Date: 11/06/2024 19:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER    PROCEDURE [dbo].[USP_UPD_ENTIDADGRUPO]
	@entidadgrupo_id int = NULL,
	@abreviatura varchar(50) = NULL, 
	@descripcion varchar(150) = NULL,
	@usuario_act varchar(20) = NULL,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
AS
BEGIN
	
	--Inicializa como false
	SET @error = 0;

	-- validamos si existe un grupo con la misma descripcion
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[ENTIDADGRUPO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@descripcion)) = TRIM(LOWER(t1.descripcion)) AND @entidadgrupo_id <> t1.entidadgrupo_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un ENTIDADGRUPO registrado con la descripción ' + TRIM(LOWER(@descripcion));
	END

	-- validamos si existe un grupo con la misma abreviatura
	IF EXISTS(SELECT TOP(1) t1.* FROM [dbo].[ENTIDADGRUPO] AS t1 WITH(NOLOCK) WHERE t1.ESTADO = 1 AND  TRIM(LOWER(@abreviatura)) = TRIM(LOWER(t1.abreviatura)) AND @entidadgrupo_id <> t1.entidadgrupo_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'Ya existe un ENTIDADGRUPO registrado con la abreviatura ' + TRIM(LOWER(@abreviatura));
	END
 
	-- si no ocurrio ningun error
	IF(@error = 0) 
	BEGIN
		-- actualizamos el grupo
		UPDATE dbo.[ENTIDADGRUPO]
		set 
			abreviatura = @abreviatura,
			descripcion = @descripcion,
			usuario_act = @usuario_act,
			fecha_act = GETDATE()
		where
			entidadgrupo_id = @entidadgrupo_id;

		-- setemos el mensaje de salida
		set @message = 'Información actualizada satisfactoriamente';

	END
END

