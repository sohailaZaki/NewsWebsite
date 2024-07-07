using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using news_websites.Data;

namespace news_websites.Models
{
	public class NewsContext : DbContext
	{
		public NewsContext(DbContextOptions<NewsContext> options)
			: base(options)
		{

		}
        public DbSet<News> News { get; set; }
        public DbSet<Categories> Categories { get; set; }
		public DbSet <ContactUS> ContactUs { get; set; }
		public DbSet<Team> Team { get; set; }
    }
}
