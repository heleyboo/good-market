using GoodMarket.Models;

namespace GoodMarket.Repositories.Contracts;

public interface ICategoryRepository: IGenericRepository<Category>
{
    public Category GetById(int categoryId);
}