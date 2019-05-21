using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Controller
{
	public class NameList : INameList
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
				AddName(name);
			}
		}

		//
		// Methods
		//

		public void AddName(string name)
		{
			Name nameToAdd = ParseName(name);

			if (nameToAdd != null)
			{
				_nameList.Add(nameToAdd);
			}
		}

		public List<Name> GetAllNames()
		{
			return _nameList;
		}

		public Name GetName(string name)
		{
			Name nameToFind = ParseName(name);

			return _nameList.Find(nl => nl.givenNames == nameToFind.givenNames && nl.surname == nameToFind.surname);
		}

		public void Sort()
		{
			_nameList.Sort(delegate(Name n1, Name n2)
			{
				int result = 0;

				// If surnames match
					// compare given names
				// Else compare surnames

				if (n1.surname == n2.surname)
				{
					result = n1.givenNames.CompareTo(n2.givenNames);
				}
				else
				{
					result = n1.surname.CompareTo(n2.surname);
				}

				return result;
			});
		}

		// Helper method. Splits passed string up into given names and surname and returns Name object.
		private Name ParseName(string name)
		{
			if (!String.IsNullOrEmpty(name))
			{ 
				string[] splitName = name.Split(' ');

				// Determine last name
				string splitSurname = splitName[splitName.Length - 1];

				string splitGivenNames = "";
				// If string contains more than one word and thus has given names
				if (splitName.Length > 1)
				{
					// Add first given name
					splitGivenNames += splitName[0];

					// Has additional given names
					if (splitName.Length > 2)
					{
						for (int i = 1; i <= splitName.Length - 2; i++)
							splitGivenNames += " " + splitName[i];
					}					
				}			

				return new Name()
				{
					surname = splitSurname,
					givenNames = splitGivenNames
				};
			}

			return null;
		}
	}
}
