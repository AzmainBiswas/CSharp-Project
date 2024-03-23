class InputHandeling
{
    public static int MenuSelectionNumber(int lowerBound, int upperBound)
    {
        string? userInput;
        int menuSelection;
        bool conversionCheck;

        do
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Enter corrosponding valid number to your action: ");
            userInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            conversionCheck = int.TryParse(userInput, out menuSelection);
            if (!conversionCheck || menuSelection < lowerBound || menuSelection > upperBound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(userInput + " is not valid.");
                conversionCheck = false;
                Console.ForegroundColor = ConsoleColor.White;
            }
        } while (!conversionCheck);

        return menuSelection;
    }
}
