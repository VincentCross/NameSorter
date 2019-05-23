using NameSorter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NameSorter.Controller
{
	public class FileController : IFileController
	{
		AppFile _currentFile;

		//
		// Constructors
		//

		public FileController(AppFile file)
		{
			_currentFile = file;
		}

		public FileController(string filePath)
		{
			_currentFile = new AppFile(filePath);
		}

		//
		// Methods
		//

		// Reads the entire file into a string array
		public string[] Read()
		{
			try
			{
				if (!File.Exists(_currentFile.filePath))
					throw new FileNotFoundException();

				return File.ReadAllLines(_currentFile.filePath);
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR: " + e.Message);
			}

			return null;
		}

		// Writes all the lines to a new/overwritten file
		public void Write(string[] stream)
		{
			if (stream == null || stream.Length <= 0 || String.IsNullOrEmpty(stream[0]))
			{
				return;
			}
			else
			{
				try
				{
					File.WriteAllLines(_currentFile.filePath, stream);
				}
				catch (Exception e)
				{
					Console.WriteLine("ERROR: " + e.Message);
				}
			}
		}
	}
}
