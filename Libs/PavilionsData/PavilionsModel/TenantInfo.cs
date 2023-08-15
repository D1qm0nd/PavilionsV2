namespace PavilionsData.PavilionsModel;

[Serializable]
public class TenantInfo
{
    public int? Id { get; set; }
    public string? KindOfActivity { get; set; }
    public string? Licence { get; set; }
    public List<string>? ServiceList { get; set; } = new();
    public string? Organization { get; set; }
    
    public TenantInfo(int id, string kindOfActivity, string licence, List<string> serviceList, string organization)
    {
        Id = id;
        KindOfActivity = kindOfActivity;
        Licence = licence;
        ServiceList = serviceList;
        Organization = organization;
    }

    public TenantInfo()
    {
        
    }
}