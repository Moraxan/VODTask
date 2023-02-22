

using System.Reflection;

namespace VODTask.Membership.Database.Contexts
{
	public class VODContext : DbContext
	{
		public VODContext(DbContextOptions<VODContext> options) : base(options)
		{

		}
		public DbSet<Director> Directors { get; set; }
		public DbSet<Film> Films { get; set; }
		public DbSet<FilmGenre> FilmGenres { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<SimilarFilm> SimilarFilms { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				// Use reflection to fetch the foreign key and alter its DeleteBehavior property
				PropertyInfo property = relationship.GetType().GetProperty("DeleteBehavior");
				property.SetValue(relationship, DeleteBehavior.Restrict);
			}
		}


	}
}
