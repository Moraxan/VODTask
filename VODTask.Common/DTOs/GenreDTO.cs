using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Common.DTOs
{

	public class GenreBaseDTO
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
	}

	public class GenreDTO : GenreBaseDTO
	{
		public List<FilmDTO> Films { get; set; } = new();
	}
}
