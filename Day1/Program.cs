namespace AdvendOfCode
{
	class Day1
	{
		static void Main(string[] args)
		{
			var context = File.ReadLines("input.txt").ToList();

			var result = new List<int>
			{
				0
			};
			var i = 0;
			foreach(var line in context)
			{
				if(line == "")
				{
					result.Add(0);
					i++;
				}
				else
				{
					result[i] += Convert.ToInt32(line);
				}
			}

			result.Sort();

			Console.WriteLine(result[result.Count-1]);
			Console.WriteLine(result[result.Count - 2]);
			Console.WriteLine(result[result.Count - 3]);
			var tot = result[result.Count - 1] + result[result.Count - 2] + result[result.Count - 3];
			Console.WriteLine(tot);
		}
	}
}