USE [pcm_icp_eva]
GO
/****** Object:  StoredProcedure [dbo].[USP_DEL_ENTIDADGRUPO]    Script Date: 11/06/2024 19:28:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER     PROCEDURE [dbo].[USP_DEL_ENTIDADGRUPO](
	@entidadgrupo_id int = NULL,
	@usuario_act varchar(20) = NULL,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN
	SET @error = 0;

	-- validamos si existe el perfil que desea eliminar
	IF NOT EXISTS(SELECT TOP(1) t1.* FROM [dbo].[ENTIDADGRUPO] AS t1 WITH(NOLOCK) WHERE t1.entidadgrupo_id = @entidadgrupo_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'El grupo que desea Eliminar no existe';
	END
	
	IF(@error = 0)
	BEGIN

		--Se elimina el perfil actualizando sus datos de auditoria

		UPDATE 
		[dbo].[ENTIDADGRUPO]
		SET 
		estado = 0,
		usuario_act = @usuario_act
		WHERE
		entidadgrupo_id = @entidadgrupo_id

		-- setemos el mensaje de salida
		set @message = 'Información eliminada satisfactoriamente';

	END


END

