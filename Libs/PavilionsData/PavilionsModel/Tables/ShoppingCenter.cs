using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace PavilionsData.PavilionsModel.Tables;

/// <summary>
/// Торговый центр
/// </summary>
/// <params>
/// <param name="Id_ShoppingCeter">уникальный идентификатор ТЦ</param>
/// <param name="Name">название ТЦ</param>
/// <param name="Status">статус ТЦ</param>
/// <param name="PavilionsCount">количество павильонов</param>
/// <param name="City">город</param>
/// <param name="Price">стоимость</param>
/// <param name="AddedValueCoefficient">коэффициент добавочной стоимости</param>
/// <param name="FloorsNumber">этажность ТЦ</param>
/// <param name="Picture">изображение ТЦ</param>
/// </params>
[Table("ShoppingCenters")]
public class ShoppingCenter
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id_ShoppingCenter { get; set; }
    [MaxLength(80), MinLength(1)] public string Name { get; set; }
    public int Id_ShoppingCenterStatus { get; set; }
    public int PavilionsCount { get; set; }
    public int Id_City { get; set; }
    public double Price { get; set; }
    public double AddedValueCoefficient { get; set; }
    public int FloorsNumber { get; set; }
    public byte[]? Photo { get; set; }
    [MaxLength(7)] public string? RecordStatus { get; set; }
    
}