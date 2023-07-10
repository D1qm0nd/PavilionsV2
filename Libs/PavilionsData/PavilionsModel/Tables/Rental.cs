using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PavilionsData.PavilionsModel.Tables;

#nullable disable

[Table("Rentals")]
public class Rental
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_Rental { get; set; }
    public int Id_Tenant { get; set; }
    public int Id_ShoppingCenter { get; set; } 
    public int Id_Pavilion { get; set; }
    public int Id_Employee { get; set; }
    public int Id_RentalStatus { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public string? AdditionalInfo { get; set; }
    
    [MaxLength(7)] public string? RecordStatus { get; set; }
    
    
}