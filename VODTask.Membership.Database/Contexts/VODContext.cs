


using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Linq;

namespace VODTask.Membership.Database.Contexts
{
	public class VODContext : DbContext
	{
		public VODContext(DbContextOptions<VODContext> options) : base(options)
		{

		}
		public DbSet<Director>? Directors { get; set; }
		public DbSet<Film>? Films { get; set; }
		public DbSet<FilmGenre>? FilmGenres { get; set; }
		public DbSet<Genre>? Genres { get; set; }
		public DbSet<SimilarFilm>? SimilarFilms { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<FilmGenre>()
				.HasKey(fg => new { fg.FilmId, fg.GenreId });

			builder.Entity<SimilarFilm>()
			.HasKey(sf => new { sf.SimilarFilmId, sf.ParentFilmId });

			builder.Entity<SimilarFilm>()
				.HasOne(sf => sf.ParentFilm)
				.WithMany(f => f.SimilarFilms)
				.HasForeignKey(sf => sf.ParentFilmId);
				
			builder.Entity<FilmGenre>()
				.HasKey(fg => new { fg.FilmId, fg.GenreId });

			builder.Entity<Film>()
			.HasOne(f => f.Director)
			.WithMany()
			.HasForeignKey(f => f.DirectorId);



			foreach (var (relationship, property) in from relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())// Use reflection to fetch the foreign key and alter its DeleteBehavior property
													 let property = relationship.GetType().GetProperty("DeleteBehavior")
													 select (relationship, property))
			{
				property.SetValue(relationship, DeleteBehavior.Restrict);
			}
		}


	}
}
