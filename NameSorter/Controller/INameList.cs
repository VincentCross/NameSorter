using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Controller
{
	interface INameList
	{
		void AddName(string name);
		Name GetName(string name);
		void DeleteName(string name);
		IEnumerable<Name> GetAllNames();
	}
}
