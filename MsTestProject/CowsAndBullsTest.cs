using Microsoft.VisualStudio.TestTools.UnitTesting;
using smells.MockObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTestProject
{
	[TestClass]
	public class CowsAndBullsTest
	{
		string MockNumberToGuess { get; set; }
		MockCowsAndBullsData MockData { get; set; }

		[TestInitialize]
		public void InitializeMasterMindTest()
		{
			MockNumberToGuess= "5278";
			MockData = new MockCowsAndBullsData(MockNumberToGuess);
		}
		[TestMethod]
		public void UserGuess_5278_ShouldReturn_FourBulls()
		{
			Assert.AreEqual("BBBB,", MockData.HandleUserGuess("5278"));		
		}
		[TestMethod]
		public void UserGuess_5279_ShouldReturn_ThreeBulls()
		{
			Assert.AreEqual("BBB,", MockData.HandleUserGuess("5279"));
		}
		[TestMethod]
		public void UserGuess_0678_ShouldReturn_TwoBulls()
		{
			Assert.AreEqual("BB,", MockData.HandleUserGuess("0678"));
		}
		[TestMethod]
		public void UserGuess_8725_ShouldReturn_FourCows()
		{
			Assert.AreEqual(",CCCC", MockData.HandleUserGuess("8725"));
		}
		[TestMethod]
		public void GeneratedNumbersShouldNotHaveDuplicateValues()
		{ 
			Assert.IsFalse(MockData.GenerateDuplicateNumbers());
		}
	
}
}
