
using DenemeAPI.Models;
using DenemeAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DenemeAPI.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly DataContext _context;
		DbSet<Category> _dbSet;

		public CategoryRepository(DataContext context)
        {
			_context = context;
			_dbSet = _context.Set<Category>();
		}

		public void Add(Category category)
		{
			_dbSet.Add(category);
			_context.SaveChanges();
		}

		public async Task AddAsync(Category category)
		{
			_dbSet.AddAsync(category);
			await _context.SaveChangesAsync();
		}

		public void Delete(int id)
		{
			var book = _dbSet.Find(id);
			_dbSet.Remove(book);
			_context.SaveChanges();
		}

		public async Task DeleteAsync(int id)
		{
			var book = _dbSet.Find(id);
			_dbSet.Remove(book);
			await _context.SaveChangesAsync();
		}

		public IEnumerable<Category> GetAll()
		{
			return _dbSet.ToList();
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public Category GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public async Task<Category> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public void Update(Category category)
		{
			_dbSet.Update(category);
			_context.SaveChanges();
		}

		public async Task UpdateAsync(Category category)
		{
			_dbSet.Update(category);
			await _context.SaveChangesAsync();
		}
	}
}
