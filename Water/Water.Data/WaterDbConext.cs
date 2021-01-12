using Microsoft.EntityFrameworkCore;
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

		public DbSet<GameImage> GameImages { get; set; }

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

			builder.Entity<UserGame>()
				.HasOne(ug => ug.Game)
				.WithMany(g => g.UserGames)
				.HasForeignKey(ug => ug.GameId);

			builder.Entity<UserGame>()
				.HasOne(ug => ug.User)
				.WithMany(g => g.UserGames)
				.HasForeignKey(ug => ug.UserId);

			builder.Entity<GameImage>()
				.HasOne(gi => gi.Game)
				.WithMany(g => g.Images)
				.HasForeignKey(gi => gi.GameId);
		}
	}
}
