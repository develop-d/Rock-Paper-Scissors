using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RockPaperScissorsLibrary.Tests
{
    public class PlayerTest
    {
        [Fact]        
        public void ShakeHandToHandSign_SignHasToBeStored()
        {
            //ARRANGE
            Player pl = new Player("Player1");
            var expected = HandSign.Rock;

            //ACT
            pl.ShakeHandToHandSign(HandSign.Rock);

            //ASSERT
            Assert.Equal(expected, pl.GetCurrentHandSign());
        }

        [Fact]
        public void ShakeHandRandom_100generatedCyclesHasToBeInRange1to3()
        {
            //ARRANGE
            Player pl = new("Player1");

            for (int i = 0; i < 100; i++)
            {
                //ACT
                pl.ShakeHandRandom();
                var actual = (int)pl.GetCurrentHandSign();
                //ASSERT
                Assert.InRange(actual, 1, 3);
            }
            
            
        }

    }
}
