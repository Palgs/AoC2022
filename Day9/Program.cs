namespace AdvendOfCode
{
	class Day9
	{
		static void Main(string[] args)
		{
			var inputs = File.ReadLines("input.txt").ToList();
			if (inputs == null) { Console.WriteLine("No Input Found"); return; }
			Dictionary<(int Row, int Column), Cell> grid = new Dictionary<(int Row, int Column), Cell>();
			for (int i = -210; i < 210; i++)
			{
				for (int j = -210; j < 210; j++)
				{
					grid[(i, j)] = new Cell(".", false);
				}
			}
			grid[(0, 0)] = new Cell("S", true);

			var head = (Row: 0, Column: 0);
			var link1 = (Row: 0, Column: 0);
			var link2 = (Row: 0, Column: 0);
			var link3 = (Row: 0, Column: 0);
			var link4 = (Row: 0, Column: 0);
			var link5 = (Row: 0, Column: 0);
			var link6 = (Row: 0, Column: 0);
			var link7 = (Row: 0, Column: 0);
			var link8 = (Row: 0, Column: 0);
			var link9 = (Row: 0, Column: 0);

			foreach (var input in inputs)
			{
				var move = input.Split(' ');
				var direction = move[0];
				var steps = Convert.ToInt32(move[1]);

				for (int i = 0; i < steps; i++)
				{
					var newRow = head.Row;
					var newCol = head.Column;

					//Head Movement
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
					else
					{
						grid[(newRow, newCol)].Text = "H";
					}
					if (head != (newRow, newCol))
					{
						grid[head].Text = ".";
					}
					head = (newRow, newCol);

					//Link Movement
					var oldRow = link1.Row;
					var oldCol = link1.Column;
					link1 = MoveLink(link1, head);
					grid = CleanUpAfterMove(link1, 1, (oldRow, oldCol), head, grid);

					oldRow = link2.Row;
					oldCol = link2.Column;
					link2 = MoveLink(link2, link1);
					grid = CleanUpAfterMove(link2, 2, (oldRow, oldCol), link1, grid);

					oldRow = link3.Row;
					oldCol = link3.Column;
					link3 = MoveLink(link3, link2);
					grid = CleanUpAfterMove(link3, 3, (oldRow, oldCol), link2, grid);

					oldRow = link4.Row;
					oldCol = link4.Column;
					link4 = MoveLink(link4, link3);
					grid = CleanUpAfterMove(link4, 4, (oldRow, oldCol), link3, grid);

					oldRow = link5.Row;
					oldCol = link5.Column;
					link5 = MoveLink(link5, link4);
					grid = CleanUpAfterMove(link5, 5, (oldRow, oldCol), link4, grid);

					oldRow = link6.Row;
					oldCol = link6.Column;
					link6 = MoveLink(link6, link5);
					grid = CleanUpAfterMove(link6, 6, (oldRow, oldCol), link5, grid);

					oldRow = link7.Row;
					oldCol = link7.Column;
					link7 = MoveLink(link7, link6);
					grid = CleanUpAfterMove(link7, 7, (oldRow, oldCol), link6, grid);

					oldRow = link8.Row;
					oldCol = link8.Column;
					link8 = MoveLink(link8, link7);
					grid = CleanUpAfterMove(link8, 8, (oldRow, oldCol), link7, grid);

					oldRow = link9.Row;
					oldCol = link9.Column;
					link9 = MoveLink(link9, link8);
					grid = CleanUpAfterMove(link9, 9, (oldRow, oldCol), link8, grid);

					#region Part1
					//newRow = tail.Row;
					//newCol = tail.Column;
					//if ((head.Row - tail.Row) > 1)
					//{
					//	if ((head.Column - tail.Column) > 0)
					//	{
					//		newRow = tail.Row + 1;
					//		newCol = tail.Column + 1;
					//		//move tail diagonally right-down
					//	}
					//	else if ((head.Column - tail.Column) < 0)
					//	{
					//		newRow = tail.Row + 1;
					//		newCol = tail.Column - 1;
					//		//move tail diagonally left-down
					//	}
					//	else
					//	{
					//		newRow = tail.Row + 1;
					//		//move tail straigth down
					//	}
					//}
					//else if ((head.Row - tail.Row) < -1)
					//{
					//	if ((head.Column - tail.Column) > 0)
					//	{
					//		newRow = tail.Row - 1;
					//		newCol = tail.Column + 1;
					//		//move tail diagonally right-up
					//	}
					//	else if ((head.Column - tail.Column) < 0)
					//	{
					//		newRow = tail.Row - 1;
					//		newCol = tail.Column - 1;
					//		//move tail diagonally left-up
					//	}
					//	else
					//	{
					//		newRow = tail.Row - 1;
					//		//move tail straigth up
					//	}
					//}
					//else if ((head.Column - tail.Column) > 1)
					//{
					//	if ((head.Row - tail.Row) > 0)
					//	{
					//		newRow = tail.Row + 1;
					//		newCol = tail.Column + 1;
					//		//move tail diagonally right-down
					//	}
					//	else if ((head.Row - tail.Row) < 0)
					//	{
					//		newRow = tail.Row - 1;
					//		newCol = tail.Column + 1;
					//		//move tail diagonally right-up
					//	}
					//	else
					//	{
					//		newCol = tail.Column + 1;
					//		//move tail straigth right
					//	}
					//}
					//else if ((head.Column - tail.Column) < -1)
					//{
					//	if ((head.Row - tail.Row) > 0)
					//	{
					//		newRow = tail.Row + 1;
					//		newCol = tail.Column - 1;
					//		//move tail diagonally left-down
					//	}
					//	else if ((head.Row - tail.Row) < 0)
					//	{
					//		newRow = tail.Row - 1;
					//		newCol = tail.Column - 1;
					//		//move tail diagonally left-up
					//	}
					//	else
					//	{
					//		newCol = tail.Column - 1;
					//		//move tail straigth left
					//	}
					//}
					//tail = (newRow, newCol);


					//if (tail != head)
					//{
					//	if (!grid.ContainsKey((newRow, newCol)))
					//	{
					//		grid[(newRow, newCol)] = new Cell("T", true);
					//	}
					//	else
					//	{
					//		grid[(newRow, newCol)] = new Cell("T", true);
					//	}
					//}
					//else
					//{
					//	grid[(newRow, newCol)] = new Cell("H", true);
					//}
					#endregion Part1
				}
				if (grid[(0, 0)].Text == ".")
				{
					grid[(0, 0)].Text = "S";
				}
				#region Debug
				//Console.WriteLine("------------------" + input + "------------------");
				//var x = grid.First().Key.Row;
				//foreach (var cell in grid)
				//{
				//	if (cell.Key.Row != x)
				//	{
				//		x = cell.Key.Row;
				//		Console.WriteLine();
				//	}
				//	Console.Write(cell.Value.Text);
				//}
				//Console.WriteLine();
				//Console.WriteLine();
				#endregion Debug
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

		static (int Row, int Column) MoveLink((int Row, int Column) link, (int Row, int Column) prevLink)
		{
			var newRow = link.Row;
			var newCol = link.Column;

			if ((prevLink.Row - link.Row) > 1)
			{
				if ((prevLink.Column - link.Column) > 0)
				{
					newRow = link.Row + 1;
					newCol = link.Column + 1;
					//move link diagonally right-down
				}
				else if ((prevLink.Column - link.Column) < 0)
				{
					newRow = link.Row + 1;
					newCol = link.Column - 1;
					//move link diagonally left-down
				}
				else
				{
					newRow = link.Row + 1;
					//move link straigth down
				}
			}
			else if ((prevLink.Row - link.Row) < -1)
			{
				if ((prevLink.Column - link.Column) > 0)
				{
					newRow = link.Row - 1;
					newCol = link.Column + 1;
					//move link diagonally right-up
				}
				else if ((prevLink.Column - link.Column) < 0)
				{
					newRow = link.Row - 1;
					newCol = link.Column - 1;
					//move link diagonally left-up
				}
				else
				{
					newRow = link.Row - 1;
					//move link straigth up
				}
			}
			else if ((prevLink.Column - link.Column) > 1)
			{
				if ((prevLink.Row - link.Row) > 0)
				{
					newRow = link.Row + 1;
					newCol = link.Column + 1;
					//move link diagonally right-down
				}
				else if ((prevLink.Row - link.Row) < 0)
				{
					newRow = link.Row - 1;
					newCol = link.Column + 1;
					//move link diagonally right-up
				}
				else
				{
					newCol = link.Column + 1;
					//move link straigth right
				}
			}
			else if ((prevLink.Column - link.Column) < -1)
			{
				if ((prevLink.Row - link.Row) > 0)
				{
					newRow = link.Row + 1;
					newCol = link.Column - 1;
					//move link diagonally left-down
				}
				else if ((prevLink.Row - link.Row) < 0)
				{
					newRow = link.Row - 1;
					newCol = link.Column - 1;
					//move link diagonally left-up
				}
				else
				{
					newCol = link.Column - 1;
					//move link straigth left
				}
			}

			link = (newRow, newCol);

			return link;
		}

		static Dictionary<(int Row, int Column), Cell> CleanUpAfterMove((int Row, int Column) link, int linkNr, (int, int) prevPos, (int Row, int Column) prevLink, Dictionary<(int, int), Cell> grid)
		{
			if (link != prevLink)
			{
				if (!grid.ContainsKey(link))
				{
					grid[link] = new Cell(linkNr.ToString(), false);
				}
				else
				{
					grid[link].Text = linkNr.ToString();
				}
				if (prevPos != link)
				{
					grid[prevPos].Text = ".";
				}
			}

			if (linkNr == 9)
			{
				grid[link].WasTail = true;
			}

			return grid;
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