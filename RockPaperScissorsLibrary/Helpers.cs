using System;

namespace RockPaperScissorsLibrary
{
    public static class Helpers
    {
        /// <summary>
        /// Repeat to read input from console until valid game input for hand sign is given
        /// </summary>
        /// <param name="playerName">Player name</param>
        /// <returns>Internal representation of hand sign</returns>
        public static HandSign ProcessUserInput(string playerName)
        {            
            Console.Write($"{playerName}, your move: ");
            var vInput = Helpers.CheckValidGameInput(Console.ReadLine());
            while (vInput == HandSign.NotDefined)
            {
                Console.Write($"Invalid entry, repeat your move: ");
                vInput = Helpers.CheckValidGameInput(Console.ReadLine());
            }
            return vInput;
        }

        /// <summary>
        /// Validate the user input Rock, Paper, Scissors
        /// </summary>
        /// <remarks>
        /// Rock is any string starting "r" or "R".
        /// Paper is any string starting "p" or "P".
        /// Scissors is any string starting "s" or "S".
        /// If the input is not valid, HandSign.NotDefined is returned
        /// </remarks>
        /// <param name="gameInput">User input to validate</param>
        /// <returns>Internal representation of hand sign</returns>
        private static HandSign CheckValidGameInput(string gameInput)
        {
            // store uppercase of input
            var cmp = gameInput.ToUpper();
            // according to input return corresponding internal expression of hand sign
            return cmp switch
            {
                string st when st.ToUpper().StartsWith("R") => HandSign.Rock,
                string st when st.ToUpper().StartsWith("P") => HandSign.Paper,
                string st when st.ToUpper().StartsWith("S") => HandSign.Scissors,
                _ => HandSign.NotDefined,
            };
        }

        /// <summary>
        /// Validate the user input according to provided named strings for rock, paper and scissors.
        /// </summary>
        /// <remarks>e.g. for Fance you can pass (rock: "PI", paper: "PA", scissors: "CI")</remarks>
        /// <param name="gameInput">String to validate/param>
        /// <param name="signs">Valid strings for rock, paper, scissors</param>
        /// <returns>Internal representation of hand sign</returns>
        public static HandSign CheckValidGameInput(string gameInput, (string rock, string paper, string scissors) signs)
        {
            // store uppercase of input
            var cmp = gameInput.ToUpper();
            // according to input and provided named strings of valid inputs for rock, paper, scissors
            // return corresponding internal expression of hand sign
            return cmp switch
            {
                string when cmp.CompareTo(signs.rock) == 0 => HandSign.Rock,
                string when cmp.CompareTo(signs.paper) == 0 => HandSign.Paper,
                string when cmp.CompareTo(signs.scissors) == 0 => HandSign.Scissors,
                _ => HandSign.NotDefined,
            };
        }
    }
}
