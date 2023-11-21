using System.Diagnostics;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace AdvendOfCode
{
	class Day7
	{
		List<Directory> _SmallDir = new List<Directory>();
		List<Directory> _Directories = new List<Directory>();

		static void Main(string[] args)
		{
			var consoleLog = File.ReadLines("input.txt").ToList();
			if (consoleLog == null) { Console.WriteLine("No Input Found"); return; }

			var day7 = new Day7();

			var fileTree = new Directory("/", null);

			Directory currDir = fileTree;

			foreach (var line in consoleLog)
			{
				if (line.StartsWith("$"))
				{
					var cmd = line.Split(' ');
					if (cmd.Length == 2) //ls
					{

					}
					else if (cmd.Length == 3) //cd x
					{
						if (cmd[2] == "..")
						{
							if(currDir.Parent != null)
							{
								currDir = currDir.Parent;
							}
							else
							{
								Console.WriteLine($"No top Directory found {currDir.Name}: {line}");
								Console.WriteLine("Stop program? [y,n]");
								var x = Console.ReadLine();
								if (x == "y")
								{
									break;
								}
							}
						}
						else
						{
							var newdir = (from it in currDir.Subdirectories where it.Name == cmd[2] select it).FirstOrDefault();

							if (newdir != null)
							{
								currDir = newdir;
							}
							else
							{
								Console.WriteLine($"No such Directory in {currDir.Name}: {line}");
								Console.WriteLine("Stop program? [y,n]");
								var x = Console.ReadLine();
								if (x == "y")
								{
									break;
								}
							}
						}
					}
				}
				else if (line.StartsWith("dir"))
				{
					var cmd = line.Split(' ');
					currDir.Subdirectories.Add(new Directory(cmd[1], currDir));
				}
				else //file
				{
					var cmd = line.Split(' ');
					currDir.Files.Add(new SubFile(cmd[1], Convert.ToInt32(cmd[0])));
				}
			}

			var totalTreeSize = day7.DirectorySize(fileTree);
			
			Console.WriteLine(totalTreeSize);

			var totalSmallDirSize = 0;
			foreach(var dir in day7._SmallDir)
			{
				totalSmallDirSize += dir.Size;
			}
			Console.WriteLine(totalSmallDirSize);

			Console.WriteLine();
			Console.WriteLine();

			var totalSpace = 70000000;
			var freeSpace = totalSpace - totalTreeSize;
			var toDelete = 30000000 - freeSpace;

			day7._Directories = day7._Directories.Where(x => x.Size >= toDelete).OrderBy(x => x.Size).ToList();

			var dirToDel = day7._Directories.FirstOrDefault();

			Console.WriteLine($"Total Space: {totalSpace}");
			Console.WriteLine($"Used Space: {totalTreeSize}");
			Console.WriteLine($"Free Space: {freeSpace}");
			Console.WriteLine($"Data to delete: {toDelete}");
			Console.WriteLine();
			Console.WriteLine($"Directory to delete: {dirToDel.Name}, {dirToDel.Size}");

		}

		public int DirectorySize(Directory dir)
		{
			var dirSize = 0;
			foreach (var file in dir.Files)
			{
				dirSize += file.Size;
			}

			foreach(var directory in dir.Subdirectories)
			{
				dirSize += DirectorySize(directory);
			}

			dir.Size = dirSize;
			if (dir.Size <= 100000)
			{
				_SmallDir.Add(dir);
			}

			_Directories.Add(dir);
			return dirSize;
		}
	}

	class Directory
	{
		public Directory? Parent;
		public List<Directory> Subdirectories;
		public List<SubFile> Files;
		public string Name;
		public int Size;

		public Directory(string name, Directory parent)
		{
			Name = name;
			Size = 0;
			Parent = parent;
			Subdirectories = new List<Directory>();
			Files = new List<SubFile>();
		}
	}

	class SubFile
	{
		public string Name;
		public int Size;

		public SubFile(string name, int size)
		{
			Name = name;
			Size = size;
		}
	}
}