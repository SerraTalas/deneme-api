using DenemeAPI.Dto;
using DenemeAPI.Models;

namespace DenemeAPI.Service
{
	public interface ICategoryService
	{
		Category GetById(int id);
		IEnumerable<Category> GetAll();
		void Add(Category category);
		void Update(Category category);
		void Delete(int id);
		bool Exists(int id);


		Task<Category> GetByIdAsync(int id);
		Task<IEnumerable<Category>> GetAllAsync();
		Task AddAsync(CategoryDto categoryDto);
		Task UpdateAsync(CategoryDto categoryDto);
		Task DeleteAsync(int id);
		Task<bool> ExistsAsync(int id);
	}
}
