using DenemeAPI.Data;
using DenemeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DenemeAPI.GenericRepository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly DataContext _context;
		DbSet<T> _dbSet;

		public GenericRepository(DataContext context)
        {
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}
		public void Add(T entity)
		{
			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{	
			var entity = _dbSet.Find(id);
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}

		public T GetById(int id)
		{
			return _dbSet.Find(id);
		}



		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task AddAsync(T entity)
		{
			_dbSet.AddAsync(entity);	
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = _dbSet.Find(id);
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
