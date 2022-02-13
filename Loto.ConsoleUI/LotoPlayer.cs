using System;
using System.Collections.Generic;
using System.Linq;
using Loto.Core;
using Loto.Core.Extensions;

namespace Loto.ConsoleUI
{
	public class LotoPlayer : IPlayer
	{
		private List<int> takenNumbers = new List<int>();
		private int[] tickedCounter = new int[Ballot.ROW_PER_BALLOT];

		public string Name { get; }

		public Ballot Ballot { get; }

		public int X { get; set; }

		public int Y { get; set; }


		public LotoPlayer(string name, Ballot ballot)
		{
			Name = name;
			Ballot = ballot;
		}

		public bool Check(int number)
		{
			var idx = Ballot.Numbers.IndexOf(number);
			if (idx < 0) return false;
			
			var row = idx / Ballot.NUMBER_PER_ROW;
			var col = number.GetTens();

			takenNumbers.Add(number);
			tickedCounter[row]++;

			SetTick(number, row, col);

			return tickedCounter[row] == Ballot.NUMBER_PER_ROW;
		}

		public List<int> GetWinNumbers()
		{
			for (int i = 0; i < tickedCounter.Length; i++)
			{
				if (tickedCounter[i] == Ballot.NUMBER_PER_ROW)
				{
					return Ballot.Numbers
						.Skip(i * Ballot.NUMBER_PER_ROW)
						.Take(Ballot.NUMBER_PER_ROW)
						.ToList();
				}
			}

			return new List<int>();
		}

		private void SetTick(int number, int row, int col)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(X + col * 3 + 1, Y + row * 2 + 2);
			Console.Write(number.ToString().PadLeft(2, ' '));
		}
	}
}