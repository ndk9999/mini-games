using System.Linq;

namespace Loto.Core.Generators
{
	public class NumberSequence
	{
		private int[] _numbers;
		private int _maxIndex;

		public NumberSequence(int maxValue)
		{
			_maxIndex = maxValue;
			_numbers = Enumerable.Range(1, maxValue).ToArray();
		}

		public int GetOne()
		{
			// Chọn 1 vị trí ngẫu nhiên trong những số còn lại
			var idx = Randomizer.Next(_maxIndex);
			
			// Hoán đổi số tại vị trí đó với số cuối cùng
			var temp = _numbers[_maxIndex - 1];
			_numbers[_maxIndex - 1] = _numbers[idx];
			_numbers[idx] = temp;

			// Giảm bớt 1 số
			_maxIndex--;

			// Trả về số ở vị trí cuối cùng
			return _numbers[_maxIndex];
		}

		public void StepBack(int numStep = 1)
		{
			_maxIndex += numStep;
		}
	}
}