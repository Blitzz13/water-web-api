using Microsoft.EntityFrameworkCore;
using System.Linq;
using Water.Data.Models;

namespace Water.Data
{
	public class WaterDbConext : DbContext
	{
		public WaterDbConext()
		{
		}

		public WaterDbConext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		//public DbSet<Company> Companies { get; set; }

		public DbSet<Game> Games { get; set; }

		public DbSet<Review> Reviews { get; set; }

		public DbSet<UserGame> UsersGames { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			base.OnConfiguring(builder);

			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=WaterDB;Integrated Security=True");
			}

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<UserGame>()
				.HasKey(ug => new { ug.GameId, ug.UserId });
		}
	}
}
