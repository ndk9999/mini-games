using System.Collections.Generic;
using System.Linq;

namespace Loto.Core.Extensions
{
	public static class NumberExtensions
	{
		public static int GetTens(this int number)
		{
			return number >= 80 ? 8 : number / 10;
		}

		public static string GetColumnFormatted(this IEnumerable<int> numbers, char delimiter = '|')
		{
			var columns = Enumerable.Repeat("  ", 9).ToArray();

			foreach (var n in numbers)
			{
				columns[n.GetTens()] = n.ToString().PadLeft(2, ' ');
			}

			return string.Join(delimiter, columns);
		}
	}
}