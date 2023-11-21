namespace AdvendOfCode
{
	class Day2
	{
		static void Main(string[] args)
		{
			/* A = Rock
			 * B = Paper
			 * C = Scissors
			 * 
			 * X = Rock (1 point)
			 * Y = Paper (2 points)
			 * Z = Scissors (3 points)
			 * 
			 * Win = 6 points
			 * Draw = 3 points
			 * Loss = 0 points
			 */

			var strategy = File.ReadLines("input.txt").ToList();

			var points = 0;

			foreach (var line in strategy)
			{
				var round = line.Split(' ');
				if (round[1] == "X")
				{
					points++;
				}
				else if (round[1] == "Y")
				{
					points+=2;
				}
				else if (round[1] == "Z")
				{
					points += 3;
				}
				points += RPSCalc1(round);
			}

			Console.WriteLine("Part 1");
			Console.WriteLine(points);
			Console.WriteLine();

			points = 0;

			foreach (var line in strategy)
			{
				var round = line.Split(' ');
				points += RPSCalc2(round);
			}

			Console.WriteLine("Part 2");
			Console.WriteLine(points);
		}

		static int RPSCalc1(string[] round)
		{
			var p1 = round[0] == "A" ? "R" : round[0] == "B" ? "P" : "S";
			var me = round[1] == "X" ? "R" : round[1] == "Y" ? "P" : "S";

			if(p1 == me) // Draw
			{
				return 3;
			}
			else if(p1 == "R" &&  me == "P" || p1 == "P" && me == "S" || p1 == "S" && me == "R") // Win
			{
				return 6;
			}
            else // Loss
            {
				return 0;
            }
		}

		static int RPSCalc2(string[] round)
		{
			var points = 0;
			var p1 = round[0] == "A" ? "R" : round[0] == "B" ? "P" : "S";
			var me = round[1];

			if (me == "Y") // Draw
			{
				points = 3;
				switch(p1)
				{
					case "R":
						points++;
						break;
					case "P":
						points += 2;
						break;
					case "S":
						points += 3;
						break;
				}
			}
			else if (me == "Z") // Win
			{
				points = 6;
				switch (p1)
				{
					case "R":
						points += 2;
						break;
					case "P":
						points += 3;
						break;
					case "S":
						points++;
						break;
				}
			}
			else // Loss
			{
				switch (p1)
				{
					case "R":
						points += 3;
						break;
					case "P":
						points++;
						break;
					case "S":
						points += 2;
						break;
				}
			}

			return points;
		}
	}
}