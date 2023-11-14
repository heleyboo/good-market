using GoodMarket.DataTransferObjects.Response;
using GoodMarket.Models;
using GoodMarket.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// GET api/categories
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        var categories = _categoryService.GetAllCategories();
        var response = BaseResponse<IEnumerable<Category>>.Success(categories);
        return Ok(response);
    }

    // GET api/categories/{id}
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var category = _categoryService.GetCategoryById(id);

        if (category == null)
        {
            return NotFound(); // Return 404 Not Found if the category is not found
        }

        return Ok(BaseResponse<Category>.Success(category));
    }

    // POST api/categories
    [HttpPost]
    public IActionResult Post([FromBody] Category category)
    {
        _categoryService.CreateCategory(category);
        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }

    // PUT api/categories/{id}
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Category updatedCategory)
    {
        var existingCategory = _categoryService.GetCategoryById(id);

        if (existingCategory == null)
        {
            return NotFound(); // Return 404 Not Found if the category is not found
        }

        existingCategory.Name = updatedCategory.Name;
        existingCategory.Code = updatedCategory.Code;
        existingCategory.ImageUrl = updatedCategory.ImageUrl;

        _categoryService.UpdateCategory(existingCategory);

        return NoContent();
    }

    // DELETE api/categories/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var categoryToDelete = _categoryService.GetCategoryById(id);

        if (categoryToDelete == null)
        {
            return NotFound(); // Return 404 Not Found if the category is not found
        }

        _categoryService.DeleteCategory(id);

        return NoContent();
    }
}