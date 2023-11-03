using GoodMarket.Context;
using GoodMarket.Models;
using GoodMarket.Repositories.Contracts;

namespace GoodMarket.Repositories;

public class PostRepository: GenericRepository<Post>, IPostRepository
{
    public PostRepository(GmDbContext context): base(context) {}
}