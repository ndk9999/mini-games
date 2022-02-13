using System;
using System.Collections.Generic;
using System.Linq;

namespace Loto.Core
{
	public class Ballot
	{
		public const int ROW_PER_BALLOT = 3;
		public const int NUMBER_PER_ROW = 5;
		public const int NUMBER_PER_BALLOT = 15;

		public string Color { get; set; }

		public int[] Numbers { get; set; }

		public Ballot()
		{
			
		}

		public Ballot(string color, IEnumerable<int> numbers)
		{
			if (numbers.Count() != 15)
				throw new ArgumentException("Argument numbers must have exactly 15 integer", nameof(numbers));

			Color = color;
			Numbers = numbers.ToArray();
		}

		public bool HasSameRow(Ballot y)
		{
			var xStartIdx = 0;

			// Duyệt từng cụm 5 phần tử trong phiếu x
			while (xStartIdx < NUMBER_PER_BALLOT)
			{
				var yStartIdx = 0;

				// Duyệt từng cụm 5 phần tử trong phiếu y
				while (yStartIdx < NUMBER_PER_BALLOT)
				{
					var isSubset = true;

					// So sánh xem 2 cụm 5 phần tử đó có giống nhau hay không
					for (var i = 0; i < NUMBER_PER_ROW; i++)
					{
						if (this.Numbers[xStartIdx + i] != y.Numbers[yStartIdx + i])
						{
							isSubset = false;
							break;
						}
					}

					// Nếu giống nhau thì kết luận 2 phiếu có cùng dãy số
					if (isSubset) return true;

					yStartIdx += NUMBER_PER_ROW;
				}
				
				xStartIdx += NUMBER_PER_ROW;
			}

			return false;
		}

		public override string ToString()
		{
			return $"{Color},{string.Join(",", Numbers)}";
		}
	}
}
