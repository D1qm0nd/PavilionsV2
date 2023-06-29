using Encrypting;
using PavilionsData.PavilionsModel.Context;

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

    [Test]
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
}