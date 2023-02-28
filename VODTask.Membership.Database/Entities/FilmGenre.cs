using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Membership.Database.Entities
{
	public class FilmGenre 
	{
		public int FilmId { get; set; }
		public Film? Films { get; set; }
		public int GenreId { get; set; }
		public Genre? Genre { get; set; }
	}
}
