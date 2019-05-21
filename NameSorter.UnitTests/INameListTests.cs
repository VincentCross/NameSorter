using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.Controller;
using NameSorter.Model;
using System.Collections.Generic;

namespace NameSorter.UnitTests
{
	[TestClass]
	public class INameListTests
	{
		[TestMethod]
		public void Constructor_NoArgument_EmptyList()
		{
			// Arrange

			// Act
			INameList nameList = new NameList();

			// Assert
			Assert.IsTrue(nameList.GetAllNames().Count == 0);
		}

		[TestMethod]
		public void Constructor_StringArrayArgument_EmptyList()
		{
			// Arrange
			string[] nameArray = { "Name1", "Name2" };

			// Act
			INameList nameList = new NameList(nameArray);

			// Assert
			Assert.IsTrue(nameList.GetAllNames().Count == 2);
		}

		[TestMethod]
		public void AddName_OneWordString_NameAddedToList()
		{
			// Arrange
			INameList nameList = new NameList();
			string testName = "Muirgen";

			// Act
			nameList.AddName(testName);

			// Assert
			Assert.IsTrue(nameList.GetName(testName).givenNames == "");
			Assert.IsTrue(nameList.GetName(testName).surname == "Muirgen");
		}

		[TestMethod]
		public void AddName_TwoWordString_NameAddedToList()
		{
			// Arrange
			INameList nameList = new NameList();
			string testName = "Joseba Kruse";

			// Act
			nameList.AddName(testName);

			// Assert
			Assert.IsTrue(nameList.GetName(testName).givenNames == "Joseba");
			Assert.IsTrue(nameList.GetName(testName).surname == "Kruse");
		}

		[TestMethod]
		public void AddName_ThreeWordString_NameAddedToList()
		{
			// Arrange
			INameList nameList = new NameList();
			string testName = "Pyrrhos Jakov Wang";

			// Act
			nameList.AddName(testName);

			// Assert
			Assert.IsTrue(nameList.GetName(testName).givenNames == "Pyrrhos Jakov");
			Assert.IsTrue(nameList.GetName(testName).surname == "Wang");
		}

		[TestMethod]
		public void AddName_EmptyString_NoNameAddedToList()
		{
			// Arrange
			INameList nameList = new NameList();
			string testName = "";

			// Act
			nameList.AddName(testName);

			// Assert
			Assert.IsTrue(nameList.GetAllNames().Count == 0);
		}

		[TestMethod]
		public void AddName_NullString_NoNameAddedToList()
		{
			// Arrange
			INameList nameList = new NameList();
			string testName = null;

			// Act
			nameList.AddName(testName);

			// Assert
			Assert.IsTrue(nameList.GetAllNames().Count == 0);
		}

		
		[TestMethod]
		public void SortBySurname_NoDuplicateSurnamesAlreadySorted_SortedCorrectly()
		{
			// Arrange
			string[] nameArray = {
				"Order1 Andrews",
				"Order2 Johnson",
				"Order3 Miles",
				"Order4 Peerson",
				"Order5 Wender"
			};
			INameList nameList = new NameList(nameArray);

			// Act
			nameList.Sort();
			List<Name> result = nameList.GetAllNames();

			// Assert
			for (int i = 0; i < nameArray.Length; i++)
			{
				Assert.IsTrue(result[i].givenNames + " " + result[i].surname == nameArray[i]);
			}
		}

		[TestMethod]
		public void SortBySurname_NoDuplicateSurnamesNotSorted_SortedCorrectly()
		{
			// Arrange
			string[] nameArray = {
				"Order2 Johnson",
				"Order5 Wender",
				"Order3 Miles",
				"Order4 Peerson",
				"Order1 Andrews"
			};
			INameList nameList = new NameList(nameArray);

			// Act
			nameList.Sort();
			List<Name> result = nameList.GetAllNames();

			// Assert
			Assert.IsTrue(result[0].givenNames == "Order1");
			Assert.IsTrue(result[1].givenNames == "Order2");
			Assert.IsTrue(result[2].givenNames == "Order3");
			Assert.IsTrue(result[3].givenNames == "Order4");
			Assert.IsTrue(result[4].givenNames == "Order5");
		}

		[TestMethod]
		public void SortBySurname_DuplicateSurnames_SortedCorrectly()
		{
			// Arrange
			string[] nameArray = {
				"Order2 Johnson",
				"Order3 Miles",
				"Order5 Wender",
				"Order4 Wender",
				"Order1 Andrews"
			};
			INameList nameList = new NameList(nameArray);

			// Act
			nameList.Sort();
			List<Name> result = nameList.GetAllNames();

			// Assert
			Assert.IsTrue(result[0].givenNames == "Order1");
			Assert.IsTrue(result[1].givenNames == "Order2");
			Assert.IsTrue(result[2].givenNames == "Order3");
			Assert.IsTrue(result[3].givenNames == "Order4");
			Assert.IsTrue(result[4].givenNames == "Order5");
		}
	}
}
