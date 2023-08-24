using FluentAssertions;
using smells;
using smells.MockObjects;

namespace CowsAndBullsTest
{
	public class PLayerDataTest
	{
		MockPlayerData mockPlayerData= new MockPlayerData();
		[Fact]
		public void AverageOf5Times3Is5()
		=> mockPlayerData.Average().Should().Be(5.00);
		[Fact]
		public void UpdateNumberOfGuessesShouldBe17()
			=> mockPlayerData.UpdateGuesses(2).Should().Be(17);
		[Fact]
		public void UpdateNumberOfGamesPlayedShouldBe4()
			=> mockPlayerData.UpdateNumberOfGames().Should().Be(4);
	}
}