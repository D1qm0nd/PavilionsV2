using System.Diagnostics;
using System.Text.Json;
using Encrypting;
using Microsoft.EntityFrameworkCore;
using PavilionsData;
using PavilionsData.PavilionsModel.Context;
using PavilionsData.PavilionsModel.Tables;
using UnitTests.Resources;

namespace UnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LoadData()
    {
        var context = new PavilionsDbContext();
        context.LoadData();
        HackThisPentagon();
    }

    [Test]
    public void Encrypting()
    {
        List<string> passwords = new()
        {
            "ynt1RS#3",
            "0^7i7Lb4",
            "7SP?9cV5",
            "6QF1Wb)6",
            "!GwffgE7",
            "d7iKK@V8",
            "8K%C7wJ9",
            "1x58O&AN",
            "3fhD*SBf",
            "49mlP\"QJ",
            "6Wh4OY<m",
            "7>Kc1PeS"
        };

        for (int i = 0; i < passwords.Count; i++)
        {
            passwords[i] = PasswordEncryptor.Encrypt(passwords[i]);
        }
    }

    [Test]
    public void HackThisPentagon()
    {
        var np = DataWorker.LoadJson<Employee>(JsonResource.DATA);

        using (var context = new PavilionsDbContext())
        {
            foreach (var employee in context.Employees)
            {
                employee.Password = np.First(e => e.Id_Employee == employee.Id_Employee).Password;
            }

            context.SaveChanges();
        }
    }

    [Test]
    public void Hello()
    {
        var id = -1;
        int.TryParse("lox", out id);
        Trace.WriteLine(id);
    }

    [Test]
    public void hello()
    {
        var a = new PavilionsData.PavilionsModel.TenantInfo(1, "business", 99999.90, 500);
        var s = JsonSerializer.Serialize(a);
    }

}