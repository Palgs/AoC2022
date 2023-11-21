namespace AdvendOfCode
{
	class Day5
	{
		static void Main(string[] args)
		{
			var cargoInstructions = File.ReadLines("input.txt").ToList();
			if(cargoInstructions == null) { Console.WriteLine("No Input Found"); return; }

			Console.WriteLine("--------------------------Part One--------------------------");
			Console.WriteLine();

			var cargo = cargoInstructions.Take(9).ToList();
			var instructions = cargoInstructions.Skip(10).ToList();

			foreach (var crates in cargo) //print cargo
			{
				Console.WriteLine(crates);
			}

			foreach (var instr in instructions)
			{
				var x = instr.Split(' ');
				var count = Convert.ToInt32(x[1]);
				var origin = Convert.ToInt32(x[3]);
				var dest = Convert.ToInt32(x[5]);

				Console.WriteLine();
				Console.WriteLine($"{count}: {origin} --> {dest}");
				cargo = MoveCrates(count, origin, dest, cargo);
			}
			var columns = SplitCargo(cargo);
			Console.WriteLine();
			Console.WriteLine();

			foreach (var column in columns)
			{
				Console.WriteLine(column[0]);
			}

			Console.WriteLine("--------------------------Part Two--------------------------");
			Console.WriteLine();

			cargo = cargoInstructions.Take(9).ToList();
			instructions = cargoInstructions.Skip(10).ToList();
			
			foreach (var crates in cargo) //print cargo
			{
				Console.WriteLine(crates);
			}

			foreach (var instr in instructions)
			{
				var x = instr.Split(' ');
				var count = Convert.ToInt32(x[1]);
				var origin = Convert.ToInt32(x[3]);
				var dest = Convert.ToInt32(x[5]);

				//Console.WriteLine();
				//Console.WriteLine($"{count}: {origin} --> {dest}");
				cargo = MoveMultipleCrates(count, origin, dest, cargo);
			}
			columns = SplitCargo(cargo);
			Console.WriteLine();
			Console.WriteLine();

			foreach (var column in columns)
			{
				Console.WriteLine(column[0]);
			}
		}

		static List<string>? UpdateCargo(List<string>[] stacks)
		{
			var maxRows = 0;

			foreach(var column in stacks) //get number of total rows
			{
				var rows = column.Count;
				if(rows > maxRows)
				{
					maxRows = rows;
				}
			}

			for(int i = 0; i < stacks.Length; i++) //fill columns with spaces
			{
				var column = stacks[i];
				for(int rows = column.Count; rows < maxRows; rows = column.Count)
				{
					column.Insert(0, "   ");
				}
			}

			var cargo = new List<string>();

			for (int i = 0; i < maxRows; i++) //convert columns to rows
			{
				var row = "";
				var column = 1;
				foreach (var col in stacks)
				{
					row += col[i];
					if(column < stacks.Length)
					{
						row += ' ';
					}
					column++;
				}
				cargo.Add(row);
			}

			foreach (var crates in cargo) //print cargo
			{
				Console.WriteLine(crates);
			}
			return cargo;
		}

		static List<string>? MoveCrates(int count, int origin, int dest, List<string> cargo)
		{
			var columns = SplitCargo(cargo);

			origin--;
			dest--;

			for (int i = 0; i < count; i++)
			{
				columns[dest].Insert(0, columns[origin][0]);
				columns[origin].RemoveAt(0);
			}
			return UpdateCargo(columns);
		}

		static List<string>? MoveMultipleCrates(int count, int origin, int dest, List<string> cargo)
		{
			var columns = SplitCargo(cargo);

			origin--;
			dest--;

			var movedCrates = new List<string>();

			for (int i = 0; i < count; i++)
			{
				movedCrates.Add(columns[origin][0]);
				columns[origin].RemoveAt(0);
			}
			columns[dest].InsertRange(0, movedCrates);
			return UpdateCargo(columns);
		}

		static List<string>[] SplitCargo(List<string> cargo)
		{
			var columns = new List<string>[9];
			for (int i = 0; i < 9; i++) //9 times for 9 columns
			{
				for (int j = 0; j < cargo.Count; j++) //nr of rows
				{
					var row = cargo[j];
					var checkChar = i * 4 + 1;
					if (row[checkChar] != ' ')
					{
						var diff = cargo.Count - j;
						var col = new List<string>();
						for (int k = 0; k < diff; k++)
						{
							row = cargo[j];
							var crate = row.Substring(checkChar-1, 3);
							col.Add(crate);
							j++;
						}
						columns[i] = col;
					}
				}
			}
			return columns;
		}
	}
}