using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RockPaperScissorsLibrary.Tests
{
    public class GameTests
    {

        Player p1 = new("Player1");
        Player p2 = new("Player2");

        [Fact]
        public void GetPlayerByName_CorrectPlayerReturnedViaItsName()
        {
            //Arrange
            Game g = new(p1, p2);
            var playerName = "Player1";
            var expected = p1;
            //Act
            var actual = g.GetPlayerByName(playerName);
            //Arrange
            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void ZeroGameScore_GaneScoreHasToBeZeroedForBothPlayers()
        {
            // Arrange
            Game g = new(p1, p2);
            p1.Score = 2;
            p1.Score = 6;
            //Act
            g.ZeroGameScore();
            //Assert
            Assert.Equal(0, p1.Score); 
            Assert.Equal(p1.Score, p2.Score);
        }

        [Theory]
        [InlineData(HandSign.Rock, HandSign.Paper)]
        [InlineData(HandSign.Paper, HandSign.Scissors)]
        [InlineData(HandSign.Scissors, HandSign.Rock)]
        public void Compare_Player2Win(HandSign sign1, HandSign sign2 )
        {
            //Arrange
            Game g = new(p1, p2);
            p1.ShakeHandToHandSign(sign1);
            p2.ShakeHandToHandSign(sign2);
            //Act
            var actual = g.Compare();
            //Assert
            Assert.Equal(1, actual);
        }

        [Theory]
        [InlineData(HandSign.Paper, HandSign.Rock)]
        [InlineData(HandSign.Scissors, HandSign.Paper)]
        [InlineData(HandSign.Rock, HandSign.Scissors)]
        public void Compare_Player2Loose(HandSign sign1, HandSign sign2)
        {
            //Arrange
            Game g = new(p1, p2);
            p1.ShakeHandToHandSign(sign1);
            p2.ShakeHandToHandSign(sign2);
            //Act
            var actual = g.Compare();
            //Assert
            Assert.Equal(-1, actual);
        }


        [Theory]
        [InlineData(HandSign.Paper, HandSign.Paper)]
        [InlineData(HandSign.Scissors, HandSign.Scissors)]
        [InlineData(HandSign.Rock, HandSign.Rock)]
        public void Compare_PlayersTie(HandSign sign1, HandSign sign2)
        {
            //Arrange
            Game g = new(p1, p2);
            p1.ShakeHandToHandSign(sign1);
            p2.ShakeHandToHandSign(sign2);
            //Act
            var actual = g.Compare();
            //Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void ToJudge_Player2ReturnedIfPlaer2Win()
        {
            //Arrange
            Game g = new(p1, p2);
            p1.ShakeHandToHandSign(HandSign.Rock);
            p2.ShakeHandToHandSign(HandSign.Paper);
            //Act
            var actual = g.ToJudge();
            //Assert
            Assert.True(p2.Equals(actual));
        }

        [Fact]
        public void ToJudge_Player1ReturnedIfPlaer2Loose()
        {
            //Arrange
            Game g = new(p1, p2);
            p1.ShakeHandToHandSign(HandSign.Paper);
            p2.ShakeHandToHandSign(HandSign.Rock);
            //Act
            var actual = g.ToJudge();
            //Assert
            Assert.True(p1.Equals(actual));
        }

        [Fact]
        public void ToJudge_NullReturnedIfTie()
        {
            //Arrange
            Game g = new(p1, p2);
            p1.ShakeHandToHandSign(HandSign.Paper);
            p2.ShakeHandToHandSign(HandSign.Paper);
            //Act
            var actual = g.ToJudge();
            //Assert
            Assert.Null(actual);
        }
    }
}
