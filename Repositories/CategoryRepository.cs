using GoodMarket.Context;
using GoodMarket.Models;
using GoodMarket.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GoodMarket.Repositories;

public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(GmDbContext context): base(context) {}
    
    public Category GetById(int categoryId)
    {
        var query = context.Set<Category>().AsQueryable();

        query = query.Include(c => c.Subcategories);
        query = query.Include(c => c.ParentCategory);

        return query.SingleOrDefault(c => c.Id == categoryId);
    }
}