using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace VODTask.Membership.Database.Entities
{
	public class Film : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Du måste fylla i en titel.")]
		[StringLength(50, ErrorMessage = "Titeln kan inte vara längre än 50 tecken.")]

		public string? Title { get; set; }

		public DateTime Released { get; set; }

		public virtual ICollection<Director>? Directors { get; set; }

		public bool Free { get; set; }

		[StringLength(200, ErrorMessage = "Beskrivningen kan inte vara längre än 200 tecken.")]
		public string? Description { get; set; }

		[Required(ErrorMessage = "Du måste fylla i url för filmen.")]
		[StringLength(1024, ErrorMessage = "Url:en kan inte vara längre än 1024 tecken.")]
		public string? FilmUrl { get; set; }

	}
}
