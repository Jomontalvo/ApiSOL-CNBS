using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolCnbs.Common.Models.Entities;

[Table("tipo_tramite")]
public class ProcedureType
{
    [Key]
    [Column("codigo_tipo_tramite")]
    public int CodigoTipoTramite { get; set; }

    [Column("nombre")]
    public string? Nombre { get; set; }

    [Column("coordinador")]
    public int? Coordinador { get; set; }

    [Column("codificador")]
    public string? Codificador { get; set; }

    [Column("ultimo_numero")]
    public int UltimoNumero { get; set; }

    [Column("texto_explicativo")]
    public string? TextoExplicativo { get; set; }

    [Column("requisitos")]
    public string? Requisitos { get; set; }

    [Column("documento_instructivo")]
    public byte[]? DocumentoInstructivo { get; set; }

    [Column("duracion_maxima")]
    public short? DuracionMaxima { get; set; }

    [Column("dias_habiles")]
    public byte? DiasHabiles { get; set; }

    [Column("activo")]
    public byte Activo { get; set; }

    [Column("permite_rechazo_previo")]
    public byte PermiteRechazoPrevio { get; set; }

    [Column("gestion_cero")]
    public bool GestionCero { get; set; }

    [Column("orden")]
    public short Orden { get; set; }

    [Column("origen_tramite")]
    public byte OrigenTramite { get; set; }

    [Column("certificado_digital")]
    public byte[]? CertificadoDigital { get; set; }

    [Column("clave_certificado")]
    public string? ClaveCertificado { get; set; }

    [Column("firma_documentos")]
    public byte FirmaDocumentos { get; set; }

    [Column("nombre_tabla_datos")]
    public string? NombreTablaDatos { get; set; }

    [Column("json_datos")]
    public string? JsonDatos { get; set; }

    [Column("sp_antes_presentar")]
    public string? SpAntesPresentar { get; set; }

    [Column("ws_antes_presentar")]
    public string? WsAntesPresentar { get; set; }

    [Column("sp_despues_presentar")]
    public string? SpDespuesPresentar { get; set; }

    [Column("ws_despues_presentar")]
    public string? WsDespuesPresentar { get; set; }

    [Column("sp_antes_aceptar")]
    public string? SpAntesAceptar { get; set; }

    [Column("ws_antes_aceptar")]
    public string? WsAntesAceptar { get; set; }

    [Column("sp_despues_aceptar")]
    public string? SpDespuesAceptar { get; set; }

    [Column("ws_despues_aceptar")]
    public string? WsDespuesAceptar { get; set; }

    [Column("sp_seleccion_responsables")]
    public string? SpSeleccionResponsables { get; set; }

    [Column("sp_antes_aprobar")]
    public string? SpAntesAprobar { get; set; }

    [Column("ws_antes_aprobar")]
    public string? WsAntesAprobar { get; set; }

    [Column("sp_antes_rechazar")]
    public string? SpAntesRechazar { get; set; }

    [Column("ws_antes_rechazar")]
    public string? WsAntesRechazar { get; set; }

    [Column("sp_despues_finalizar")]
    public string? SpDespuesFinalizar { get; set; }

    [Column("ws_despues_finalizar")]
    public string? WsDespuesFinalizar { get; set; }

    [Column("sp_antes_cambiar_fase")]
    public string? SpAntesCambiarFase { get; set; }

    [Column("ws_antes_cambiar_fase")]
    public string? WsAntesCambiarFase { get; set; }

    [Column("sp_despues_cambiar_fase")]
    public string? SpDespuesCambiarFase { get; set; }

    [Column("ws_despues_cambiar_fase")]
    public string? WsDespuesCambiarFase { get; set; }

    [Column("sp_seleccion_fases")]
    public string? SpSeleccionFases { get; set; }

    [Column("sp_estructura_datos_adicionales")]
    public string? SpEstructuraDatosAdicionales { get; set; }

    [Column("sp_obtener_datos_adicionales")]
    public string? SpObtenerDatosAdicionales { get; set; }

    [Column("requiere_encuesta")]
    public byte RequiereEncuesta { get; set; }

    [Column("tipo_tramite_siguiente_presentado")]
    public int? TipoTramiteSiguientePresentado { get; set; }

    [Column("tipo_tramite_siguiente_aprobado_total")]
    public int? TipoTramiteSiguienteAprobadoTotal { get; set; }

    [Column("tipo_tramite_siguiente_aprobado_parcial")]
    public int? TipoTramiteSiguienteAprobadoParcial { get; set; }

    [Column("tipo_tramite_siguiente_aprobado_tp")]
    public int? TipoTramiteSiguienteAprobadoTp { get; set; }

    [Column("tipo_tramite_siguiente_rechazado")]
    public int? TipoTramiteSiguienteRechazado { get; set; }

    [Column("sp_tramite_siguiente")]
    public string? SpTramiteSiguiente { get; set; }

    [Column("preguntar_tramite_siguiente")]
    public byte PreguntarTramiteSiguiente { get; set; }

    [Column("js_antes_presentar")]
    public string? JsAntesPresentar { get; set; }

    [Column("js_antes_aceptar")]
    public string? JsAntesAceptar { get; set; }

    [Column("js_antes_aprobar")]
    public string? JsAntesAprobar { get; set; }

    [Column("js_antes_rechazar")]
    public string? JsAntesRechazar { get; set; }

    [Column("js_antes_cambiar_fase")]
    public string? JsAntesCambiarFase { get; set; }

    [Column("sp_despues_crear")]
    public string? SpDespuesCrear { get; set; }

    [Column("ws_despues_crear")]
    public string? WsDespuesCrear { get; set; }

    [Column("js_antes_actualizar")]
    public string? JsAntesActualizar { get; set; }

    [Column("sp_despues_actualizar")]
    public string? SpDespuesActualizar { get; set; }

    [Column("ws_despues_actualizar")]
    public string? WsDespuesActualizar { get; set; }

    [Column("asignar_asunto_nuevos_tramites")]
    public bool AsignarAsuntoNuevosTramites { get; set; }

    [Column("mostrar_campo_detalle")]
    public bool MostrarCampoDetalle { get; set; }

    [Column("sp_despues_retirar")]
    public string? SpDespuesRetirar { get; set; }

    [Column("ws_despues_retirar")]
    public string? WsDespuesRetirar { get; set; }

    [Column("sp_obtener_documentos")]
    public string? SpObtenerDocumentos { get; set; }

    [Column("sp_obtener_tramites_derivables")]
    public string? SpObtenerTramitesDerivables { get; set; }

    [Column("solicitante_interno_agrega_subproceso")]
    public bool SolicitanteInternoAgregaSubproceso { get; set; }

    [Column("tipo_representacion")]
    public byte TipoRepresentacion { get; set; }

    [Column("modificado_por")]
    public int ModificadoPor { get; set; }

    [Column("ultima_modificacion")]
    public DateTime UltimaModificacion { get; set; }

    [Column("adicionales_modificado_por")]
    public int? AdicionalesModificadoPor { get; set; }

    [Column("ultima_modificacion_adicionales")]
    public DateTime? UltimaModificacionAdicionales { get; set; }

    [Column("sp_puede_crear")]
    public string? SpPuedeCrear { get; set; }

    [Column("sp_despues_actualizar_documento")]
    public string? SpDespuesActualizarDocumento { get; set; }

    [Column("ws_despues_actualizar_documento")]
    public string? WsDespuesActualizarDocumento { get; set; }

    [Column("sp_despues_actualizar_documento_adicional")]
    public string? SpDespuesActualizarDocumentoAdicional { get; set; }

    [Column("ws_despues_actualizar_documento_adicional")]
    public string? WsDespuesActualizarDocumentoAdicional { get; set; }

    [Column("sp_despues_enviar_mensaje")]
    public string? SpDespuesEnviarMensaje { get; set; }

    [Column("ws_despues_enviar_mensaje")]
    public string? WsDespuesEnviarMensaje { get; set; }

    [Column("js_antes_enviar_mensaje")]
    public string? JsAntesEnviarMensaje { get; set; }

    [Column("vigencia_tramite")]
    public short VigenciaTramite { get; set; }

    [Column("usar_fila_atencion_tramites")]
    public bool UsarFilaAtencionTramites { get; set; }

}
