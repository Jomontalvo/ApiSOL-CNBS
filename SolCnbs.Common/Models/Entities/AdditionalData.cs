using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolCnbs.Common.Models.Entities;

[Table("datos_adicionales_1")]
public class AdditionalData
{
    [Key]
    [Column("codigo_tramite")]
    public long CodigoTramite { get; set; }

    [Column("indicacion_nombre_firma")]
    public bool? IndicacionNombreFirma { get; set; }

    [Column("indicaciones_nombre_personas")]
    public bool? IndicacionesNombrePersonas { get; set; }

    [Column("indicaciones_identificaciones")]
    public bool? IndicacionesIdentificaciones { get; set; }

    [Column("indicaciones_varios")]
    public bool? IndicacionesVarios { get; set; }

    [Column("indicaciones_generales")]
    public bool? IndicacionesGenerales { get; set; }

    [Column("categoria_solicitud")]
    public string? CategoriaSolicitud { get; set; }

    [Column("calidad_actuante")]
    public string? CalidadActuante { get; set; }

    [Column("nombre_apoderado")]
    public string? NombreApoderado { get; set; }

    [Column("email_apoderado")]
    public string? EmailApoderado { get; set; }

    [Column("telefono_apoderado")]
    public string? TelefonoApoderado { get; set; }

    [Column("carnet_cah")]
    public byte[]? CarnetCah { get; set; }

    [Column("nombre_firma")]
    public string? NombreFirma { get; set; }

    [Column("nombre_firma_nr")]
    public string? NombreFirmaNr { get; set; }

    [Column("direccion_firma")]
    public string? DireccionFirma { get; set; }

    [Column("email_firma")]
    public string? EmailFirma { get; set; }

    [Column("telefono_firma")]
    public string? TelefonoFirma { get; set; }

    [Column("origen_firma")]
    public string? OrigenFirma { get; set; }

    [Column("rtn_firma")]
    public string? RtnFirma { get; set; }

    [Column("imagen_rtn_firma")]
    public byte[]? ImagenRtnFirma { get; set; }

    [Column("personal_firma")]
    public bool? PersonalFirma { get; set; }

    [Column("personal_secundario")]
    public bool? PersonalSecundario { get; set; }

    [Column("tabla_socios")]
    public bool? TablaSocios { get; set; }

    [Column("total_aporte")]
    public float? TotalAporte { get; set; }

    [Column("total_porcentaje")]
    public float? TotalPorcentaje { get; set; }

    [Column("numero_poliza")]
    public string? NumeroPoliza { get; set; }

    [Column("aseguradora")]
    public string? Aseguradora { get; set; }

    [Column("cobertura")]
    public string? Cobertura { get; set; }

    [Column("inicio_cobertura")]
    public DateTime? InicioCobertura { get; set; }

    [Column("fin_cobertura")]
    public DateTime? FinCobertura { get; set; }

    [Column("cartera_clientes")]
    public bool? CarteraClientes { get; set; }

    [Column("total_lempiras")]
    public float? TotalLempiras { get; set; }

    [Column("total_ingresos")]
    public float? TotalIngresos { get; set; }

    [Column("detalle_equipo")]
    public bool? DetalleEquipo { get; set; }

    [Column("texto7_17")]
    public bool? Texto717 { get; set; }

    [Column("lectura_declaracion")]
    public bool? LecturaDeclaracion { get; set; }

    [Column("texto7_18")]
    public bool? Texto718 { get; set; }

    [Column("info_adicional")]
    public bool? InfoAdicional { get; set; }

    [Column("documentos_soporte_analisis")]
    public bool? DocumentosSoporteAnalisis { get; set; }

    [Column("resultado_analisis")]
    public bool? ResultadoAnalisis { get; set; }

    [Column("total_puntos")]
    public string? TotalPuntos { get; set; }

    [Column("categoria_a_otorgar")]
    public string? CategoriaAOtorgar { get; set; }

    [Column("actualizado_al")]
    public DateTime? ActualizadoAl { get; set; }

    [Column("motivo_fecha")]
    public string? MotivoFecha { get; set; }

    [Column("autorizacion_auditar")]
    public string? AutorizacionAuditar { get; set; }

    [Column("tiene_registro_previo")]
    public string? TieneRegistroPrevio { get; set; }
    [Column("codigo_documento")]

    public string? CodigoDocumento { get; set; }
}
