using AutoMapper;
using DenemeAPI.Data;
using DenemeAPI.Dto;
using DenemeAPI.GenericRepository;
using DenemeAPI.Models;
using DenemeAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace DenemeAPI.Service
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public CategoryService(ICategoryRepository categoryRepository, DataContext context, IMapper mapper)
        {
			_categoryRepository = categoryRepository;
			_context = context;
			_mapper = mapper;
		}

		public void Add(Category category)
		{
			_categoryRepository.Add(category);
		}

		public async Task AddAsync(CategoryDto categoryDto)
		{
			var categoryToAdd = _mapper.Map<Category>(categoryDto);
			await _categoryRepository.AddAsync(categoryToAdd);
		}

		public void Delete(int id)
		{
			_categoryRepository.Delete(id);
		}

		public async Task DeleteAsync(int id)
		{
			await _categoryRepository.DeleteAsync(id);
		}

		public bool Exists(int id)
		{
			return _context.Categories.Any(c => c.Id == id);
		}

		public async Task<bool> ExistsAsync(int id)
		{
			return await _context.Categories.AnyAsync(c => c.Id == id);
		}

		public IEnumerable<Category> GetAll()
		{
			return _categoryRepository.GetAll();
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _categoryRepository.GetAllAsync();
		}

		public Category GetById(int id)
		{
			return _categoryRepository.GetById(id);
		}

		public async Task<Category> GetByIdAsync(int id)
		{
			return await _categoryRepository.GetByIdAsync(id);
		}

		public void Update(Category entity)
		{
			_categoryRepository.Update(entity);
		}

		public async Task UpdateAsync(CategoryDto categoryDto)
		{
			var categoryToUpdate = _mapper.Map<Category>(categoryDto);
			await _categoryRepository.UpdateAsync(categoryToUpdate);
		}
	}
}

