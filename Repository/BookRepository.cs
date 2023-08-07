
using DenemeAPI.Models;
using DenemeAPI.Data;
using Microsoft.EntityFrameworkCore;
using DenemeAPI.Dto;
using DenemeAPI.GenericRepository;

namespace DenemeAPI.Repository
{
	public class BookRepository : GenericRepository<Book>, IBookRepository
	{
		public BookRepository(DataContext context) : base(context)
        {
		
		}

		
	}
}
