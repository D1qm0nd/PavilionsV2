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
}