namespace PavilionsData.PavilionsModel;

[Serializable]
public class TenantInfo
{
    public TenantInfo(string kindOfActivity, double profitability, int avgNumberOfVisitsPerDay)
    {
        KindOfActivity = kindOfActivity;
        Profitability = profitability;
        AvgNumberOfVisitsPerDay = avgNumberOfVisitsPerDay;
    }
    public string KindOfActivity { get; set; }
    public double Profitability { get; set; }
    public int AvgNumberOfVisitsPerDay { get; set; }
}