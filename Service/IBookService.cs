using DenemeAPI.Dto;
using DenemeAPI.Models;

namespace DenemeAPI.Service
{
	public interface IBookService
	{
		GetBookDto GetById(int id);
		IEnumerable<GetBookDto> GetAll();
		void Add(Book book);
		void Update(Book book);
		void Delete(int id);
		bool Exists(int  id);


		Task<GetBookDto> GetByIdAsync(int id);
		Task<IEnumerable<GetBookDto>> GetAllAsync();
		Task<BookDto> AddAsync (BookDto bookDto);
		Task UpdateAsync(BookDto bookDto);
		Task DeleteAsync(int id);
		Task<bool> ExistsAsync(int id);

	}
}
