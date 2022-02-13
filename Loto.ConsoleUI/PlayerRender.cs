using System;
using System.Linq;
using Loto.Core;
using Loto.Core.Extensions;

namespace Loto.ConsoleUI
{
	public class PlayerRender
	{
		public void Display(IPlayer player, int x, int y)
		{
			Enum.TryParse(player.Ballot.Color, out ConsoleColor color);
			Console.ForegroundColor = color;

			Console.SetCursorPosition(x, y);
			Console.Write("Nguoi choi: {0}", player.Name);

			Display(player.Ballot, x, y + 1);
		}

		private void Display(Ballot ballot, int x, int y)
		{
			var row1 = ballot.Numbers.Take(5).GetColumnFormatted();
			var row2 = ballot.Numbers.Skip(5).Take(5).GetColumnFormatted();
			var row3 = ballot.Numbers.Skip(10).Take(5).GetColumnFormatted();

			var lines = new[]
			{
				"+--+--+--+--+--+--+--+--+--+",
				$"|{string.Join('|', row1)}|",
				"+--+--+--+--+--+--+--+--+--+",
				$"|{string.Join('|', row2)}|",
				"+--+--+--+--+--+--+--+--+--+",
				$"|{string.Join('|', row3)}|",
				"+--+--+--+--+--+--+--+--+--+"
			};

			for (int i = 0; i < lines.Length; i++)
			{
				Console.SetCursorPosition(x, y + i);
				Console.Write(lines[i]);
			}
		}
	}
}