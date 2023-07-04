using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PavilionsData.PavilionsModel.Tables;

[Table("Cities")]
public class City
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id_City { get; set; }
    [MaxLength(120)] public string CityName { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }
}