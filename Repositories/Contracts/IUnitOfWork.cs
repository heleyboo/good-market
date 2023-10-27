namespace GoodMarket.Repositories.Contracts;

public interface IUnitOfWork: IDisposable
{
    int Save();
}