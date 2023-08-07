using System.ComponentModel.DataAnnotations.Schema;

namespace DenemeAPI.Models
{
	public class Book : BaseEntity
	{
		public string Name { get; set; }
        public string Author { get; set; }
        public int PageNo { get; set; }
        public double Cost { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
