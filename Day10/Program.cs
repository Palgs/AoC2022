using System.Data;
using System.Threading.Tasks.Sources;

namespace AdvendOfCode
{
	class Day10
	{
		static void Main(string[] args)
		{
			var inputs = File.ReadLines("input.txt").ToList();
			if (inputs == null) { Console.WriteLine("No Input Found"); return; }

			var cycle = 1;
			var xRegister = 1;
			var pointer = (Row: 0, Column: 0);
			string[,] screen = new string[6,40];
			var valueList = new List<int>();
			foreach (var input in inputs)
			{
				var x = input.Split(' ');
				var op = x[0];
				var value = 0;
				var step = 0;
				if (x.Length > 1)
				{
					value = Convert.ToInt32(x[1]);
				}
				if (op == "noop")
				{
					step = 1;
				}
				else if (op == "addx")
				{
					step = 2;
				}
				for (int i = 0; i < step; i++)
				{
					if ((cycle / 19f) == 1 || (cycle / 59f) == 1 || (cycle / 99f) == 1 || (cycle / 139f) == 1 || (cycle / 179f) == 1 || (cycle / 219f) == 1)
					{
						valueList.Add(xRegister * cycle);
					}
					cycle++;

					//Screen op
					if (pointer.Column >= (xRegister - 1) && pointer.Column <= (xRegister + 1))
					{
						screen[pointer.Row, pointer.Column] = "#";
					}
					else
					{
						screen[pointer.Row, pointer.Column] = ".";
					}

					if (pointer.Column == 39)
					{
						pointer.Row++;
						pointer.Column = 0;
					}
					else
					{
						pointer.Column++;
					}
				}
				xRegister += value;
			}

			Console.WriteLine(valueList.Sum());
			Console.WriteLine();
			Console.WriteLine();
			for(int i = 0;i < 6;i++)
			{
				for(int j = 0;j < 40; j++)
				{
					Console.Write(screen[i,j]);
				}
				Console.WriteLine();
			}
		}
	}
}