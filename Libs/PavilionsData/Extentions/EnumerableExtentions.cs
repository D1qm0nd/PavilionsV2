using System.Collections;
using PavilionsData.PavilionsModel.Tables;

namespace PavilionsData.Extentions;

public static class EnumerableExtentions
{
    /// <summary>
    /// Получить названия ролей
    /// </summary>
    /// <param name="roles"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetRoleNames(this IEnumerable<Role> roles)
    {
        var res = new List<string>();
        foreach (var role in roles)
            res.Add(role.RoleName);
        return res;
    }

    /// <summary>
    /// Получить айди роли по названию
    /// </summary>
    /// <param name="roles"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static int? GetIdRoleByName(this IEnumerable<Role> roles, string name) =>
        roles.FirstOrDefault(role => role.RoleName.ToLower() == name.ToLower())?.Id_Role;


    /// <summary>
    /// Получить названия статусов павильонов
    /// </summary>
    /// <param name="statuses"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetPavilionsStatusNames(this IEnumerable<PavilionStatus> statuses)
    {
        var res = new List<string>();
        foreach (var status in statuses)
            res.Add(status.PavilionsStatusName);
        return res;
    }


    /// <summary>
    /// Получить айди статус павильона по названию
    /// </summary>
    /// <param name="roles"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static int? GetIdPavilionStatysByName(this IEnumerable<PavilionStatus> statuses, string name) =>
        statuses.FirstOrDefault(status => status.PavilionsStatusName.ToLower() == name.ToLower())?.Id_PavilionsStatus;

    /// <summary>
    /// Получить айди павильона по номеру и айди торгового центра
    /// </summary>
    /// <param name="pavilions"></param>
    /// <param name="number"></param>
    /// <param name="idShoppingCenter"></param>
    /// <returns></returns>
    public static Pavilion? GetPavilionIdByNumberAndIdShoppingCenter(this IEnumerable<Pavilion> pavilions,
        string number, int idShoppingCenter) =>
        pavilions.FirstOrDefault(
            pavilion => pavilion.Id_ShoppingCenter == idShoppingCenter && pavilion.Number == number);

    /// <summary>
    /// Получить павильоны со стутусом
    /// </summary>
    /// <param name="pavilions"></param>
    /// <param name="idPavilionStatus"></param>
    /// <returns></returns>
    public static IEnumerable<Pavilion> GetPavilionsByStatus(this IEnumerable<Pavilion> pavilions, int idPavilionStatus)
        => pavilions.Where(pavilion => pavilion.Id_PavilionsStatus == idPavilionStatus);


    /// <summary>
    /// Получить павильоны торгового центра
    /// </summary>
    /// <param name="pavilions"></param>
    /// <param name="idShoppingCenter"></param>
    /// <returns></returns>
    public static IEnumerable<Pavilion> GetShoppingCenterPavilions(this IEnumerable<Pavilion> pavilions,
        int idShoppingCenter) =>
        pavilions.Where(pavilion => pavilion.Id_ShoppingCenter == idShoppingCenter);

    public static string? GetShoppingCenterStatusById(this IEnumerable<ShoppingCentersStatus> shoppingCentersStatuses,
        int id) =>
        shoppingCentersStatuses.FirstOrDefault(status => status.Id_ShoppingStatus == id)?.ShoppingStatusName;


    /// <summary>
    /// Получить сотрудника по айди
    /// </summary>
    /// <param name="employees"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Employee? GetEmployeeById(this IEnumerable<Employee> employees, int id) =>
        employees.FirstOrDefault(e => e.Id_Employee == id);

    /// <summary>
    /// Получить торговый центр по айди
    /// </summary>
    /// <param name="shoppingCenters"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static ShoppingCenter? GetShoppingCenterById(this IEnumerable<ShoppingCenter> shoppingCenters, int id) =>
        shoppingCenters.FirstOrDefault(sc => sc.Id_ShoppingCenter == id);

    public static City? GetCityById(this IEnumerable<City> cities, int id) =>
        cities.FirstOrDefault(city => city.Id_City == id);

    public static PavilionStatus? GetPavilionStatusById(this IEnumerable<PavilionStatus> shoppingCenters, int id) =>
        shoppingCenters.FirstOrDefault(pav => pav.Id_PavilionsStatus == id);

    /// <summary>
    /// Получить айди статус аренды по названию
    /// </summary>
    /// <param name="roles"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static int? GetIdRentalStatysByName(this IEnumerable<RentalsStatus> statuses, string name) =>
        statuses.FirstOrDefault(status => status.RentalStatusName.ToLower() == name.ToLower())?.Id_RentalStatus;

    public static IEnumerable<string> GetPavilionsNumbers(this IEnumerable<Pavilion> pavilions)
    {
        foreach (var pavilion in pavilions)
        {
            yield return pavilion.Number;
        }
    }

    public static IEnumerable<string> GetTenantsNames(this IEnumerable<Tenant> tenants)
    {
        foreach (var tenant in tenants)
        {
            yield return tenant.Name;
        }
    }


    public static Role? GetRoleByID(this IEnumerable<Role> roles, int role_id)
    {
        return roles.FirstOrDefault(role => role.Id_Role == role_id);
    }

}