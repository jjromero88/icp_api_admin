USE [pcm_icp_eva]
GO
/****** Object:  StoredProcedure [dbo].[USP_UPD_ENTIDAD_GENERALIDADES]    Script Date: 23/06/2024 14:32:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER     PROCEDURE [dbo].[USP_UPD_ENTIDAD_GENERALIDADES]
	@entidad_id int = null,
	@ubigeo_id int = null,
	@documentoestructura_id int = null,
	@modalidadintegridad_id int = null,
	@documentoestructura_doc varchar(250) = null,
	@modalidadintegridad_doc varchar(250) = null,
	@modalidadintegridad_anterior varchar(150) = null,
	@documentointegridad_desc varchar(150) = null,
	@documentointegridad_doc varchar(250) = null,
	@num_servidores int = null,
	@usuario_act varchar(20) = null,
	@error BIT = null output,
	@message NVARCHAR(500) = null output
AS
BEGIN
	
	--Inicializa como false
	SET @error = 0;

	-- validamos si existe la entidad que desea modificar
	IF NOT EXISTS(SELECT TOP(1) t1.* FROM [dbo].ENTIDAD AS t1 WITH(NOLOCK) WHERE t1.entidad_id = @entidad_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'La entidad que intenta modificar no existe';
	END
 
	-- si no ocurrio ningun error
	IF(@error = 0) 
	BEGIN
		-- actualizamos el grupo
		UPDATE dbo.[ENTIDAD]
		set 
			[ubigeo_id]						=	@ubigeo_id, 
			[documentoestructura_id]		=	@documentoestructura_id, 
			[modalidadintegridad_id]		=	@modalidadintegridad_id, 
			[documentoestructura_doc]		=	@documentoestructura_doc, 
			[modalidadintegridad_doc]		=	@modalidadintegridad_doc, 
			[modalidadintegridad_anterior]  =	@modalidadintegridad_anterior, 
			[documentointegridad_desc]		=	@documentointegridad_desc, 
			[documentointegridad_doc]		=	@documentointegridad_doc, 
			[num_servidores]				=	@num_servidores,
			[usuario_act]					=	@usuario_act,
			[fecha_act]						=	GETDATE()
		where
			entidad_id = @entidad_id;

		-- setemos el mensaje de salida
		set @message = 'Información actualizada satisfactoriamente';

	END
END

