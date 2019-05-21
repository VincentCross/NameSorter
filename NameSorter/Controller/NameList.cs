using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Controller
{
	class NameList : INameList
	{
		private List<Name> _nameList;

		//
		// Constructors
		//

		public NameList()
		{
			_nameList = new List<Name>();
		}

		public NameList(string[] inputNames)
		{
			_nameList = new List<Name>();

			foreach (var name in inputNames)
			{
				Name parsedName = ParseName(name);
				_nameList.Add(parsedName);
			}
		}

		//
		// Methods
		//

		public void AddName(string name)
		{
			_nameList.Add(ParseName(name));
		}

		public void DeleteName(string name)
		{
			_nameList.Remove(GetName(name));
		}

		public IEnumerable<Name> GetAllNames()
		{
			return _nameList;
		}

		public Name GetName(string name)
		{
			Name nameToFind = ParseName(name);

			return _nameList.Find(nl => nl.givenNames == nameToFind.givenNames && nl.surname == nameToFind.surname);
		}

		// Helper method. Splits passed string up into given names and surname and returns Name object.
		private Name ParseName(string name)
		{
			string[] splitName = name.Split(' ');

			string splitSurname = splitName[splitName.Length - 1];
			string splitGivenNames = "";

			for (int i = 0; i < splitName.Length - 2; i++)
				splitGivenNames += splitName[i];

			return new Name()
			{
				surname = splitSurname,
				givenNames = splitGivenNames
			};
		}
	}
}
