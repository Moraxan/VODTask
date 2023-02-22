using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Membership.Database.Entities
{
	public class SimilarFilm
	{
		public int ParentFilmId { get; set; }
		public int SimilarFilmId { get; set; }
	}
}
