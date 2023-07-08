using System.Diagnostics;
using Encrypting;
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
    }

    //[Test]
    public void Encrypting()
    {
        List<string> passwords = new()
        {
            "ynt1RS#",
            "0^7i7Lb",
            "7SP?9cV",
            "6QF1Wb)",
            "!GwffgE",
            "d7iKK@V",
            "8K%C7wJ",
            "x58O&AN",
            "fhD*SBf",
            "9mlP\"QJ",
            "Wh4OY<m",
            ">Kc1PeS"
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

            // DataWorker.UploadJsonToFile(context.Employees.ToList() as IEnumerable<Employee>,
            //     @"D:\C#\LearningPractice2023\Pavilions\Libs\PavilionsData\Resources\Json\Employees.json");
        }
    }

    [Test]
    public void Hello()
    {
        var id = -1;
        int.TryParse("lox", out id);
        Trace.WriteLine(id);
    }
}