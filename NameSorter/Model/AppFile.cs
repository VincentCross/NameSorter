using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NameSorter.Model
{
	public class AppFile
	{
		public string fileName { get; set; }
		public string dirPath { get; set; }
		public string filePath { get; set; }

		public AppFile()
		{

		}

		public AppFile(string filePath)
		{
			this.filePath = filePath;
			fileName = Path.GetFileName(filePath);
			dirPath = Path.GetDirectoryName(filePath);			
		}
	}
}
