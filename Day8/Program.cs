using System.Data.Common;

namespace AdvendOfCode
{
	class Day8
	{
		static void Main(string[] args)
		{
			var gridRows = File.ReadLines("input.txt").ToList();
			if (gridRows == null) { Console.WriteLine("No Input Found"); return; }

			var rows = gridRows.Count;
			var colls = gridRows[1].Length;

			var totalVisibleTrees = rows * 2 + (colls - 2) * 2;
			var scenicScores = new List<int>();

			for (int i = 1; i < rows - 1; i++)
			{
				for (int j = 1; j < colls - 1; j++)
				{
					if (CheckTopVisibility(i, j, gridRows) || CheckBottomVisibility(i, j, gridRows) || CheckLeftVisibility(i, j, gridRows) || CheckRightVisibility(i, j, gridRows))
					{
						totalVisibleTrees++;
					}
				}
			}

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < colls; j++)
				{
					var left = CalculateScore(i, j, 0, -1, gridRows);
					var right = CalculateScore(i, j, 0, 1, gridRows);
					var top = CalculateScore(i, j, -1, 0, gridRows);
					var bottom = CalculateScore(i, j, 1, 0, gridRows);
					var score = left * right * top * bottom;
					scenicScores.Add(score);
				}
			}
			scenicScores = scenicScores.OrderByDescending(x => x).ToList();

			foreach (var score in scenicScores)
			{
				int i = 0;
				if (i == 5)
				{
					Console.WriteLine();
					i = 0;
				}
				Console.Write($"{score}, ");
				i++;
			}

			Console.WriteLine(totalVisibleTrees);
			Console.WriteLine(scenicScores.Max());
		}

		static bool CheckTopVisibility(int row, int column, List<string> trees)
		{
			var result = true;
			var tree = Convert.ToInt32(trees[row][column].ToString());
			var scenicList = new List<int>();
			for (int i = 0; i < row; i++)
			{
				if (tree <= Convert.ToInt32(trees[i][column].ToString()))
				{
					result = false;
				}
			}

			return result;
		}

		static bool CheckBottomVisibility(int row, int column, List<string> trees)
		{
			var result = true;
			var tree = Convert.ToInt32(trees[row][column].ToString());
			for (int i = row + 1; i < trees.Count; i++)
			{
				if (tree <= Convert.ToInt32(trees[i][column].ToString()))
				{
					result = false;
				}
			}

			return result;
		}

		static bool CheckLeftVisibility(int row, int column, List<string> trees)
		{
			var result = true;
			var tree = Convert.ToInt32(trees[row][column].ToString());
			for (int i = 0; i < column; i++)
			{
				if (tree <= Convert.ToInt32(trees[row][i].ToString()))
				{
					result = false;
				}
			}

			return result;
		}

		static bool CheckRightVisibility(int row, int column, List<string> trees)
		{
			var result = true;
			var tree = Convert.ToInt32(trees[row][column].ToString());
			for (int i = column + 1; i < trees[0].Length; i++)
			{
				if (tree <= Convert.ToInt32(trees[row][i].ToString()))
				{
					result = false;
				}
			}

			return result;
		}

		static int CalculateScore(int row, int column, int rowOffset, int columnOffset, List<string> trees)
		{
			var score = 0;

			var checkRow = row + rowOffset;
			var checkColumn = column + columnOffset;

			var tree = Convert.ToInt32(trees[row][column].ToString());

			while(IsInBounds(checkRow, checkColumn) && tree > Convert.ToInt32(trees[checkRow][checkColumn].ToString()))
			{
				score++;
				if(checkRow < row)
				{
					checkRow--;
				}
				else if(checkColumn < column)
				{
					checkColumn--;
				}
				else if(checkRow > row)
				{
					checkRow++;
				}
				else if(checkColumn > column)
				{
					checkColumn++;
				}
			}

			if(IsInBounds(checkRow, checkColumn))
			{
				if (tree <= Convert.ToInt32(trees[checkRow][checkColumn].ToString())) { score++; }
			}

			return score;
		}

		static bool IsInBounds(int row, int column)
		{
			if(row < 0 || column < 0)
			{
				return false;
			}
			if(row > 98 || column > 98)
			{
				return false;
			}
			return true;
		}
	}
}