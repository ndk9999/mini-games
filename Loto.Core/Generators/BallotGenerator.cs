using System;
using System.Collections.Generic;
using System.Linq;

namespace Loto.Core.Generators
{
	public class BallotGenerator
	{
		private static readonly string[] _colors = new[]
		{
			"DarkBlue",
			"DarkGreen",
			"DarkCyan",
			"DarkRed",
			"DarkMagenta",
			"DarkYellow",
			"Gray",
			"DarkGray",
			"Blue",
			"Green",
			"Cyan",
			"Red",
			"Magenta",
			"Yellow"
		};

		public static List<Ballot> Generate()
		{
			var ballots = new List<Ballot>();

			foreach (var color in _colors)
			{
				var sequence = new NumberSequence(90);
				var countPerColor = 0;

				// Với mỗi màu và 1 bộ 90 số, sinh ra 6 phiếu
				while (countPerColor < 5)
				{
					// Sinh 1 bộ 15 số và tạo phiếu loto
					var numbers = GenerateNumbers(sequence);
					var paper = new Ballot(color, numbers);

					// Kiểm tra xem đã có phiếu nào trùng hay chưa
					// Nếu trùng thì quay lại 15 số
					if (ballots.Any(x => x.HasSameRow(paper)))
					{
						sequence.StepBack(Ballot.NUMBER_PER_BALLOT);
					}
					// Nếu không trùng thì thêm phiếu vào danh sách kết quả
					else
					{
						ballots.Add(paper);
						countPerColor++;
					}
				}
			}

			return ballots;
		}

		private static int[] GenerateNumbers(NumberSequence sequence)
		{
			var numbers = new int[Ballot.NUMBER_PER_BALLOT];

			// Tạo dãy số cho từng dòng, tối đa 3 dòng mỗi phiếu
			for (var row = 0; row < Ballot.ROW_PER_BALLOT; row++)
			{
				// Tạo mảng đánh dấu số trong mỗi cột (9 cột)
				var marked = new bool[10];
				var idx = 0;

				// Lần lượt thêm cho đủ 5 số mỗi dòng
				while (idx < Ballot.NUMBER_PER_ROW)
				{
					// Lấy ngẫu nhiên 1 số
					var item = sequence.GetOne();

					// Xác định xem số đó nằm cột nào
					var col = GetColumn(item);

					// Nếu cột đó đã có số rồi thì lùi lại, chọn 1 số khác
					if (marked[col])
					{
						sequence.StepBack();
					}
					// Nếu chưa có thì đưa số đó vào dãy kết quả
					// Và đánh dấu cột tương ứng đã có số
					else
					{
						marked[col] = true;
						numbers[row * Ballot.NUMBER_PER_ROW + idx] = item;
						idx++;
					}
				}
			}

			Array.Sort(numbers, 0, 5);
			Array.Sort(numbers, 5, 5);
			Array.Sort(numbers, 10, 5);

			return numbers;
		}

		private static int GetColumn(int number)
		{
			return number >= 80 ? 8 : number / 10;
		}
	}
}