using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Loto.Core;
using Loto.Core.Extensions;
using Loto.Core.Generators;
using Loto.Core.IO;

namespace Loto.ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetBufferSize(300, 100);

			//var ballots = BallotGenerator.Generate();

			int x = 1, y = 0, idx = 0, 
				rows = 7, cols = 6, 
				numPlayers = (rows + cols - 4) * 4;

			var render = new PlayerRender();
			var reader = new BallotReader();
			var ballots = reader.Read("ballots.xml").TakeRandom(numPlayers).ToList();
			var players = ballots
				.Select((b, i) => new LotoPlayer(Names.GetOne(i), b))
				.ToList();

			for (int i = 0; i < rows; i++)
			{
				x = 1;

				for (int j = 0; j < cols; j++)
				{
					if (i <= 1 || i >= rows - 2 || j <= 1 || j >= cols - 2)
					{
						players[idx].X = x;
						players[idx].Y = y;

						render.Display(players[idx], x, y);
						idx++;
					}

					x += 35;
				}

				y += 9;
			}

			Console.ReadKey();

			var game = new LotoGame(players);
			
			game.NumberSelected += (sender, eventArgs) => DisplayStep(eventArgs.Step, eventArgs.Number);
			game.WinnersFound += (sender, eventArgs) => DisplayWinners(eventArgs.TotalStep, eventArgs.Winners);

			game.Start();
		}

		private static void DisplayStep(int step, int number)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.SetCursorPosition(71, 20);

			Console.Write("Lan quay thu {0}: SO {1}", step, number);
		}

		private static void DisplayWinners(int totalStep, List<IPlayer> winners)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(71, 25);
			Console.Write("Da tim duoc nguoi thang cuoc sau {0} lan quay so", totalStep);
			Console.SetCursorPosition(71, 27);
			Console.Write("Co {0} nguoi choi thang cuoc, do la:", winners.Count);

			for (int i = 0; i < winners.Count; i++)
			{
				Enum.TryParse(winners[i].Ballot.Color, out ConsoleColor color);
				Console.ForegroundColor = color;

				Console.SetCursorPosition(75, i + 28);
				Console.Write("+ Nguoi choi '{0}': [{1}]", winners[i].Name, string.Join(",", winners[i].GetWinNumbers()));
			}

			Console.SetCursorPosition(0, 92);
		}
	}
}
