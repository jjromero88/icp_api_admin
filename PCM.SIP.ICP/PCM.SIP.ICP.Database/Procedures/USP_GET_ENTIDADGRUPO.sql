USE [pcm_icp_eva]
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_ENTIDADGRUPO]    Script Date: 11/06/2024 18:59:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROCEDURE [dbo].[USP_GET_ENTIDADGRUPO](
	@entidadgrupo_id INT,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0

	-- validamos si existe el grupo que desea consultar
	IF NOT EXISTS(SELECT TOP(1) t1.* FROM [dbo].[ENTIDADGRUPO] AS t1 WITH(NOLOCK) WHERE t1.entidadgrupo_id = @entidadgrupo_id) 
	BEGIN
		SET @error = 1;
		SET @message = 'El grupo que desea consultar no existe';
	END
	
	IF(@error = 0)
	BEGIN
		SELECT
			 T1.entidadgrupo_id, 
			 T1.codigo, 
			 T1.abreviatura, 
			 T1.descripcion, 
			 T1.estado, 
			 T1.usuario_reg, 
			 T1.fecha_reg, 
			 T1.usuario_act, 
			 T1.fecha_act 
		FROM 
			[dbo].[ENTIDADGRUPO]  T1 WITH(NOLOCK)
		WHERE
			T1.entidadgrupo_id = @entidadgrupo_id;

		set @message = 'Consulta exitosa';
	END


END

