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
}