using System;

namespace Loto.Core.Generators
{
	public static class Randomizer
	{
		private static Random _random = new Random();

		public static int Next(int max) => _random.Next(max);

		public static int Next(int min, int max) => _random.Next(min, max);
	}
}