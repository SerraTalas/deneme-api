using DenemeAPI.Models;

namespace DenemeAPI.Dto
{
	public class GetBookDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public double Cost { get; set; }
		public int PageNo { get; set; }
		public string CategoryName { get; set; }
	}
}
