using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace news_websites.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}
        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<IdentityRole>().HasData(
				
				new IdentityRole()
				{
					Id = Guid.NewGuid().ToString(),
					Name = "Admin",
					NormalizedName="admin",
					ConcurrencyStamp = Guid.NewGuid().ToString(),

				}, new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),

                }

                );
            base.OnModelCreating(builder);
        }
    }
}
