class InputHandeling
{
    public static int MenuSelectionNumber(int lowerBound, int upperBound)
    {
        string? userInput;
        int menuSelection;
        bool conversionCheck;

        do
        {
            Console.Write("Enter corrosponding valid number to your action: ");
            userInput = Console.ReadLine();

            conversionCheck = int.TryParse(userInput, out menuSelection);
            if (!conversionCheck || menuSelection < lowerBound || menuSelection > upperBound)
            {
                Console.WriteLine(userInput + " is not valid.");
                conversionCheck = false;
            }
        } while (!conversionCheck);

        return menuSelection;
    }
}
