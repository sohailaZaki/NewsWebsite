using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace news_websites.Models
{
	public class News
	{
		
		public int Id { get; set; }
		
		
		public string Title { get; set; }
		public string Topic { get; set; }
		public DateTime Date { get; set; }
		[AllowNull]
		public string imageUrl { get; set; }
		public Categories ?Category { get; set; }
		public string Description { get; set; }

		[ForeignKey("Categories")]
		public int CategoryId { get; set; }
	}
}
