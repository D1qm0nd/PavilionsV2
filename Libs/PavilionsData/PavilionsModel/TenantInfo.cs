namespace PavilionsData.PavilionsModel;

[Serializable]
public class TenantInfo
{
    public TenantInfo(int id, string kindOfActivity, double profitability, int avgNumberOfVisitsPerDay)
    {
        Id = id;
        KindOfActivity = kindOfActivity;
        Profitability = profitability;
        AvgNumberOfVisitsPerDay = avgNumberOfVisitsPerDay;
    }

    public int Id { get; set; }
    public string KindOfActivity { get; set; }
    public double Profitability { get; set; }
    public int AvgNumberOfVisitsPerDay { get; set; }
}