using System;
using System.Collections.Generic;
using Loto.Core.EventArguments;
using Loto.Core.Generators;

namespace Loto.Core
{
	public class LotoGame
	{
		private readonly IEnumerable<IPlayer> _players;

		public event EventHandler<NumberSelectedEventArgs> NumberSelected = null;
		public event EventHandler<WinnerFoundEventArgs> WinnersFound = null;

		public int Delay { get; set; } = 3;

		public LotoGame(IEnumerable<IPlayer> players)
		{
			_players = players;
		}

		public void Start()
		{
			var winners = new List<IPlayer>();
			var sequence = new NumberSequence(90);
			var step = 1;

			do
			{
				var number = sequence.GetOne();

				OnNumberSelected(step, number);
				step++;

				foreach (var p in _players)
				{
					if (p.Check(number))
					{
						winners.Add(p);
					}
				}

				System.Threading.Thread.Sleep(Delay * 1000);
			} while (winners.Count == 0);

			OnWinnerFound(step - 1, winners);
		}

		protected virtual void OnNumberSelected(int step, int number)
		{
			if (NumberSelected != null)
			{
				var ea = new NumberSelectedEventArgs()
				{
					Step = step,
					Number = number
				};
				NumberSelected(this, ea);
			}
		}

		protected virtual void OnWinnerFound(int totalStep, List<IPlayer> winners)
		{
			if (WinnersFound != null)
			{
				var ea = new WinnerFoundEventArgs()
				{
					TotalStep = totalStep,
					Winners = winners
				};
				WinnersFound(this, ea);
			}
		}
	}
}