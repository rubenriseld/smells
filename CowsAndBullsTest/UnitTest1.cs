using FluentAssertions;
using smells;

namespace CowsAndBullsTest
{
	public class UnitTest1
	{
		[Fact]
		public void AvarageOf5Times3Is5()
		=> new PlayerData("", 15).Avarage().Should().Be(5.00);
	}
}