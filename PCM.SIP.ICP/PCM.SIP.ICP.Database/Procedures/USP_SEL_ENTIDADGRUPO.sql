USE [pcm_icp_eva]
GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_ENTIDADGRUPO]    Script Date: 11/06/2024 19:30:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER     PROCEDURE [dbo].[USP_SEL_ENTIDADGRUPO](
	@entidadgrupo_id int = null,
	@filtro varchar(max) = null,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;

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
		[dbo].ENTIDADGRUPO  T1 WITH(NOLOCK)
	WHERE
		T1.estado = 1 AND
		(@entidadgrupo_id IS NULL OR T1.entidadgrupo_id = @entidadgrupo_id) AND
		(@FILTRO IS NULL OR (RTRIM(LTRIM(ISNULL(T1.codigo, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.abreviatura, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.descripcion, '')))) LIKE '%' + @filtro + '%' COLLATE Latin1_General_CI_AI);

		-- seteamos mensaje de salida
		set @message = 'Consulta exitosa';


END

