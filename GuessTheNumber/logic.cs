namespace GuessTheNumber
{
    class LogicForGame
    {
        public static int UserInput()
        {
            while (true)
            {
                int userGauss;

                Console.Write("Please choose a Number between 0 and 10: ");
                // if user give a string which is not convertable to int then validGauss would be alse.
                bool validGauss = int.TryParse(Console.ReadLine(), out userGauss);

                if (validGauss)
                {
                    if (userGauss >= 0 && userGauss <= 10)
                        return userGauss;
                }
            }

        }


        public static bool MainGame()
        {
            int userGauss;
            int totalNumberOfGauss = 4;
            int currentNumberOfGause = 1;
            Random random = new Random();
            int randomNumber = random.Next(0, 11);

            userGauss = UserInput();

            Console.WriteLine("You have choosen {0}", userGauss);
            Console.WriteLine();
            while (currentNumberOfGause <= totalNumberOfGauss)
            {
                if (userGauss == randomNumber)
                {
                    int score = 100 - (currentNumberOfGause - 1) * 10;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Congrads Your Gauss is right 󱁖 ");
                    Console.WriteLine("Youur score is " + score);
                    Console.WriteLine();
                    Console.ResetColor();
                    return true;
                }
                else if (userGauss < randomNumber)
                {
                    Console.WriteLine("Wrong!!\nYou have to choose higher.");
                    if (currentNumberOfGause != totalNumberOfGauss)
                        userGauss = UserInput();
                    else
                        Console.WriteLine($"The number is {randomNumber}");
                    currentNumberOfGause++;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Wrong!!!\nYou have to choose lower.");
                    if (currentNumberOfGause != totalNumberOfGauss)
                        userGauss = UserInput();
                    else
                        Console.WriteLine($"The number is {randomNumber}");
                    currentNumberOfGause++;
                    Console.WriteLine();
                }
            }

            return false;
        }
    }
}
