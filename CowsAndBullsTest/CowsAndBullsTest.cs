using FluentAssertions;
using smells;
using smells.MockObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class CowsAndBullsTest
	{
		MockCowsAndBullsData mockData= new MockCowsAndBullsData();
		[Fact]
		public void ThreeCorrectNumbersShouldEqualBBBcomma()
		=> mockData.HandleUserGuess("5279").Should().Be("BBB,");

		[Fact]
		public void RightNumbersWrongPlaceShouldReturnCommaCCC()
		=> mockData.HandleUserGuess("8725").Should().Be(",CCCC");

		[Fact]
		public void NumberOfGuessesShouldIncrease()
		{

		}
		[Fact]
		public void FaultyNumbers5537ShouldBe5637()
		=> mockData.GenerateNumbersToGuess().Should().Be("5637");
	}
}
