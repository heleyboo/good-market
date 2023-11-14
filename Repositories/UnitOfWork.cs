using GoodMarket.Context;
using GoodMarket.Repositories.Contracts;

namespace GoodMarket.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private GmDbContext context;
    
    private bool _disposed = false;
    
    public UnitOfWork(GmDbContext context)
    {
        this.context = context;
        PostRepository = new PostRepository(context);
        CategoryRepository = new CategoryRepository(context);
    }
    
    public IPostRepository PostRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        _disposed = true;
    }

    public int Commit()
    {
        return context.SaveChanges();
    }
}