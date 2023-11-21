namespace AdvendOfCode
{
	class Day3
	{
		static void Main(string[] args)
		{
			var cargo = File.ReadLines("input.txt").ToList();

			Console.WriteLine(cargo.Count);
			Console.WriteLine(cargo.Count / 3);

			var singlePriority = 0;
			var groupPriority = 0;

			var group = new List<string>();
			var x = 0;

			foreach (var rucksack in cargo)
			{
				var half = rucksack.Length / 2;
				var first = rucksack[..half];
				var second = rucksack.Substring(half, half);

				for (int i = 0; i < first.Length; i++)
				{
					if (second.Contains(first[i]))
					{
						var c = first[i];
						if (char.IsUpper(c))
						{
							singlePriority += 26;
						}
						singlePriority += (int)c % 32;
						i = first.Length;
					}
				}

				group.Add(rucksack);

				if (group.Count == 3)
				{
					x++;
					Console.WriteLine(x);
					Console.WriteLine(group[0]);
					Console.WriteLine(group[1]);
					Console.WriteLine(group[2]);

					for (int i = 0; i < group[0].Length; i++)
					{
						var c = group[0][i];
						if (group[1].Contains(c))
						{
							if (group[2].Contains(c))
							{
								Console.WriteLine(c);
								if (char.IsUpper(c))
								{
									groupPriority += 26;
								}
								groupPriority += (int)c % 32;
								i = group[0].Length;
							}
						}
					}

					group.Clear();
				}
			}

			Console.WriteLine($"Single: {singlePriority}");
			Console.WriteLine($"Group: {groupPriority}");
		}
	}
}