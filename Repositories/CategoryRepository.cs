using GoodMarket.Context;
using GoodMarket.Models;
using GoodMarket.Repositories.Contracts;

namespace GoodMarket.Repositories;

public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(GmDbContext context): base(context) {}
}