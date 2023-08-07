using DenemeAPI.Data;
using DenemeAPI.Models;

namespace DenemeAPI
{
	public class DataSeeder
	{
		private readonly DataContext _context;

		public DataSeeder(DataContext context)
		{
			_context = context;
		}

		public void Seed()
		{

			if (!_context.Categories.Any())
			{
				var categories = new List<Category>
				{
					new Category { Name = "Science Fiction" },
					new Category { Name = "Fantasy" },
					new Category { Name = "Autobiography" },
					new Category { Name = "Mystery" }
				};
				_context.Categories.AddRange(categories);
				_context.SaveChanges();

				if (!_context.Books.Any())
				{
					var books = new List<Book>
				{
					new Book
					{
						Name = "Harry Potter ve Felsefe Taşı",
						Author = "J.K Rowling",
						Category = categories[1],
						Cost = 150,
						PageNo = 420
					},

					new Book
					{
						Name = "Yüzüklerin Efendisi 1",
						Author = "J.R.R Tolkien",
						Category = categories[1],
						Cost = 170,
						PageNo = 470
					},

					new Book
					{
						Name = "Anne Frank'in Hatıra Defteri",
						Author = "Anne Frank",
						Category = categories[2],
						Cost = 110,
						PageNo = 370
					},

					new Book
					{
						Name = "Beş Küçük Domuz",
						Author = "Agatha Christie",
						Category = categories[3],
						Cost = 70,
						PageNo = 220
					},

					new Book
					{
						Name = "Fahrenheit",
						Author = "Ray Bradbury",
						Category = categories[0],
						Cost = 200,
						PageNo = 370
					}};
					_context.Books.AddRange(books);
					_context.SaveChanges();
				}
			}
		}
	}
}

