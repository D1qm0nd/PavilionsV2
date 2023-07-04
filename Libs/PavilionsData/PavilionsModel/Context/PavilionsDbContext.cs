using Encrypting;
using Microsoft.EntityFrameworkCore;
using PavilionsData.Exceptions;
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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(
            @"Server=LOCALHOST; Initial Catalog=PavilionsDB; Integrated Security=True; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=true");
    // optionsBuilder.UseSqlServer(@"Data Source=mssql-server,1433; User ID = SA; Password = DB_Manager; initial catalog=PavilionsDB;  TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasOne<Role>();
        modelBuilder.Entity<ShoppingCenter>().HasOne<City>();
        modelBuilder.Entity<ShoppingCenter>().HasOne<ShoppingCentersStatus>();
        modelBuilder.Entity<ShoppingCenter>().HasMany<Pavilion>();
        modelBuilder.Entity<Pavilion>().HasOne<PavilionStatus>();
        modelBuilder.Entity<Rental>().HasOne<RentalsStatus>();
        modelBuilder.Entity<Rental>().HasMany<Tenant>();
        modelBuilder.Entity<Rental>().HasMany<ShoppingCenter>();
        modelBuilder.Entity<Rental>().HasMany<Pavilion>();
        modelBuilder.Entity<Rental>().HasMany<Employee>();

        modelBuilder.Entity<Pavilion>().ToTable(e => e.HasTrigger("PreventModifyReservedPavilions"));
        modelBuilder.Entity<ShoppingCenter>().ToTable(e => e.HasTrigger("PreventSCStatusChange"));
        //Todo: ставить процедуры и триггеры
    }

    public bool Register(Employee employee)
    {
        if (employee.isNotFull()) throw new ArgumentException();
        Encrypt(employee);
        if (Employees.Any(e => e.Login == employee.Login)) throw new RegisterException();
        try
        {
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

    private void Encrypt(Employee employee)
    {
        employee.Password = PasswordEncryptor.Encrypt(employee.Password);
    }

    public Employee? Login(Employee employee)
    {
        Encrypt(employee);
        Employee? res;
        var req = Employees.Where(e => e.Login == employee.Login && e.Password == employee.Password);
        res = req.First();
        return res;
    }

    // public void IDENTITY_ON()
    // {
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Cities] ON");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Roles] ON");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Cities] ON");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[RentalsStatuses] ON");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[ShoppingCentersStatuses] ON");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[PavilionsStatuses] ON");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[ShoppingCenters] ON");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Pavilions] ON");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Employees] ON");
    // }
    //
    // public void IDENTITY_OFF()
    // {
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Roles] OFF");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Cities] OFF");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[RentalsStatuses] OFF");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[ShoppingCentersStatuses] OFF");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[PavilionsStatuses] OFF");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[ShoppingCenters] OFF");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Pavilions] OFF");
    //     this.Database.ExecuteSql($"SET IDENTITY_INSERT [dbo].[Employees] OFF");
    // }
    
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