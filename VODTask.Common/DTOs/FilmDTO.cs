
namespace VODTask.Common.DTOs
{
	public class FilmDTO
	{
		
		public int Id { get; set; }

		

		public string? Title { get; set; }
		public DateTime Released { get; set; }

		public virtual List<DirectorDTO>? Directors { get; set; }

		public bool Free { get; set; }

		
		public string? Description { get; set; }

		public string? FilmUrl { get; set; }
	}
}
