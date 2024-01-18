using Labb3_miniAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_miniAPI.Data
{
	public class ApplicationContext: DbContext
	{
		public DbSet<Interest> Interests { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<InterestLink> InterestLinks { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
	}
}
