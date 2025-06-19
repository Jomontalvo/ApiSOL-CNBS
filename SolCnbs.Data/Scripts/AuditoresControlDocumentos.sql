USE [SOL_HN_CNBS]
GO

/****** Object:  StoredProcedure [dbo].[cnfg_controlardocumentos]    Script Date: 18/6/2025 13:34:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE
	OR

ALTER PROCEDURE [dbo].[cnfg_controlardocumentos]
	@CODIGO BIGINT,
	@TIPO_TRAMITE INT,
	@ESTADO TINYINT,
	@FASE INT,
	@USUARIO INT,
	@USUARIO_RESPONSABLE INT,
	@USUARIO_SOLICITANTE INT
AS
BEGIN
	/* COMENTARIO DE PROCEDIMIENTO
    Propósito:  Visibilizar documentos segun sea la seleccion del ciudadano
    Tramites: Varios de registro de auditores
    Autor: oswaldo.montalvo@undp.org */
	/* Si el usuario no es solicitanto no debo cambiar nada de lo que trae la tabla de documentos*/
	IF @USUARIO != @USUARIO_SOLICITANTE
		RETURN

	/* Estructura parcial de la tabla temporal de documentos que arma el procedimiento 
    llamador st_ObtenerDocumentosTramite
    
    CREATE TABLE #DOC(
    codigo_molde_documento int,
    obligatorio bit,
    editable bit not null default 0,
    visibilidad tinyint,
    tiene_formato bit,
    nombre_molde varchar(255),
    nombre_completo varchar(255),
    tipo_usuario tinyint,
    nombre_archivo varchar(255),
    tiene_campos_reemplazables tinyint,
    sp_campos_reemplazables varchar(100),
    firma_obligatoria tinyint,
    generar_documento_descargar bit,
    largo_maximo smallint
    ); 
  */
	DECLARE @NOMBRE_TABLA VARCHAR(255),
		@VALOR VARCHAR(max);
	DECLARE @SQLString NVARCHAR(500);
	DECLARE @ParmDefinition NVARCHAR(500);
	DECLARE @TABLA TABLE (
		codigo_molde_documento INT,
		valor VARCHAR(1000),
		visibilidad BIT
		);
	/* Variales para el cursor */
	DECLARE @CNFG_MOLDE_DOCUMENTO INT,
		@CNFG_NOMBRE_CAMPO VARCHAR(255),
		@CNFG_VALOR_SELECCIONADO VARCHAR(255),
		@CNFG_VISIBILIDAD BIT

	-- Obtengo el nombre de la tabla de datos adicionales segun el tipo de tramite
	SELECT @NOMBRE_TABLA = tt.nombre_tabla_datos
	FROM tipo_tramite AS tt(NOLOCK)
	WHERE tt.codigo_tipo_tramite = @TIPO_TRAMITE;

	DECLARE config_moldes_cursor CURSOR LOCAL FORWARD_ONLY
	FOR
	SELECT CAST(LEFT(molde_documento, CHARINDEX('-', molde_documento) - 1) AS INT),
		nombre_campo,
		valor_seleccionado,
		visibilidad
	FROM [dbo].opciones_moldes
	WHERE CAST(LEFT(tipo_tramite, CHARINDEX('-', tipo_tramite) - 1) AS INT) = @TIPO_TRAMITE
		AND ISNULL(activo, 0) = 1;

	OPEN config_moldes_cursor

	FETCH NEXT
	FROM config_moldes_cursor
	INTO @CNFG_MOLDE_DOCUMENTO,
		@CNFG_NOMBRE_CAMPO,
		@CNFG_VALOR_SELECCIONADO,
		@CNFG_VISIBILIDAD

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @SQLString = '';
		SET @ParmDefinition = '';

		-- Para debug
		PRINT CONCAT('Molde:',@CNFG_MOLDE_DOCUMENTO)
		PRINT CONCAT('Campo:', @CNFG_NOMBRE_CAMPO)
		PRINT CONCAT('Valor:', @CNFG_VALOR_SELECCIONADO)
		PRINT CONCAT('Visibilidad:', @CNFG_VISIBILIDAD)
		PRINT '------------------'

		SET @SQLString = N' SELECT @valorOUT = ' + CAST(@CNFG_NOMBRE_CAMPO AS VARCHAR(255)) + ' FROM ' + @NOMBRE_TABLA + ' WHERE codigo_tramite = ' + CONVERT(VARCHAR(255), @CODIGO);
		SET @ParmDefinition = N'@valorOUT VARCHAR(255) OUTPUT';

		PRINT @SQLString;

		EXEC sp_executesql @SQLString,
			@ParmDefinition,
			@valorOUT = @VALOR OUTPUT;

		PRINT 'Valor actual => ' + ISNULL(@VALOR, 'NULL');

		IF @VALOR IS NOT NULL
			AND UPPER(TRIM(@VALOR)) IN (
				SELECT Valor
			FROM [dbo].[fn_ConvertirDoblePipeEnTablaString](@CNFG_VALOR_SELECCIONADO)
				)
		BEGIN
			PRINT 'Entra al control por True'
			INSERT INTO @TABLA
				(
				codigo_molde_documento,
				valor,
				visibilidad
				)
			SELECT codigo_molde_documento,
				nombre_molde,
				@CNFG_VISIBILIDAD
			FROM molde_documento_tramite
			WHERE codigo_tipo_tramite = @TIPO_TRAMITE
				AND codigo_molde_documento = @CNFG_MOLDE_DOCUMENTO
		END
		ELSE
		BEGIN
			PRINT 'Entra al control por False'
			INSERT INTO @TABLA
				(
				codigo_molde_documento,
				valor,
				visibilidad
				)
			SELECT codigo_molde_documento,
				nombre_molde,
				1 - @CNFG_VISIBILIDAD
			FROM molde_documento_tramite
			WHERE codigo_tipo_tramite = @TIPO_TRAMITE
				AND codigo_molde_documento = @CNFG_MOLDE_DOCUMENTO
		END

		PRINT '-------- NEXT ----------'

		FETCH NEXT
		FROM config_moldes_cursor
		INTO @CNFG_MOLDE_DOCUMENTO,
			@CNFG_NOMBRE_CAMPO,
			@CNFG_VALOR_SELECCIONADO,
			@CNFG_VISIBILIDAD
	END

	CLOSE config_moldes_cursor;

	DEALLOCATE config_moldes_cursor;

	--SELECT * FROM @TABLA;
	/*Finalmente elimino de la tabla temporal de documentos que viene del SP llamador 
		todos aquellos documentos que no estén en la tabla que acabo de llenar*/
	DELETE #DOC
		/*Quito los que no tienen documentos y son de ingreso del ciudadano */
		WHERE obligatorio IN (0, 10, 11, 13)
		AND codigo_documento IS NULL
		AND codigo_molde_documento IN (
				SELECT md.codigo_molde_documento
		FROM molde_documento_tramite md
			INNER JOIN (
					SELECT codigo_molde_documento,
				visibilidad
			FROM @TABLA
			WHERE ISNULL(visibilidad, 0) = 0
					) l ON md.codigo_molde_documento = l.codigo_molde_documento
		WHERE codigo_tipo_tramite = @TIPO_TRAMITE
				)
	-- Pongo obligatorio todo lo que inclui en mi tabla de control
	UPDATE #DOC
		SET obligatorio = 1
		WHERE codigo_molde_documento IN (
				SELECT md.codigo_molde_documento
	FROM molde_documento_tramite md
		INNER JOIN (
					SELECT codigo_molde_documento, visibilidad
		FROM @TABLA
		WHERE  ISNULL(visibilidad, 0) = 1
					) l ON md.codigo_molde_documento = l.codigo_molde_documento
	WHERE codigo_tipo_tramite = @TIPO_TRAMITE
				)
END

GRANT EXECUTE 
	ON [dbo].[cnfg_controlardocumentos]
	TO [wsServicioTramites_SOL_HN_CNBS]
---
SELECT *
FROM tramite

SELECT codigo_tramite,
	calidad_actuante,
	categoria_solicitud,
	origen_firma
FROM datos_adicionales_1

SELECT codigo_molde,
	nombre_campo,
	valor_seleccionado,
	visibilidad,
	activo
FROM [dbo].opciones_moldes
WHERE codigo_tipo_tramite = 1

--
EXEC registroauditores_controlardocumentos @CODIGO = 36,
	@TIPO_TRAMITE = 1,
	@ESTADO = 0,
	@FASE = 1,
	@USUARIO = 5,
	@USUARIO_RESPONSABLE = 0,
	@USUARIO_SOLICITANTE = 5

EXEC st_ObtenerDocumentosTramite @CODIGO = 36,
	@USUARIO = 5

SELECT *
FROM tramite

GRANT EXECUTE
	ON [dbo].[registroauditores_controlardocumentos]
	TO [wsServicioTramites_SOL_HN_CNBS]
