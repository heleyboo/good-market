using GoodMarket.Models;

namespace GoodMarket.Services.Contracts;

public interface ICategoryService
{
    // Create a new category
    void CreateCategory(Category category);

    // Get all categories
    IEnumerable<Category> GetAllCategories();

    // Get a category by ID
    Category GetCategoryById(int categoryId);

    // Update an existing category
    void UpdateCategory(Category updatedCategory);

    // Delete a category by ID
    void DeleteCategory(int categoryId);
}
