using System.Diagnostics.CodeAnalysis;

namespace DenemeAPI.Models
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime? UpdatedTime { get; set; }
    }
}
