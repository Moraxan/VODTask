using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Membership.Database.Entities
{
	public class SimilarFilm
	{
		public int ParentFilmId { get; set; }
		public int SimilarFilmId { get; set; }

		public virtual Film? ParentFilm { get; set; }

		
	}
}
