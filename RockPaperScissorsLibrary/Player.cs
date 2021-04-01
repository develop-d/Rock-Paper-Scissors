using System;

namespace RockPaperScissorsLibrary
{
    /// <summary>
    /// Player object with the Name, Score and HandSign
    /// </summary>
    public class Player
    {

        public string Name { get; set; }
        public int Score { get; set; }

        private HandSign handSign;

        private HandSign CurrentHand
        {
            get { return handSign; }
            set { handSign = value; }
        }

        /// <summary>
        /// Instantiate a new Player with given name
        /// </summary>
        /// <param name="name">Name of the player</param>
        public Player(string name)
        {
            Name = name;
            Score = 0;
            CurrentHand = HandSign.NotDefined;
        }

        /// <summary>
        /// Set the hand sign
        /// </summary>
        /// <param name="hs">Internal representation of hand sign</param>
        public void ShakeHandToHandSign(HandSign hs)
        {            
            CurrentHand = hs;            
        }

        /// <summary>
        /// Set the hand sign by generating randomly
        /// </summary>
        public void ShakeHandRandom()
        {
            CurrentHand = (HandSign)new Random().Next(1, 4);
        }

        /// <summary>
        /// Return current hand sign
        /// </summary>
        /// <returns>Internal representation of hand sign</returns>
        public HandSign GetCurrentHandSign()
        {
            return CurrentHand;
        }

        /// <summary>
        /// Override default object ToString() behaviour
        /// </summary>
        /// <returns>The player's name and current player's score and hand sign</returns>
        public override string ToString()
        {
            return $"Player name: {Name}, current score: {Score}, current hand sign: {CurrentHand}";
        }
    }

    public enum HandSign
    {
        Rock = 3,
        Scissors = 2,
        Paper = 1,
        NotDefined = 0
    }
}
