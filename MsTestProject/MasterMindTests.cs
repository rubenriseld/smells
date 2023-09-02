using smells.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestProject
{
    [TestClass]
    public class MasterMindTests
    {
        string MockNumberToGuess { get;set; }
        MockMasterMind MockMasterMind { get; set; }

        [TestInitialize]
        public void InitializeMasterMindTest()
        {
            MockNumberToGuess= "1122";
            MockMasterMind = new MockMasterMind(MockNumberToGuess);
        }

        [TestMethod]
        public void UserGuess_2112_ShouldBe_TwoAsterisks_And_TwoQuestionMarks()
        {
            string guessResult = MockMasterMind.HandleUserGuess("2112");
            Assert.AreEqual("**??", guessResult);
        }
        [TestMethod]
        public void UserGuess_1112_ShouldBe_ThreeAsterisks_And_ZeroQuestionMarks()
        {
            string guessResult = MockMasterMind.HandleUserGuess("1112");
            Assert.AreEqual("***", guessResult);
        }
        [TestMethod]
        public void UserGuess_1111_ShouldBe_TwoAsterisks_And_ZeroQuestionMarks()
        {
            string guessResult = MockMasterMind.HandleUserGuess("1111");
            Assert.AreEqual("**", guessResult);
        }
        [TestMethod]
        public void UserGuess_1345_ShouldBe_OneAsterisks_And_ZeroQuestionMarks()
        {
            string guessResult = MockMasterMind.HandleUserGuess("1345");
            Assert.AreEqual("*", guessResult);
        }
        [TestMethod]
        public void UserGuess_3435_ShouldBe_ZeroAsterisks_And_ZeroQuestionMarks()
        {
            string guessResult = MockMasterMind.HandleUserGuess("3435");
            Assert.AreEqual("", guessResult);
        }
    }
}