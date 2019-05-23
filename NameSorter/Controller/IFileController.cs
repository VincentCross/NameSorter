using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Controller
{
	public interface IFileController
	{
		void Write(string[] stream);
		string[] Read();
	}
}
