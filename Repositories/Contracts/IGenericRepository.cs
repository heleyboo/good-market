using System.Linq.Expressions;

namespace GoodMarket.Repositories.Contracts;

public interface IGenericRepository <T> where T: class {
    T GetById(int id);
    IEnumerable <T> GetAll();
    IEnumerable < T > Find(Expression < Func < T, bool >> expression);
    T Add(T entity);
    void AddRange(IEnumerable <T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable <T> entities);
}