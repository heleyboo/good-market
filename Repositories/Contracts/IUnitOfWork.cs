namespace GoodMarket.Repositories.Contracts;

public interface IUnitOfWork: IDisposable
{
    IPostRepository PostRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    int Commit();
}