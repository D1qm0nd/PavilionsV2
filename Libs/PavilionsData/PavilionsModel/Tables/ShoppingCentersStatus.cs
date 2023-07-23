using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PavilionsData.PavilionsModel.Tables;

[Table("ShoppingCentersStatuses")]
public class ShoppingCentersStatus
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_ShoppingStatus { get; set; }
    [MaxLength(13)] public string ShoppingStatusName { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }
    
    
}