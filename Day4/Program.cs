namespace AdvendOfCode
{
	class Day4
	{
		static void Main(string[] args)
		{
			var camp = File.ReadLines("input.txt").ToList();

			var containedPairs = 0;
			var overlappedPairs = 0;

			foreach (var pair in camp)
			{
				var elfs = pair.Split(',');
				var elf1 = elfs[0].Split('-');
				var elf2 = elfs[1].Split("-");
				var start1 = Convert.ToInt32(elf1[0]);
				var start2 = Convert.ToInt32(elf2[0]);

				var end1 = Convert.ToInt32(elf1[1]);
				var end2 = Convert.ToInt32(elf2[1]);

				if(CheckIfContained(start1, start2, end1, end2))
				{
					containedPairs++;
				}
				else if(CheckIfOverlapped(start1, start2, end1, end2))
				{
					overlappedPairs++;
				}
			}

			Console.WriteLine("Contained Pairs");
			Console.WriteLine(containedPairs);
			Console.WriteLine("Total overlapped Pairs");
			Console.WriteLine(overlappedPairs + containedPairs);
		}

		static bool CheckIfContained(int start1, int start2, int end1, int end2)
		{
			//check if elf1 is contained in elf2
			if(start1 >= start2 && end1 <= end2)
			{
				return true;
			}
			//check if elf2 is contained in elf2
			else if(start2 >= start1 && end2 <= end1)
			{
				return true;
			}
			return false;
		}
		static bool CheckIfOverlapped(int start1, int start2, int end1, int end2)
		{
			if (start1 <= start2 && end1 >= start2 && end1 < end2)
			{
				return true;
			}
			else if (start2 <= start1 && end2 >= start1 && end2 < end1)
			{
				return true;
			}
			return false;
		}
	}
}