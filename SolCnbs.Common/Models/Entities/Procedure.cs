using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolCnbs.Common.Models.Entities;

[Table("tramite")]
public class Procedure
{
    [Key]
    [Column("codigo_tramite")]
    public long CodigoTramite { get; set; }

    [Column("codigo_tipo_tramite")]
    public int CodigoTipoTramite { get; set; }

    [Column("codigo_fase")]
    public int? CodigoFase { get; set; }

    [Column("estado")]
    public byte Estado { get; set; }

    [Column("solicitante")]
    public int Solicitante { get; set; }

    [Column("responsable")]
    public int? Responsable { get; set; }

    [Column("titulo_tramite")]
    public string? TituloTramite { get; set; }

    [Column("detalle_tramite")]
    public string? DetalleTramite { get; set; }

    [Column("codigo_codificador")]
    public string? CodigoCodificador { get; set; }

    [Column("fecha_solicitud")]
    public DateTime? FechaSolicitud { get; set; }

    [Column("fecha_inicio")]
    public DateTime? FechaInicio { get; set; }

    [Column("fecha_fin_esperada")]
    public DateTime? FechaFinEsperada { get; set; }

    [Column("fecha_fin")]
    public DateTime? FechaFin { get; set; }

    [Column("texto_gestion_final")]
    public string? TextoGestionFinal { get; set; }

    [Column("resumen_gestion")]
    public string? ResumenGestion { get; set; }

    [Column("proxima_accion")]
    public string? ProximaAccion { get; set; }

    [Column("fecha_proxima_accion")]
    public DateTime? FechaProximaAccion { get; set; }

    [Column("codigo_tramite_origen")]
    public long? CodigoTramiteOrigen { get; set; }

    [Column("tiene_encuesta")]
    public bool TieneEncuesta { get; set; }

    [Column("ingresa_datos_solicitante")]
    public byte IngresaDatosSolicitante { get; set; }

    [Column("representado")]
    public int? Representado { get; set; }

    [Column("fecha_ultimo_mensaje")]
    public DateTime? FechaUltimoMensaje { get; set; }

    [Column("mensaje_sin_revisar_solicitante")]
    public bool MensajeSinRevisarSolicitante { get; set; }

    [Column("mensaje_sin_revisar_responsable")]
    public bool MensajeSinRevisarResponsable { get; set; }

    [Column("fecha_vigencia")]
    public DateTime? FechaVigencia { get; set; }

    [Column("fecha_asignacion_responsable")]
    public DateTime? FechaAsignacionResponsable { get; set; }
}
