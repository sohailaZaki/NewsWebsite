namespace news_websites.Models
{
	public class Categories
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		= 0;
		public string Name { get; set; }
		public string Description { get; set; }

	
		public List<News>News { get; set; }

	}
}
