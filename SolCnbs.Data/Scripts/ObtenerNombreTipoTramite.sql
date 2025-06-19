SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[cnfg_ObtenerNombreTipoTramite]
    @CODIGO bigint,
    --@USUARIO int,
    @RESULTADO bit OUTPUT,
    @MENSAJE varchar(1000) OUTPUT
AS

/*   COMENTARIO DE PROCEDIMIENTO
    Autor: oswaldo.montalvo@undp.org
    Proposito: Obtener el nombre de un tipo de tramite dado el cdigo
    Utilizado en: Tabla de configuracion de visibilidad de documentos Anexos
    Fecha: 08/06/2025
*/
BEGIN

    SET @RESULTADO = 0
    SET @MENSAJE = 'Verifique los datos ingresados.';

    DECLARE @NOMBRE_TIPO_TRAMITE VARCHAR(255),
	@TIPO_TRAMITE INT,
	@ParmDefinition NVARCHAR(MAX),
    @SQLString NVARCHAR(MAX);

    -- Obtengo el tipo de criterio y el puntaje
    SET @SQLString = N' SELECT @codigoTipoTramiteOUT = codigo_tipo_tramite '
					+ ' FROM [dbo].[opciones_moldes]' 
					+ ' WHERE ISNULL(codigo_tramite,0) = 0 '
					+ ' AND codigo_registro = ' 
					+ CAST(@CODIGO AS VARCHAR);

    SET @ParmDefinition = N'@codigoTipoTramiteOUT INT OUTPUT ';


    -- En @seleccion va el valor seleccionado en dispositivo
    EXEC sp_executesql @SQLString, @ParmDefinition, @codigoTipoTramiteOUT = @TIPO_TRAMITE output;

    SELECT @NOMBRE_TIPO_TRAMITE = nombre
    FROM tipo_tramite
    WHERE codigo_tipo_tramite = @TIPO_TRAMITE;

    IF ISNULL(@NOMBRE_TIPO_TRAMITE,'') = ''
	BEGIN
        SET @MENSAJE = 'No existe un tipo de trámite con el código especificado [' + CAST(@TIPO_TRAMITE AS VARCHAR) +']';
        RETURN;
    END

    UPDATE opciones_moldes
    SET nombre_tramite = @NOMBRE_TIPO_TRAMITE
    WHERE codigo_registro = @CODIGO;

    SET @MENSAJE = 'tipo de trámite encontrado y actualizado exitosamente.';
    SET @RESULTADO = 1;

END;

GRANT EXECUTE ON dbo.[cnfg_ObtenerNombreTipoTramite] TO wsServicioTramites_SOL_HN_CNBS;
GO
