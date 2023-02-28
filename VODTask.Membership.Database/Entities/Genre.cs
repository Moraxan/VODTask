using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Membership.Database.Entities
{
	public class Genre : IEntity
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="Du måste ange en genre.")]
		[StringLength(50, ErrorMessage = "Texten kan inte vara mer än 50 tecken")]
		public string? Name {get; set; }

		public ICollection<FilmGenre>? FilmGenres { get; set; }
	}
}
