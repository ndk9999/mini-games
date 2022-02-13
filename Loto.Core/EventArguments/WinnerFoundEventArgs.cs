using System.Collections.Generic;

namespace Loto.Core.EventArguments
{
	public class WinnerFoundEventArgs
	{
		public int TotalStep { get; set; }

		public List<IPlayer> Winners { get; set; }	
	}
}