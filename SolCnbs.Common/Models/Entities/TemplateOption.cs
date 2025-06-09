using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolCnbs.Common.Models.Entities;

[Table("opciones_moldes")]
public class TemplateOption
{
    [Key]
    [Column("codigo_registro")]
    public Int64 CodigoRegistro { get; set; }

    [Column("codigo_tramite")]
    public Int64? CodigoTramite { get; set; }

    [Column("codigo_usuario")]
    public int CodigoUsuario { get; set; }

    [Column("fecha_creacion")]
    public DateTime FechaCreacion { get; set; }

    [Column("usuario_modificado_por")]
    public int UsuarioModificadoPor { get; set; }

    [Column("fecha_ultima_modificacion")]
    public DateTime FechaUltimaModificacion { get; set; }

    [Column("codigo_tipo_tramite")]
    public int? CodigoTipoTramite { get; set; }

    [Column("nombre_tramite")]
    public string? NombreTramite { get; set; }

    [Column("nombre_campo")]
    public string? NombreCampo { get; set; }

    [Column("valor_seleccionado")]
    public string? ValorSeleccionado { get; set; }

    [Column("codigo_molde")]
    public string? CodigoMolde { get; set; }

    [Column("nombre_molde")]
    public string? NombreMolde { get; set; }

    [Column("visibilidad")]
    public bool? Visibilidad { get; set; }

    [Column("activo")]
    public bool? Activo { get; set; }

}
