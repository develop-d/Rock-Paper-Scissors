using RockPaperScissorsLibrary;
using System;

namespace RockPapeScissors
{
        
    /// <summary>
    /// Classic Rock, Paper, Scissors Game written in C#
    /// - Engine library
    /// - Engine library unit tests
    /// - Separated Program project with examples how to use the library
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            string P1Name = "PC";
            string P2Name = "HUMAN";

            Game g = new (new Player(P1Name), new Player(P2Name));

            /*
             * GAME - 1
             * 3 games with built-in reporting methods
             */
            Console.WriteLine("GAME - 1");
            int counter = 3;
            while (counter > 0)
            {
                g.SetPlayerHandRandomly(P1Name);
                g.SetPlayerHandTo(P2Name, Helpers.ProcessUserInput(P2Name));
                g.ToJudge();
                g.ReportWinner();
                g.ReportScore();
                
                Console.WriteLine();
                counter--;
            }
            // Reset game score to start over
            g.ZeroGameScore();

            /*
             * GAME - 2
             * 3 games with own reporting
             */
            Console.WriteLine("GAME - 2");
            counter = 3;
            while (counter > 0)
            {
                g.SetPlayerHandRandomly(P1Name);
                g.SetPlayerHandTo(P2Name, Helpers.ProcessUserInput(P2Name));
                g.ToJudge();
                Console.WriteLine(g.GetLastGameWinner() != null ? $"Winner: {g.GetLastGameWinner()}" : "No winner, TIE");
                Console.WriteLine($"Score P1:P2: {g.GetPlayerScore(P1Name)}:{g.GetPlayerScore(P2Name)}");
                
                Console.WriteLine();
                counter--;
            }
            // Reset game score to start over
            g.ZeroGameScore();

            /*
             * GAME - 3
             * Game with zeroing score and exit capability
             * Game with own valid hand signs
             */
            Console.WriteLine("GAME - 3");
            Console.WriteLine("Type ZERO to reset win score to 0:0, type EXIT to exit game");
            Console.WriteLine("Type Pierre papier ciseaux as PI/PA/CI for game valid hand sign moves");

            while (true)
            {
                // first player will get random hand sign
                g.SetPlayerHandRandomly(P1Name);
                // let second player geit input from console read
                var userInput = Console.ReadLine();
                // set the valid hand signs for rock, paper and scissors
                var userValidGameInput = Helpers.CheckValidGameInput(userInput, (rock: "PI", paper: "PA", scissors: "CI"));
                // if second player did not enter valid hand sign
                if (userValidGameInput == HandSign.NotDefined)
                {
                    //check if zero or exit has been enterred
                    switch (userInput.ToString().ToUpper())
                    {
                        case "ZERO":
                            g.ZeroGameScore();
                            g.ReportScore();
                            continue;                            
                        case "EXIT":                                                        
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine(" - Not recognised entry - ");
                            continue;                            
                    }
                }
                else
                {
                    //otherwise second player will get hand sign from console read
                    g.SetPlayerHandTo(P2Name, userValidGameInput);
                }
                // compare move of first and second player
                g.ToJudge();
                // report the winner
                g.ReportWinner();
                // report the game score
                g.ReportScore();

                Console.WriteLine();
            }
        }
    }
}
