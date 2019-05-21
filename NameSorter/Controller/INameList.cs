using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Controller
{
	public interface INameList
	{
		void AddName(string name);
		Name GetName(string name);
		IEnumerable<Name> GetAllNames();
		void SortBySurname();
	}
}
