using NameSorter.Controller;
using NameSorter.Model;
using System;
using System.Collections.Generic;

namespace NameSorter
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] nameArray = {
				"Order2 Johnson",
				"Order3 Miles",
				"Order5 Wender",
				"Order4 Wender",
				"Order1 Andrews"
			};

			INameList nameList = new NameList(nameArray);
			

			Console.WriteLine("-------------Presort---------------");
			foreach (Name name in (List<Name>)nameList.GetAllNames())
			{
				Console.WriteLine(name);
			};
			Console.WriteLine("-----------------------------------");

			nameList.Sort();

			Console.WriteLine("-------------Postsort--------------");
			foreach (Name name in (List<Name>)nameList.GetAllNames())
			{
				Console.WriteLine(name);
			};
			Console.WriteLine("-----------------------------------");
		}
	}
}
