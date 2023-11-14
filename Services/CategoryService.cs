using GoodMarket.Models;
using GoodMarket.Repositories.Contracts;
using GoodMarket.Services.Contracts;

namespace GoodMarket.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Implement the CRUD methods from the interface
    // ...

    // Create a new category
    public void CreateCategory(Category category)
    {
        _unitOfWork.CategoryRepository.Add(category);
        _unitOfWork.Commit();
    }

    // Get all categories
    public IEnumerable<Category> GetAllCategories()
    {
        return _unitOfWork.CategoryRepository.GetAll();
    }

    // Get a category by ID
    public Category GetCategoryById(int categoryId)
    {
        return _unitOfWork.CategoryRepository.GetById(categoryId);
    }

    // Update an existing category
    public void UpdateCategory(Category updatedCategory)
    {
        _unitOfWork.CategoryRepository.Update(updatedCategory);
        _unitOfWork.Commit();
    }

    // Delete a category by ID
    public void DeleteCategory(int categoryId)
    {
        _unitOfWork.CategoryRepository.Delete(categoryId);
        _unitOfWork.Commit();
    }
}
