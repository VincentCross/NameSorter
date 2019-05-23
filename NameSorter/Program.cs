using NameSorter.Controller;
using System;
using System.IO;

namespace NameSorter
{
	class Program
	{
		static void Main(string[] args)
		{
			if ( args.Length <= 0 || String.IsNullOrEmpty(args[0]))
			{
				Console.WriteLine("Use: name-sorter <filepath>");
				return;
			}

			if (!File.Exists(args[0]))
			{
				Console.WriteLine("File not found: " + args[0]);
				return;
			}

			IFileController inputFC = new FileController(args[0]);
			IFileController outputFC = new FileController("./sorted-names-list.txt");
			INameList nameList = new NameList(inputFC.Read());
			nameList.Sort();

			foreach (var name in nameList.GetAllNames())
			{
				Console.WriteLine(name);
			};

			outputFC.Write(nameList.GetAllNames());
		}
	}
}
