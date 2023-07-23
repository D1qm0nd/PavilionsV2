using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PavilionsData.PavilionsModel.Tables;

[Table("Roles")]
public class Role
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_Role { get; set; }
    [MaxLength(13)] public string RoleName { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }

    
}