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


}
