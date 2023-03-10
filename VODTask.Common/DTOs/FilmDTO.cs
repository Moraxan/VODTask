
namespace VODTask.Common.DTOs
{
	public class FilmDTO
	{

		public int Id { get; set; }
		public string? Title { get; set; }
		public DateTime Released { get; set; }
		public bool Free { get; set; }
		public string? Description { get; set; }
		public string? FilmUrl { get; set; }
		public int DirectorId { get; set; }
		public DirectorDTO? Director { get; set; }
		public List<SimilarFilmDTO>? SimilarFilms { get; set; }
		public List<GenreBaseDTO>? Genres { get; set; }
	}
	public class FilmCreateDTO
	{
		public string? Title { get; set; }
		public DateTime Released { get; set; }
		public bool Free { get; set; }
		public string? Description { get; set; }
		public string? FilmUrl { get; set; }
		public int DirectorId { get; set; }
		
	}
	public class FilmEditDTO : FilmCreateDTO
	{
		public int Id { get; set; }	
	}
}

