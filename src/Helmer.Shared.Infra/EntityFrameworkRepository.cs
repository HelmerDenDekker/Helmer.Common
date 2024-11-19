using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Helmer.Shared.Infra;

public class EntityFrameworkRepository<T> : IRepository<T> where T: class
{
	private readonly DbContext _context;
	private DbSet<T> _dbSet;
    
	public EntityFrameworkRepository(DbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}
    
	public async Task<T?> GetAsync(int id)
	{
		return await _dbSet.FindAsync(id);
	}
    
	public async Task<IEnumerable<T>> GetAsync()
	{
		return await _dbSet.ToListAsync();
	}
    
	public void Add(T entity)
	{
		_dbSet.Add(entity);
	}
    
	public void Delete(T entity)
	{
		_dbSet.Remove(entity);
	}
    
	public void Update(T entity)
	{
		// no code is required in the update method as changes are tracked by the context
	}
    
	public async Task SaveChangesAsync()
	{
		await _context.SaveChangesAsync();
	}

	// I am not sure this is a good idea. First of all, it is not async. IO should be async. Second of all,  
	public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
	{
		return _dbSet.Where(predicate);
	}
}
