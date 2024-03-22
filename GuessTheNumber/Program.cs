namespace GuessTheNumber
{
    class Program
    {
        public static void Main()
        {
            bool replay = true;
            string replayAns = string.Empty;

            Console.WriteLine();
            Console.Title = "Guess The Number Game";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"------------ Guess The Number --------------");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello 󰙊  Welcome To The Game.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Game Rules:");

            Console.WriteLine("You have to guess a number between 0 and 10.\nYou have only 4 chance to guess the right number.");
            Console.WriteLine("Game Points: 100, 90, 80, 70\naccording to your number guesses.");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            // main game
            while (replay)
            {
                bool game = LogicForGame.MainGame();
                if (game)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Winner Winner!!!");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Looser!!!!");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Do you want to play again? (y/n): ");
                replayAns = Console.ReadLine()!;
                
                // By using the ! after Console.ReadLine()
                // you are essentially telling the compiler that you are sure the result will not be null.
                if (replayAns != "y")
                    replay = false;
                
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}
