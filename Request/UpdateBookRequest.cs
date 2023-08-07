namespace DenemeAPI.Request
{
	public class UpdateBookRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public double Cost { get; set; }
		public int PageNo { get; set; }
        public int CategoryId { get; set; }
    }
}
