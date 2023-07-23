using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PavilionsData.PavilionsModel.Tables;

[Table("PavilionsStatuses")]
public class PavilionStatus
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_PavilionsStatus { get; set; }
    [MaxLength(13)] public string PavilionsStatusName { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }
}