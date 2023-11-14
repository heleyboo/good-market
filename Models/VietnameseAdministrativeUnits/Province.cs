namespace GoodMarket.Models.VietnameseAdministrativeUnits;

public class Province
{
    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public string NameEn { get; set; }
    
    public string FullName { get; set; }
    
    public string FullNameEn { get; set; }
    
    public string CodeName { get; set; }
    
    public int AdministrativeUnitId { get; set; }
    
    public virtual AdministrativeUnit AdministrativeUnit { get; set; }
    
    public int AdministrativeRegionId { get; set; }
    
    public virtual AdministrativeRegion AdministrativeRegion { get; set; }
    
    public ICollection<District> Districts { get; set; }
}