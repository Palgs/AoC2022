namespace AdvendOfCode
{
	class Day5
	{
		static void Main(string[] args)
		{
			var stream = File.ReadAllText("input.txt");

			var packetMarker = "";
			var packetIndex = 4;
			var messageMarker = "";
			var messageIndex = 14;
			for (int i = 0; i < stream.Length-4; i++)
			{
				packetMarker = stream.Substring(i, 4);
				if (CheckMarker(packetMarker, packetMarker.Length))
				{
					packetIndex = i + 4;
					i = stream.Length-4;
				}
			}
			for (int i = 0; i < stream.Length - 14; i++)
			{
				messageMarker = stream.Substring(i, 14);
				if (CheckMarker(messageMarker, messageMarker.Length))
				{
					messageIndex = i + 14;
					i = stream.Length - 4;
				}
			}

			Console.WriteLine(packetMarker);
			Console.WriteLine(packetIndex);
			Console.WriteLine();
			Console.WriteLine(messageMarker);
			Console.WriteLine(messageIndex);
		}

		static bool CheckMarker(string marker, int length)
		{
			var result = true;
			for (int i = 0; i < length; i++)
			{
				var character = marker[i];
				var x = (from it in marker where it == character select it).ToList().Count;
				if(x >= 2)
				{
					result = false;
				}
			}
			return result;
		}
	}
}