using Microsoft.EntityFrameworkCore;
using PersonDetails_WEBAPI_Test.Model;

namespace PersonDetails_WEBAPI_Test.Data
{
	public class DbContextClass : DbContext
	{
		protected readonly IConfiguration Configuration;
		public DbContextClass(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(Configuration.GetConnectionString("DataCS"));
		}

		public DbSet<PersonDetails> PersonDetalisTest { get; set; }
		public DbSet<TechnicalExperience> TechnicalExperiencesTest { get; set; }
	}
}
