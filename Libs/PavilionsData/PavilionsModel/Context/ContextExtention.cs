using Microsoft.EntityFrameworkCore;

namespace PavilionsData.PavilionsModel.Context;

public static class ContextExtention
{
    public static int ExecuteSqlCommand(this DbContext database, string sql)
    {
        var connection = database.Database.GetDbConnection();
        var command = connection.CreateCommand();
        command.CommandText = sql;
        try
        {
            connection.Open();

            return command.ExecuteNonQuery();
        }
        catch (Exception exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static void AddRangeIdentity<T>(this DbContext context, DbSet<T> dbSet, List<T> items) where T : class
    {
        foreach (var item in items)
        {
            dbSet.Add(item);
        }
        context.SaveChanges();
    }
    
    
    
}