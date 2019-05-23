﻿using NameSorter.Controller;
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

			IFileController fc = new FileController(args[0]);
			INameList nameList = new NameList(fc.Read());
			nameList.Sort();

			foreach (var name in nameList.GetAllNames())
			{
				Console.WriteLine(name);
			};

			fc.Write(nameList.GetAllNames());
		}
	}
}
