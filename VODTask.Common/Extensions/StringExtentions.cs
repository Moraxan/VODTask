using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VODTask.Common.Extensions
{
	public static class StringExtentions
	{
		public static string Truncate(int length, string value)
		{
			if (string.IsNullOrEmpty(value)) return string.Empty;
			if (value.Length <= length) return value;
			var result = value.Substring(0, length);
			return $"{result} ...";	

		}
	}
}
