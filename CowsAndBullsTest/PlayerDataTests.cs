using FluentAssertions;
using smells;

namespace CowsAndBullsTest
{
	public class PLayerDataTest
	{
		MockPlayerData mockPlayerData= new MockPlayerData();
		[Fact]
		public void AvarageOf5Times3Is5()
		=> mockPlayerData.Avarage().Should().Be(5.00);
		[Fact]
		public void UpdateNumberOfGuessesShouldBe17()
			=> mockPlayerData.UpdateGuesses(2).Should().Be(17);
		[Fact]
		public void UpdateNumberOfGamesPlayedShouldBe4()
			=> mockPlayerData.UpdateNumberOfGames().Should().Be(4);
	}
}