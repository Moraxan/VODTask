using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Common.DTOs
{
	public record ClickModel(string PageType, int Id);
	
}
