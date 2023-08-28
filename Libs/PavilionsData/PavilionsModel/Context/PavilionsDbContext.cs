using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using Encrypting;
using Microsoft.EntityFrameworkCore;
using PavilionsData.Exceptions;
using PavilionsData.Extentions;
using PavilionsData.PavilionsModel.Balvanka;
using PavilionsData.PavilionsModel.Tables;
using PavilionsData.Resources;

namespace PavilionsData.PavilionsModel.Context;

public class PavilionsDbContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<RentalsStatus> RentalsStatuses { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Pavilion> Pavilions { get; set; }
    public DbSet<ShoppingCenter> ShoppingCenters { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<PavilionStatus> PavilionsStatuses { get; set; }
    public DbSet<ShoppingCentersStatus> ShoppingCentersStatuses { get; set; }
    public DbSet<Log> Logs { get; set; }   


    public PavilionsDbContext() : base()
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try 
        {
            var connection_string = Environment.GetEnvironmentVariable("PAVILIONS_CONNECTION");
            if (connection_string == null || connection_string.Equals(string.Empty))
                throw new ConnectionStringExcepiton("PAVILIONS_CONNECTION является некорректной, проверьте значение в переменной среде");
            optionsBuilder.UseSqlServer(connection_string);
        }
        catch (ConnectionStringExcepiton ex) 
        {
            throw ex;
        }
        catch (Exception ex) 
        {
            throw ex;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public bool Register(Employee employee)
    {
        if (employee.isNotFull()) throw new ArgumentException();
        Encrypt(employee);
        if (Employees.Any(e => e.Login == employee.Login)) throw new RegisterException();
        try
        {
            employee.Id_Employee = Employees.Max(employee => employee.Id_Employee) + 1;
            this.Database.BeginTransaction();
            Employees.Add(employee);
            this.Database.CommitTransaction();
            SaveChanges();
            return true;
        }
        catch
        {
            this.Database.RollbackTransaction();
            return false;
        }
    }

    public Employee? Login(Employee employee)
    {
        Encrypt(employee);
        Employee? res;
        var req = Employees.Where(e => e.Login == employee.Login && e.Password == employee.Password);
        res = req.First();
        return res;
    }

    private void Encrypt(Employee employee)
    {
        employee.Password = PasswordEncryptor.Encrypt(employee.Password);
    }

    public void AddPavilion(Pavilion pavilion)
    {
        if (Pavilions.Any(_ => _.Number == pavilion.Number) &&
            Pavilions.Any(_ => _.Id_ShoppingCenter == pavilion.Id_ShoppingCenter))
            throw new RecordExistingException("Павильон с таким номером уже существует в заданном ТЦ");

        pavilion.Id_Pavilion = Pavilions.Max(_ => _.Id_Pavilion) + 1;
        Pavilions.Add(pavilion);
        SaveChanges();
    }

    public  void RentPavilion( int pavilion_ID, TenantInfo tenantInfo, int employee_ID, int rentStatus_ID, DateTime startDate, DateTime endDate)
    {
        try
        {
            var query = $"RentPavilion @ID_Pavilion={pavilion_ID},  @ID_Tennant={tenantInfo.Id}, @ID_Employee={employee_ID}, @ID_Status={rentStatus_ID}, @Start='{startDate}', @End='{endDate}', @AdditionalInfo='{JsonSerializer.Serialize(tenantInfo)}'";
            this.ExecuteSqlCommand(query);
        }
        catch (Exception ex)
        {
#if DEBUG
            {
                throw new RentException("Павильон не является доступным для аренды\n" + ex.InnerException);
            }
#else
            {
                throw new RentException("Павильон не является доступным для аренды");
            }
#endif
        }
    }


    public void LoadData()
    {
        try
        {
            Cities.AddRange(DataWorker.LoadJson<City>(TablesData.Cities)!);
            Roles.AddRange(DataWorker.LoadJson<Role>(TablesData.Roles)!);
            RentalsStatuses.AddRange(DataWorker.LoadJson<RentalsStatus>(TablesData.RentalsStatuses)!);
            ShoppingCentersStatuses.AddRange(
                DataWorker.LoadJson<ShoppingCentersStatus>(TablesData.ShoppingCentersStatuses)!);
            PavilionsStatuses.AddRange(DataWorker.LoadJson<PavilionStatus>(TablesData.PavilionsStatuses)!);
            Tenants.AddRange(DataWorker.LoadJson<Tenant>(TablesData.Tenants)!);
            ShoppingCenters.AddRange(DataWorker.LoadJson<ShoppingCenter>(TablesData.ShoppingCenters)!);
            Pavilions.AddRange(DataWorker.LoadJson<Pavilion>(TablesData.Pavilions)!);
            Employees.AddRange(DataWorker.LoadJson<Employee>(TablesData.Employees)!);
            Rentals.AddRange(DataWorker.LoadJson<Rental2>(TablesData.Rentals).ToRental().ToList());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }


        SaveChanges();
    }
}