using System.Linq.Expressions;
using GoodMarket.Context;
using GoodMarket.Repositories.Contracts;

namespace GoodMarket.Repositories;

public class GenericRepository < T > : IGenericRepository < T > where T: class {
    protected readonly GmDbContext context;
    public GenericRepository(GmDbContext context) {
        this.context = context;
    }
    public T Add(T entity) {
        context.Set<T>().Add(entity);
        context.SaveChanges();
        return entity;
    }
    public void AddRange(IEnumerable <T> entities) {
        context.Set<T>().AddRange(entities);
    }
    public IEnumerable <T> GetAll() {
        return context.Set<T>().ToList();
    }
    
    public IEnumerable < T > Find(Expression < Func < T, bool >> expression) {
        return context.Set < T > ().Where(expression);
    }
    public T GetById(int id) {
        return context.Set<T>().Find(id);
    }
    public void Remove(T entity) {
        context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable < T > entities) {
        context.Set<T>().RemoveRange(entities);
    }
}