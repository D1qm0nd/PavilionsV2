using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PavilionsData.PavilionsModel.Tables;

#nullable disable

[Table("Rentals")]
public class Rental
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_Rental { get; set; }
    [ForeignKey("Tenant")]
    public int Id_Tenant { get; set; }
    [ForeignKey("Pavilion")] public int Id_Pavilion { get; set; }
    [ForeignKey("Employee")] public int Id_Employee { get; set; }
    [ForeignKey("RentalsStatus")] public int Id_RentalStatus { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? AdditionalInfo { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }
    [JsonIgnore] public Tenant Tenant { get; set; }
    [JsonIgnore] public Pavilion Pavilion { get; set; }
    [JsonIgnore] public Employee Employee { get; set; }
    [JsonIgnore] public RentalsStatus RentalsStatus { get; set; }
}