using System.Linq.Expressions;

namespace Helmer.Shared.Infra;

public interface IRepository<T>
{
	Task<T?> GetAsync(int id);
	Task<IEnumerable<T>> GetAsync();
	void Add(T entity);
	void Delete(T entity);
	void Update(T entity);
	Task SaveChangesAsync(); // Or in Unit of Work
	Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
