using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.Controller;
using NameSorter.Model;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.UnitTests
{
	[TestClass]
	public class IFileControllerTests
	{
		[TestMethod]
		public void Read_ValidFile_ReadsCorrectly()
		{
			// Arrange
			string[] testContents = { "Contents1", "Contents2" };
			File.WriteAllLines("./TestFile.txt", testContents);
			IFileController fc = new FileController("./TestFile.txt");

			// Act
			string[] contents = fc.Read();

			// Assert
			Assert.IsTrue(contents[0] == "Contents1");
			Assert.IsTrue(contents[1] == "Contents2");

			File.Delete("./TestFile.txt");
		}

		[TestMethod]
		public void Read_InvalidFile_ReadsNothing()
		{
			// Arrange
			if (File.Exists("./TestFile.txt"))
				File.Delete("./TestFile.txt");
			IFileController fc = new FileController("./TestFile.txt");

			// Act
			string[] contents = fc.Read();

			// Assert
			Assert.IsTrue(contents == null);

			// Should also be throwing an error message to the console.
		}

		[TestMethod]
		public void Write_ValidTextNoExistingFile_NewFileWrittenCorrectly()
		{
			// Arrange
			string[] testContents = { "Contents1", "Contents2" };
			if (File.Exists("./TestFile.txt"))
				File.Delete("./TestFile.txt");
			IFileController fc = new FileController("./TestFile.txt");

			// Act
			fc.Write(testContents);
			string[] readContents = fc.Read();

			// Assert
			Assert.IsTrue(File.Exists("./TestFile.txt"));
			Assert.IsTrue(readContents[0] == "Contents1");
			Assert.IsTrue(readContents[1] == "Contents2");

			File.Delete("./TestFile.txt");
		}

		[TestMethod]
		public void Write_ValidTextExistingFile_FileOverwrittenCorrectly()
		{
			// Arrange
			if (File.Exists("./TestFile.txt"))
				File.Delete("./TestFile.txt");
			string[] oldContents = { "OldContents1", "OldContents2" };
			string[] newContents = { "NewContents1", "NewContents2" };
			File.WriteAllLines("./TestFile.txt", oldContents);
			IFileController fc = new FileController("./TestFile.txt");

			// Act
			fc.Write(newContents);
			string[] readContents = fc.Read();

			// Assert
			Assert.IsTrue(readContents[0] == "NewContents1");
			Assert.IsTrue(readContents[1] == "NewContents2");

			File.Delete("./TestFile.txt");
		}

		[TestMethod]
		public void Write_NullText_FileNotOverwritten()
		{
			// Arrange
			if (File.Exists("./TestFile.txt"))
				File.Delete("./TestFile.txt");
			string[] oldContents = { "OldContents1", "OldContents2" };
			string[] newContents1 = null;
			string[] newContents2 = { "" };
			File.WriteAllLines("./TestFile.txt", oldContents);
			IFileController fc = new FileController("./TestFile.txt");

			// Act
			fc.Write(newContents1);
			fc.Write(newContents2);
			string[] readContents = fc.Read();

			// Assert
			Assert.IsTrue(readContents[0] == "OldContents1");
			Assert.IsTrue(readContents[1] == "OldContents2");

			File.Delete("./TestFile.txt");
		}

	}
}
