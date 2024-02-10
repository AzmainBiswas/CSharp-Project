namespace GuessTheNumber
{
    class LogicForGame
    {
        public static void MainGame()
        {
            int userGauss;
            Console.Write("Please a Number between 0 and 10: ");
            // if user give a string which is not convertable to int then validGauss would be alse.
            bool validGauss = int.TryParse(Console.ReadLine(), out userGauss);
            
            if (!validGauss)
            {
                Console.WriteLine("Please Enter a valid number netween 0 and 10.");
                return;
            }

            if (userGauss < 0 || userGauss > 10)
            {
                Console.WriteLine("Please Enter a number between 0 and 10.");
                return;
            }

            Console.WriteLine(userGauss);
        }
    }
}
