namespace GoodMarket.Repositories.Contracts;

public interface IUnitOfWork: IDisposable
{
    IPostRepository PostRepository { get; }
    int Save();
}