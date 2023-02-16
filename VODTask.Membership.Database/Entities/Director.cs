using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Membership.Database.Entities
{
	public class Director : IEntity
	{
		[Key]
		public int Id { get;set; }

		[Required(ErrorMessage = "Du måste fylla i namn.")]
		[StringLength(50, ErrorMessage = "Namnet kan inte vara längre än 50 tecken.")]
		public string? Name { get; set; }
	}
}
