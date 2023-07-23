using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PavilionsData.PavilionsModel.Tables;

namespace PavilionsData.PavilionsModel.Balvanka;

#nullable disable

public class Rental2
{
    public int Id_Rental { get; set; }
    public int Id_Tenant { get; set; }
    public int Id_ShoppingCenter { get; set; }
    public int Id_Pavilion { get; set; }
    public int Id_Employee { get; set; }
    public int Id_RentalStatus { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string? AdditionalInfo { get; set; }
    public string? RecordStatus { get; set; }
}

public static class Rental2_Extentions
{
    public static Rental ToRental(this Rental2 balvanka) => new Rental()
    {
        Id_Rental = balvanka.Id_Rental,
        Id_RentalStatus = balvanka.Id_RentalStatus,
        Id_Tenant = balvanka.Id_Tenant,
        Id_Pavilion = balvanka.Id_Pavilion,
        Id_Employee = balvanka.Id_Employee,
        EndDate = DateTime.Parse(balvanka.EndDate),
        StartDate = DateTime.Parse(balvanka.StartDate)
    };

    public static IEnumerable<Rental> ToRental(this IEnumerable<Rental2> enumBalvanka)
    {
        var list = new List<Rental>();
        foreach (var balv in enumBalvanka)
        {
            var nwr = balv.ToRental();
            list.Add(nwr);
        }
        return list;
    }
}