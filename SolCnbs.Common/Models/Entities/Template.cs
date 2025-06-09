using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolCnbs.Common.Models.Entities;

[Table("molde_documento_tramite")]
public class Template
{
    [Key]
    [Column("codigo_molde_documento")]
    public int CodigoMoldeDocumento { get; set; }
    [Column("codigo_tipo_tramite")]
    public int CodigoTipoTramite { get; set; }
    [Column("nombre_molde")]
    public string? NombreMolde { get; set; }
    [Column("documento_molde")]
    public byte[]? DocumentoMolde { get; set; }
    [Column("visibilidad")]
    public byte Visibilidad { get; set; }
    [Column("obligatorio")]
    public byte Obligatorio { get; set; }
    [Column("orden")]
    public byte Orden { get; set; }
    [Column("activo")]
    public byte Activo { get; set; }
    [Column("nombre_archivo")]
    public string? NombreArchivo { get; set; }
    [Column("tiene_campos_reemplazables")]
    public byte TieneCamposReemplazables { get; set; }
    [Column("sp_campos_reemplazables")]
    public string? SpCamposReemplazables { get; set; }
    [Column("firma_obligatoria")]
    public byte FirmaObligatoria { get; set; }
    [Column("generar_documento_descargar")]
    public bool GenerarDocumentoDescargar { get; set; }
    [Column("largo_maximo")]
    public short LargoMaximo { get; set; }
    [Column("modificado_por")]
    public int ModificadoPor { get; set; }
    [Column("ultima_modificacion")]
    public DateTime UltimaModificacion { get; set; }
    [Column("tipo_almacenamiento")]
    public byte TipoAlmacenamiento { get; set; }
   

}
