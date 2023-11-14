namespace GoodMarket.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string ImageUrl { get; set; }
    public List<Category> Subcategories { get; set; } = new List<Category>();
    public int? ParentCategoryId { get; set; }
}