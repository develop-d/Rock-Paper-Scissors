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
        public readonly static string P1Name = "PC";
        private readonly static string P2Name = "HUMAN";
        private readonly static Game g = new(new Player(P1Name), new Player(P2Name));

        static void Main(string[] args)
        {
            

            bool show = true;
            while (show)
            {
                show = AppMenu();
            }            
        }

        private static bool AppMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) 3 round game with built-in game reporting messages");
            Console.WriteLine("2) 3 round game with own game reporting messages");
            Console.WriteLine("3) Game with zeroing score and exit capability, with own defined hand sign rules");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Game1();
                    return true;
                case "2":
                    Game2();
                    return true;
                case "3":
                    Game3();
                    return true;
                case "4":                    
                    return false;
                default:
                    return true;
            }
        }

        private static void ContinueToMenu()
        {
            // Reset game score to start over
            g.ZeroGameScore();
            Console.WriteLine("Press any key to continue to Menu");
            Console.ReadLine();
        }

        

        private static void Game1()
        {
            /*
             * GAME - 1
             * 3 round game with built-in game reporting messages
             */
            Console.WriteLine("GAME - 1\nEnter any word starting R/S/P for Rock, Paper, Scissors hand sign.\nFixed 3 rounds game.\n");
            int counter = 3;
            while (counter > 0)
            {
                g.SetPlayerHandTo(P2Name, Helpers.ProcessUserInput(P2Name));
                g.SetPlayerHandRandomly(P1Name);
                g.ReportPlayerMove(P1Name);
                g.ReportPlayerMove(P2Name);
                g.ToJudge();
                g.ReportWinner();
                g.ReportScore();
                Console.WriteLine();
                counter--;
            }
            ContinueToMenu();
        }

        private static void Game2()
        {
            /*
             * GAME - 2
             * 3 round game with own game reporting messages
             */
            Console.WriteLine("GAME - 2\nEnter any word starting R/S/P for Rock, Paper, Scissors hand sign.\nFixed 3 rounds game.\n");
            int counter = 3;
            while (counter > 0)
            {
                g.SetPlayerHandRandomly(P1Name);
                g.SetPlayerHandTo(P2Name, Helpers.ProcessUserInput(P2Name));
                //Report Player1 move
                Console.WriteLine($"Player {P1Name} move: {g.GetPlayerByName(P1Name).GetCurrentHandSign()}");
                //Report Player1 move
                Console.WriteLine($"Player {P2Name} move: {g.GetPlayerByName(P2Name).GetCurrentHandSign()}");
                g.ToJudge();
                // Report Winner
                Console.WriteLine(g.GetLastGameWinner() != null ? $"Winner: {g.GetLastGameWinner().Name}" : "No winner, TIE");
                // Report Game Score
                Console.WriteLine($"Score P1:P2: {g.GetPlayerScore(P1Name)}:{g.GetPlayerScore(P2Name)}");

                Console.WriteLine();
                counter--;
            }
            ContinueToMenu();
        }

        private static void Game3()
        {
            /*
             * GAME - 3
             * Game with zeroing score and exit capability
             * Game with own valid hand signs
             */
            Console.WriteLine("GAME - 3");
            Console.WriteLine("Type ZERO to reset win score to 0:0");
            Console.WriteLine("Type EXIT to exit the game");
            Console.WriteLine("Type PI/PA/CI for game valid hand sign moves Rock/Paper/Scissors");

            while (true)
            {
                // first player will get random hand sign
                g.SetPlayerHandRandomly(P1Name);
                // user input message
                Console.Write($"{P2Name}, your move: ");
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
                            return;
                        default:
                            Console.WriteLine(" - Not recognised entry - ");
                            continue;
                    }
                }
                else
                {
                    //otherwise second player will get hand sign from console read
                    g.SetPlayerHandTo(P2Name, userValidGameInput);
                    //report players moves
                    g.ReportPlayerMove(P1Name);
                    g.ReportPlayerMove(P2Name);
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
