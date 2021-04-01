using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RockPaperScissorsLibrary.Tests")]
namespace RockPaperScissorsLibrary
{

    public class Game
    {
        private readonly List<Player> players;
        private Player lastRoundWinner;

        /// <summary>
        /// Create Rock, Paper, Scissors game by providing two player objects with their names.
        /// </summary>
        /// <param name="p1">New Player1 object with player Name parameter</param>
        /// <param name="p2">New Player2 object with player Name parameter</param>
        public Game(Player p1, Player p2)
        {
            players = new List<Player>
            {
                p1,
                p2
            };
        }

        /// <summary>
        /// Get Player object
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <returns>Player object referenced by its name</returns>
        public Player GetPlayerByName(string name)
        {         
            return players.Single<Player>(n => n.Name.CompareTo(name) == 0);
        }

        /// <summary>
        /// Set randomly player hand sign
        /// </summary>
        /// <param name="name">Name of the player</param>
        public void SetPlayerHandRandomly(string name)
        {
            GetPlayerByName(name).ShakeHandRandom();            
        }

        /// <summary>
        /// Set player hand sign
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="hs">Internal representation of hand sign</param>
        public void SetPlayerHandTo(string name, HandSign hs)
        {
            GetPlayerByName(name).ShakeHandToHandSign(hs);            
        }

        /// <summary>
        /// Reset zero game back to 0:0
        /// </summary>
        public void ZeroGameScore()
        {
            players.ElementAt(0).Score = 0;
            players.ElementAt(1).Score = 0;
        }

        /// <summary>
        /// Get Player who win the last round.
        /// </summary>
        /// <returns>The player object or null</returns>
        public Player GetLastGameWinner()
        {
            return lastRoundWinner;
        }

        /// <summary>
        /// Get player score
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <returns></returns>
        public int GetPlayerScore(string name)
        {            
            return GetPlayerByName(name).Score;
        }

        /// <summary>
        /// Report total score for Player1 : Player2
        /// </summary>
        public void ReportScore()
        {
            var pl1 = players.ElementAt(0);
            var pl2 = players.ElementAt(1);

            Console.WriteLine($"Total score {pl1.Name}: {pl1.Score} - {pl2.Name}: {pl2.Score}");
        }

        /// <summary>
        /// Print to the console Player name who win the last round or TIE if there is no winner.
        /// </summary>
        public void ReportWinner()
        {
            if (lastRoundWinner == null)
            {
                Console.WriteLine($"No winner: TIE ");
            }
            else
            {
                Console.WriteLine($"Winner name: {lastRoundWinner.Name} ");
            }
        }

        /// <summary>
        /// Internally store the player who last win.
        /// </summary>
        /// <param name="p">Player object</param>
        private void SetLastRoundWinner(Player p)
        {
            lastRoundWinner = p;
        }

        /// <summary>
        /// Rise up the score for the given player
        /// </summary>
        /// <param name="p">Player object</param>
        private void RiseUpPlayerScore(Player p)
        {
            GetPlayerByName(p.Name).Score++;                        
        }
        
        /// <summary>
        /// Determines the winner of the two players
        /// </summary>
        /// <remarks>Player score and last round winner are updated as well</remarks>
        /// <returns>Player object or null in case of tie</returns>
        public Player ToJudge()
        {
            var pl1 = players.ElementAt(0);
            var pl2 = players.ElementAt(1);

            int cmp = Compare();

            if (cmp == 0)
            {
                SetLastRoundWinner(null);
                return null;
            }
            else if (cmp < 0)
            {
                SetLastRoundWinner(pl1);               
                RiseUpPlayerScore(pl1);                
                return pl1;
            }
            else
            {
                SetLastRoundWinner(pl2);
                RiseUpPlayerScore(pl2);
                return pl2;
            }
        }

        /// <summary>
        /// Compares the hand sign of both players which has the bigger value
        /// </summary>
        /// <remarks>The bigger value is given by Rock, Paper Scissors game rules [R < P < S < R]</remarks>
        /// <returns>1 (Player2 has bigger value) 0 (Same value - Tie) -1 (Player2 has lower value)</returns>
        //  Internal for testing purposes
        internal int Compare()
        {
            var pl1 = players.ElementAt(0);
            var pl2 = players.ElementAt(1);

            if (pl1.GetCurrentHandSign() == HandSign.Rock && pl2.GetCurrentHandSign() == HandSign.Paper)
            {
                return 1;
            }
            else if (pl1.GetCurrentHandSign() == HandSign.Paper && pl2.GetCurrentHandSign() == HandSign.Rock)
            {
                return -1;
            }

            if (pl1.GetCurrentHandSign() < pl2.GetCurrentHandSign())
            {
                return 1;
            }
            else if (pl1.GetCurrentHandSign() > pl2.GetCurrentHandSign())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
