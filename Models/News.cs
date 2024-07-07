using System.ComponentModel.DataAnnotations.Schema;

namespace news_websites.Models
{
	public class News
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Topic { get; set; }
		public DateTime Date { get; set; }
		public string imageUrl { get; set; }
		public Categories Category { get; set; }
		[ForeignKey("Categories")]
		public int CategoryId { get; set; }
	}
}
