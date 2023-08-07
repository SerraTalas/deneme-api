using DenemeAPI.GenericRepository;
using DenemeAPI.Models;

namespace DenemeAPI.Repository
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
		Task<IEnumerable<Category>> GetAllAsync();
		Task<Category> GetByIdAsync(int id);
		Task AddAsync(Category category);
		Task UpdateAsync(Category category);
		Task DeleteAsync(int id);
	}
}
