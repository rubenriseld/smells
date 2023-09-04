using Microsoft.VisualStudio.TestTools.UnitTesting;
using smells.MockObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smells.Data;

namespace MsTestProject
{
    [TestClass]
	public class PlayerDataTests
	{
		PlayerData mockPlayerData;
		[TestInitialize]
		public void InitializePlayerDataTests()
		{
			//Skapa player med totalt 3 spel och 15 score
			mockPlayerData = new PlayerData("TestUser", 3);
			mockPlayerData.AddToTotalScore(7);
			mockPlayerData.AddToTotalScore(5);
		}
		[TestMethod]
		public void Average_Of_15TotalScore_And_3TotalGames_ShouldBe_5()
		{
			Assert.AreEqual(5, mockPlayerData.GetAverageOfTotalScore());
		}
		[TestMethod]
		public void Increased_NumberOfGamesPlayed_Should_Return_4()
		{
			mockPlayerData.IncreaseNumberOfGamesByOne();
			Assert.AreEqual(4, mockPlayerData.TotalGamesPlayed);
		}
	}
}
