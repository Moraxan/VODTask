using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Common.DTOs
{
	public class FilmGenreDTO
	{
		public int FilmId { get; set; }
		public FilmDTO? Films { get; set; }
		public int GenreId { get; set; }
		public GenreBaseDTO? Genre { get; set; }
	}
}
