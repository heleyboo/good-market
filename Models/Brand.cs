namespace GoodMarket.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? IconUrl { get; set; }
    
    public ICollection<Edition> Editions { get; set; }
}

public class Edition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
}