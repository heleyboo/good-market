namespace GoodMarket.Models.VietnameseAdministrativeUnits;

public class Ward
{
    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public string NameEn { get; set; }
    
    public string FullName { get; set; }
    
    public string FullNameEn { get; set; }
    
    public string CodeName { get; set; }
    
    public int AdministrativeUnitId { get; set; }
    
    public virtual AdministrativeUnit AdministrativeUnit { get; set; }

    public string DistrictCode { get; set; }
    
    public virtual District District { get; set; }
}