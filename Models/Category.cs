namespace GoodMarket.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string ImageUrl { get; set; }
    public int? ParentCategoryId { get; set; }
    // Navigation properties
    public Category? ParentCategory { get; set; }
    public List<Category> Subcategories { get; set; } = new List<Category>();
}