using System;
using System.Collections.Generic;
using System.Linq;
using Loto.Core.Generators;

namespace Loto.Core.Extensions
{
	public static class EnumerableExtensions
	{
		public static int IndexOf<T>(this T[] array, T item)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Equals(item)) return i;
			}

			return -1;
		}

		public static void Shuffle<T>(this T[] array)
		{
			var steps = array.Length / 2;

			for (var i = 0; i < steps; i++)
			{
				var j = Randomizer.Next(array.Length);
				var k = Randomizer.Next(array.Length);

				Swap(array, j, k);
			}
		}

		public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
		{
			var array = source.ToArray();
			var maxLen = array.Length;

			count = Math.Min(count, array.Length);

			for (var i = 0; i < count; i++)
			{
				var idx = Randomizer.Next(maxLen);
				maxLen--;

				Swap(array, idx, maxLen);
				yield return array[maxLen];
			}
		}

		private static void Swap<T>(T[] array, int j, int k)
		{
			T temp = array[j];
			array[j] = array[k];
			array[k] = temp;
		}
	}
}