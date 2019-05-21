using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Model
{
	public class Name
	{
		public string givenNames { get; set; }
		public string surname { get; set; }

		public override string ToString()
		{
			return givenNames + " " + surname;
		}
	}
}
