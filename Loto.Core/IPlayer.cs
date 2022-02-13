using System.Collections.Generic;

namespace Loto.Core
{
	public interface IPlayer
	{
		public string Name { get; }

		public Ballot Ballot { get; }


		bool Check(int number);

		List<int> GetWinNumbers();
	}
}