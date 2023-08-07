using AutoMapper;
using DenemeAPI.Data;
using DenemeAPI.Dto;
using DenemeAPI.GenericRepository;
using DenemeAPI.Models;
using DenemeAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace DenemeAPI.Service
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;
		private readonly DataContext _context;
		private readonly CategoryService _categoryService;

		public BookService(IBookRepository bookRepository, IMapper mapper, DataContext context, CategoryService categoryService)
        {
			_bookRepository = bookRepository;
			_mapper = mapper;
			_context = context;
			_categoryService = categoryService;
		}

		public void Add(Book book)
		{
			_bookRepository.Add(book);
		}
		public void Update(Book book)
		{
			_bookRepository.Update(book);
		}
		public void Delete(int id)
		{
			_bookRepository.Delete(id);
		}
		public bool Exists(int id)
		{
			return _context.Books.Any(b => b.Id == id);
		}
		public IEnumerable<GetBookDto> GetAll()
		{
			return _mapper.Map<List<GetBookDto>>(_context.Books.Include(b => b.Category).ToList());
		}
		public GetBookDto GetById(int id)
		{
			var book = _context.Books.Include(b => b.Category).SingleOrDefault(b => b.Id == id);
			return _mapper.Map<GetBookDto>(_bookRepository.GetById(id));
		}

		public async Task<BookDto> AddAsync(BookDto bookDto)
		{
			Book bookToAdd = _mapper.Map<Book>(bookDto);
			//bookToAdd.Category = await _categoryService.GetByIdAsync(categoryId);
			await _bookRepository.AddAsync(bookToAdd);
			return _mapper.Map<BookDto>(bookToAdd);
		}
		public async Task DeleteAsync(int id)
		{
			await _bookRepository.DeleteAsync(id);
		}
		public async Task<bool> ExistsAsync(int id)
		{
			return await _context.Books.AnyAsync(b => b.Id == id);
		}
		public async Task<IEnumerable<GetBookDto>> GetAllAsync()
		{
			var bookWithCategories = await _context.Books.Include(b => b.Category).ToListAsync();
			var dtos = _mapper.Map<List<GetBookDto>>(bookWithCategories);
			return dtos;
		}
		public async Task<GetBookDto> GetByIdAsync(int id)
		{
			var book = await _context.Books.Include(b => b.Category).SingleOrDefaultAsync(b => b.Id == id);
			return _mapper.Map<GetBookDto>(_bookRepository.GetById(id));
		}

		public async Task UpdateAsync(BookDto bookDto)
		{
			var bookToUpdate = _mapper.Map<Book>(bookDto);
			await _bookRepository.UpdateAsync(bookToUpdate);
		}
	}
}
