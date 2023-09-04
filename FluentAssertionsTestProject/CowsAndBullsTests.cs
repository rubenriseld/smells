using FluentAssertions;
using Xunit;
using smells.MockObjects;

namespace FluentAssertionsTestProject
{
	public class CowsAndBullsTests
	{
		string MockNumbersToGuess = "5278";

		MockCowsAndBullsData mockData;
		public CowsAndBullsTests()
		{
			mockData = new MockCowsAndBullsData(MockNumbersToGuess);
		}
		[Fact]
		public void UserGuess_5278_ShouldReturn_FourBulls()
		=> mockData.HandleUserGuess("5278").Should().Be("BBBB,");
		[Fact]
		public void UserGuess_5279_ShouldReturn_ThreeBulls()
		=> mockData.HandleUserGuess("5279").Should().Be("BBB,");
		[Fact]
		public void TwoBullsShouldReturn_BB()
			=> mockData.HandleUserGuess("0678").Should().Be("BB,");
		[Fact]
		public void FourCowsShouldReturnCCCC()
		=> mockData.HandleUserGuess("8725").Should().Be(",CCCC");
		[Fact]
		public void GeneratedNumbersShouldBeUnique()
		=> mockData.GenerateDuplicateNumbers().Should().BeFalse();
	}
}
