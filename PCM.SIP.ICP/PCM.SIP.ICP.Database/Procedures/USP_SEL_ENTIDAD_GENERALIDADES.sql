USE [pcm_icp_eva]
GO
/****** Object:  StoredProcedure [dbo].[USP_SEL_ENTIDAD_GENERALIDADES]    Script Date: 23/06/2024 14:45:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER     PROCEDURE [dbo].[USP_SEL_ENTIDAD_GENERALIDADES](
	@entidad_id int = null,
	@entidadgrupo_id int = null,
	@entidadsector_id int = null,
	@ubigeo_id int = null,
	@documentoestructura_id int = null,
	@modalidadintegridad_id int = null,
	@filtro varchar(max) = null,
	@error BIT = NULL OUTPUT,
	@message NVARCHAR(500) = NULL OUTPUT
)
AS
BEGIN

	set @error = 0;

	SELECT
		  T1.[entidad_id]
		, T1.[entidadgrupo_id]
		, T1.[entidadsector_id]
		, T1.[modalidadintegridad_id]
		, T1.[ubigeo_id]
		, T1.[numero_ruc]
		, T1.[codigo]
		, T1.[acronimo]
		, T1.[nombre]
		, T1.[estado]
		, T1.[usuario_reg]
		, T1.[fecha_reg]
		, T1.[usuario_act]
		, T1.[fecha_act]
		, T2.[codigo]				as	entidadgrupo_codigo
		, T2.[descripcion]			as	entidadgrupo_descripcion
		, T2.[abreviatura]			as	entidadgrupo_abreviatura
		, T3.[codigo]				as	entidadsector_codigo
		, T3.[descripcion]			as	entidadsector_descripcion
		, T3.[abreviatura]			as	entidadsector_abreviatura
		, T4.[departamento]			as	ubigeo_departamento
		, T4.[provincia]			as	ubigeo_provincia
		, T4.[distrito]				as	ubigeo_distrito
		, T5.[codigo]				as	doccumentoestructura_codigo
		, T5.[abreviatura]			as	doccumentoestructura_abreviatura
		, T5.[descripcion]			as	doccumentoestructura_descripcion
		, T6.[codigo]				as	modalidadintegridad_codigo
		, T6.[abreviatura]			as	modalidadintegridad_abreviatura
		, T6.[descripcion]			as	modalidadintegridad_descripcion
	FROM 
				   [dbo].[ENTIDAD]				T1	WITH(NOLOCK)
		INNER JOIN [dbo].ENTIDADGRUPO			T2	WITH(NOLOCK) ON T1.entidadgrupo_id			= T2.entidadgrupo_id
		INNER JOIN [dbo].ENTIDADSECTOR			T3	WITH(NOLOCK) ON T1.entidadsector_id			= T3.entidadsector_id
		INNER JOIN [dbo].[UBIGEO]				T4  WITH(NOLOCK) ON T1.ubigeo_id				= T4.ubigeo_id
		INNER JOIN [dbo].[DOCUMENTOESTRUCTURA]  T5	WITH(NOLOCK) ON T1.documentoestructura_id	= T5.documentoestructura_id
		INNER JOIN [dbo].[MODALIDADINTEGRIDAD]	T6	WITH(NOLOCK) ON T1.modalidadintegridad_id	= T1.modalidadintegridad_id
	WHERE
		T1.estado = 1 AND
		(@entidad_id IS NULL OR T1.entidad_id = @entidad_id) AND
		(@FILTRO IS NULL OR (RTRIM(LTRIM(ISNULL(T1.nombre, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.acronimo, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.codigo, ''))) + ' ' +
			RTRIM(LTRIM(ISNULL(T1.numero_ruc, '')))) LIKE '%' + @filtro + '%' COLLATE Latin1_General_CI_AI);

	-- seteamos mensaje de salida
	set @message = 'Consulta exitosa';


END

