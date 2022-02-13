using System;
using System.Collections.Generic;
					
public class Program
{
	private static List<int> holes = new List<int>();
	private static int solutionCount = 0;
	
	public static void Main()
	{
		int[,] puzzle = {
			{ 0, 0, 5, 0, 0, 0, 1, 0, 7 },
			{ 0, 0, 4, 0, 0, 8, 0, 0, 0 },
			{ 0, 8, 0, 1, 0, 5, 0, 0, 0 },
			{ 3, 0, 7, 0, 0, 0, 8, 0, 0 },
			{ 0, 1, 0, 0, 4, 0, 0, 0, 3 },
			{ 0, 0, 0, 0, 0, 0, 0, 9, 1 },
			{ 5, 0, 1, 6, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 7, 0, 6, 0, 9, 1, 3, 0, 0 }
		};

		InitializeHoles(puzzle);
		//Console.WriteLine("Hole count: {0}", holes.Count);
		
		Solve(puzzle, 0);
		
		//if (SolveSudoku(puzzle, 0, 0))
		//	PrintSudoku(puzzle);
		
		Console.WriteLine("Number of solutions: {0}", solutionCount);
		Console.WriteLine("Done");
	}
	
	public static void PrintSudoku(int[,] puzzle)
	{
		Console.WriteLine("+-----+-----+-----+");

		for (int i = 1; i < 10; ++i)
		{
			for (int j = 1; j < 10; ++j)
				Console.Write("|{0}", puzzle[i - 1, j - 1]);

			Console.WriteLine("|");
			if (i % 3 == 0) Console.WriteLine("+-----+-----+-----+");
		}
		
		Console.WriteLine();
		Console.WriteLine();
	}

	public static bool SolveSudoku(int[,] puzzle, int row, int col)
	{
		if (row < 9 && col < 9)
		{
			if (puzzle[row, col] != 0)
			{
				if ((col + 1) < 9) return SolveSudoku(puzzle, row, col + 1);
				else if ((row + 1) < 9) return SolveSudoku(puzzle, row + 1, 0);
				else return true;
			}
			else
			{
				for (int i = 0; i < 9; ++i)
				{
					if (IsAvailable(puzzle, row, col, i + 1))
					{
						puzzle[row, col] = i + 1;

						if ((col + 1) < 9)
						{
							if (SolveSudoku(puzzle, row, col + 1)) return true;
							else puzzle[row, col] = 0;
						}
						else if ((row + 1) < 9)
						{
							if (SolveSudoku(puzzle, row + 1, 0)) return true;
							else puzzle[row, col] = 0;
						}
						else return true;
					}
				}
			}

			return false;
		}
		else return true;
	}

	private static bool IsAvailable(int[,] puzzle, int row, int col, int num)
	{
		int rowStart = (row / 3) * 3;
		int colStart = (col / 3) * 3;

		for (int i = 0; i < 9; ++i)
		{
			if (puzzle[row, i] == num) return false;
			if (puzzle[i, col] == num) return false;
			if (puzzle[rowStart + (i / 3), colStart + (i % 3)] == num) return false;
		}

		return true;
	}
	
	/* My Solution */
	
	private static void InitializeHoles(int[,] puzzle)
	{
		for (var i=0; i<9; i++)
			for (var j=0; j<9; j++)
				if (puzzle[i,j] == 0)
					holes.Add(i * 9 + j);
	}
	
	private static bool Solve(int[,] puzzle, int idx)
	{
		if (idx == holes.Count)
		{
			PrintSudoku(puzzle);
			solutionCount++;
			return solutionCount >= 10;
		}
		else
		{
			for (var num=1; num<=9; num++)
			{
				if (IsValid(puzzle, idx, num))
				{
					int row = holes[idx] / 9, col = holes[idx] % 9;

					puzzle[row, col] = num;
					if (Solve(puzzle, idx+1)) return true;
					else puzzle[row, col] = 0;
				}
			}
			return false;
		}
	}
	
	private static bool IsValid(int[,] puzzle, int idx, int num)
	{
		//Console.WriteLine(idx);
		int row = holes[idx] / 9; 
		int col = holes[idx] % 9;
		int rowStart = (row / 3) * 3;
		int colStart = (col / 3) * 3;

		for (int i = 0; i < 9; ++i)
		{
			if (puzzle[row, i] == num) return false;
			if (puzzle[i, col] == num) return false;
			if (puzzle[rowStart + (i / 3), colStart + (i % 3)] == num) return false;
		}

		return true;
	}
}