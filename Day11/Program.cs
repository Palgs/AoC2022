using System.Text.RegularExpressions;

namespace AdvendOfCode
{
	class Day11
	{
		static void Main(string[] args)
		{
			var text = File.ReadAllText("input.txt");
			if (text == null) { Console.WriteLine("No Input Found"); return; }

			var monkeys = text.Split("\n\n").ToList();
			var monkesglobal = new List<Monkey>();
			foreach (var monke in monkeys)
			{
				var stats = monke.Split('\n');
				var nr = 0;
				var itemsList = new List<long>();
				var op = "";
				var test = 0;
				var @true = 0;
				var @false = 0;
				foreach (var stat in stats)
				{
					if (stat.StartsWith("Monk"))
					{
						var x = Regex.Matches(stat, @"\d");
						nr = Convert.ToInt32(x.First().Value);
					}
					else if (stat.Contains("Start"))
					{
						var x = Regex.Matches(stat, @"\d+");
						foreach (Match item in x)
						{
							itemsList.Add(long.Parse(item.Value));
						}
					}
					else if (stat.Contains("Oper"))
					{
						var x = Regex.Matches(stat, @"\d+|[+*/-]\sold|[+*/-]");
						foreach (Match item in x)
						{
							op += item.Value + " ";
						}
					}
					else if (stat.Contains("Test"))
					{
						var x = Regex.Matches(stat, @"\d+");
						test = Convert.ToInt32(x.First().Value);
					}
					else if (stat.Contains("true"))
					{
						var x = Regex.Matches(stat, @"\d");
						@true = Convert.ToInt32(x.First().Value);
					}
					else if (stat.Contains("false"))
					{
						var x = Regex.Matches(stat, @"\d");
						@false = Convert.ToInt32(x.First().Value);
					}
				}
				monkesglobal.Add(new Monkey(nr, itemsList, op, test, @true, @false));
			}

			var monkes = new List<Monkey>();
			//monkes.AddRange(monkesglobal);
			//for (int i = 0; i < 20; i++)
			//{
			//	foreach (Monkey monke in monkes)
			//	{
			//		foreach (var item in monke.ItemsList)
			//		{
			//			monke.Inspects++;
			//			var lvl = CalcWorryLvl(item, monke.Op.Split(' '));
			//			lvl /= 3;

			//			if ((lvl % monke.Test) == 0)
			//			{
			//				monkes[monke.True].ItemsList.Add(lvl);
			//			}
			//			else
			//			{
			//				monkes[monke.False].ItemsList.Add(lvl);
			//			}
			//		}
			//		monke.ItemsList = new List<long>();
			//	}
			//}

			//monkes = monkes.OrderByDescending(x => x.Inspects).ToList();
			//Console.WriteLine("------------Part 1------------");
			//Console.WriteLine(monkes[0].Inspects * monkes[1].Inspects);
			//Console.WriteLine();

			//monkes = new List<Monkey>();
			monkes.AddRange(monkesglobal);
			var divisorProduct = 1;
			foreach(var monke in monkes)
			{
				divisorProduct *= monke.Test;
			}

			for (int i = 0; i < 10000; i++)
			{
				foreach (Monkey monke in monkes)
				{
					var items = monke.ItemsList;
					monke.ItemsList = new List<long>();
					foreach (var item in items)
					{
						var lvl = CalcWorryLvl(item, monke.Op.Split(' ')) % divisorProduct;
						if(lvl % monke.Test == 0)
						{
							monkes[monke.True].ItemsList.Add(item);
						}
						else
						{
							monkes[monke.False].ItemsList.Add(item);
						}
						monke.Inspects++;
					}
					//foreach (var item in monke.ItemsList)
					//{
					//	monke.Inspects++;
					//	var lvl = CalcWorryLvl(item, monke.Op.Split(' '));

					//	if ((lvl % monke.Test) == 0)
					//	{
					//		monkes[monke.True].ItemsList.Add(lvl);
					//	}
					//	else
					//	{
					//		monkes[monke.False].ItemsList.Add(lvl);
					//	}
					//}
					//monke.ItemsList = new List<long>();
				}
			}

			monkes = monkes.OrderByDescending(x => x.Inspects).ToList();
			Console.WriteLine("------------Part 2------------");
			Console.WriteLine(monkes[0].Inspects * monkes[1].Inspects);
		}

		static long CalcWorryLvl(long item, string[] op)
		{
			var res = item;
			if (op[0] == "+")
			{
				res += Convert.ToInt32(op[1]);
			}
			else if (op[0] == "-")
			{
				res -= Convert.ToInt32(op[1]);
			}
			else if (op[0] == "*")
			{
				if (op[1] == "old")
				{
					res *= res;
				}
				else
				{
					res *= Convert.ToInt32(op[1]);
				}
			}
			else if (op[0] == "/")
			{
				res /= Convert.ToInt32(op[1]);
			}
			return res;
		}
	}

	class Monkey
	{
		public int Number;
		public List<long> ItemsList;
		public string Op;
		public int Test;
		public int True;
		public int False;
		public long Inspects = 0;

		public Monkey(int Number, List<long> itemsList, string op, int test, int @true, int @false)
		{
			this.Number = Number;
			ItemsList = itemsList;
			Op = op;
			Test = test;
			True = @true;
			False = @false;
		}
	}
}