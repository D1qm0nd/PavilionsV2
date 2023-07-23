using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PavilionsData.PavilionsModel.Tables;

#nullable disable
/// <summary>
/// Павильон
/// </summary>
///<params>
/// <param name="Id_Pavilion">уникальный идентификатор павильона</param>
/// <param name="ShopCenterName">название ТЦ</param>
/// <param name="Number">номер павильона</param>
/// <param name="Floar">этаж</param>
/// <param name="Status">статус</param>
/// <param name="Area">площадь</param>
/// <param name="Price">стоимоть за кв.м.</param>
/// <param name="AddedValueCoefficient">коэффициент добавочной стоимости</param>
/// </params>
[Table("Pavilions")]
public class Pavilion
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_Pavilion { get; set; }

    [ForeignKey("PavilionStatus")]
    public int Id_PavilionsStatus { get; set; }

    [ForeignKey("ShoppingCenter")]
    [MaxLength(80)] public int Id_ShoppingCenter { get; set; }
    [MaxLength(3)] public string Number { get; set; }
    public int Floor { get; set; }
    public double Area { get; set; }
    public double Price { get; set; }
    public double AddedValueCoefficient { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }
    
    [JsonIgnore] public PavilionStatus PavilionStatus { get; set; }

    [JsonIgnore] public ShoppingCenter ShoppingCenter { get; set; }

    public Pavilion()
    {
        
    }
    
    public Pavilion(int idPavilion, int idShoppingCenter, int idPavilionsStatus, [MaxLength(3)] string number,
        double area, double price, double avc)
    {
        Id_Pavilion = idPavilion;
        Id_ShoppingCenter = idShoppingCenter;
        Number = number;
        Id_PavilionsStatus = idPavilionsStatus;
        Area = area;
        Price = price;
        AddedValueCoefficient = avc;
    }
}