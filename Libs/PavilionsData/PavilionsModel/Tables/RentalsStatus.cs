using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PavilionsData.PavilionsModel.Tables;

[Table("RentalsStatuses")]
public class RentalsStatus
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_RentalStatus { get; set; }
    [MaxLength(13)] public string RentalStatusName { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }


}