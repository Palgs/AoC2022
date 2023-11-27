namespace AdvendOfCode
{
	class Day9
	{
		static void Main(string[] args)
		{
			var inputs = File.ReadLines("input.txt").ToList();
			if (inputs == null) { Console.WriteLine("No Input Found"); return; }
			Dictionary<(int Row, int Column), Cell> grid;

			grid = new Dictionary<(int Row, int Column), Cell>();
			// Initialize starting position, e.g., (0,0)
			grid[(0, 0)] = new Cell("S", true); // Assuming Cell is a class you've defined

			var newRow = 0;
			var newCol = 0;
			var head = (Row: 0, Column: 0);
			var tail = (Row: 0, Column: 0);

			foreach (var input in inputs)
			{
				var move = input.Split(' ');
				var direction = move[0];
				var steps = Convert.ToInt32(move[1]);

				for (int i = 0; i < steps; i++)
				{
					newRow = head.Row;
					newCol = head.Column;
					if (direction == "R")
					{
						newCol = head.Column + 1;
					}
					else if (direction == "L")
					{
						newCol = head.Column - 1;
					}
					else if (direction == "D")
					{
						newRow = head.Row + 1;
					}
					else if (direction == "U")
					{
						newRow = head.Row - 1;
					}
					if (!grid.ContainsKey((newRow, newCol)))
					{
						grid[(newRow, newCol)] = new Cell("H", false);
					}
					head = (newRow, newCol);
					newRow = tail.Row;
					newCol = tail.Column;
					if ((head.Row - tail.Row) > 1)
					{
						if ((head.Column - tail.Column) > 0)
						{
							newRow = tail.Row + 1;
							newCol = tail.Column + 1;
							//move tail diagonally right-down
						}
						else if ((head.Column - tail.Column) < 0)
						{
							newRow = tail.Row + 1;
							newCol = tail.Column - 1;
							//move tail diagonally left-down
						}
						else
						{
							newRow = tail.Row + 1;
							//move tail straigth down
						}
					}
					else if ((head.Row - tail.Row) < -1)
					{
						if ((head.Column - tail.Column) > 0)
						{
							newRow = tail.Row - 1;
							newCol = tail.Column + 1;
							//move tail diagonally right-up
						}
						else if ((head.Column - tail.Column) < 0)
						{
							newRow = tail.Row - 1;
							newCol = tail.Column - 1;
							//move tail diagonally left-up
						}
						else
						{
							newRow = tail.Row - 1;
							//move tail straigth up
						}
					}
					else if ((head.Column - tail.Column) > 1)
					{
						if ((head.Row - tail.Row) > 0)
						{
							newRow = tail.Row + 1;
							newCol = tail.Column + 1;
							//move tail diagonally right-down
						}
						else if ((head.Row - tail.Row) < 0)
						{
							newRow = tail.Row - 1;
							newCol = tail.Column + 1;
							//move tail diagonally right-up
						}
						else
						{
							newCol = tail.Column + 1;
							//move tail straigth right
						}
					}
					else if ((head.Column - tail.Column) < -1)
					{
						if ((head.Row - tail.Row) > 0)
						{
							newRow = tail.Row + 1;
							newCol = tail.Column - 1;
							//move tail diagonally left-down
						}
						else if ((head.Row - tail.Row) < 0)
						{
							newRow = tail.Row - 1;
							newCol = tail.Column - 1;
							//move tail diagonally left-up
						}
						else
						{
							newCol = tail.Column - 1;
							//move tail straigth left
						}
					}
					tail = (newRow, newCol);
					if (tail != head)
					{
						if (!grid.ContainsKey((newRow, newCol)))
						{
							grid[(newRow, newCol)] = new Cell("T", true);
						}
						else
						{
							grid[(newRow, newCol)] = new Cell("T", true);
						}
					}
					else
					{
						grid[(newRow, newCol)] = new Cell("H", true);
					}
				}
			}

			var nrOfTailCells = 0;
			foreach (var cell in grid)
			{
				if (cell.Value.WasTail)
				{
					nrOfTailCells++;
				}
			}

			Console.WriteLine(nrOfTailCells);

			var orderedGrid = grid.OrderBy(x => x.Key.Row).ThenBy(x => x.Key.Column);
		}
	}

	class Cell
	{
		public string Text { get; set; }
		public bool WasTail { get; set; }

		public Cell(string text, bool wasTail)
		{
			Text = text;
			WasTail = wasTail;
		}
	}
}