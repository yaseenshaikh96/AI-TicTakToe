public static class Utility
{
    public static int GetInput(string inputMsg)
    {
        string? input;
        int output = 0;
        bool success = false;

        System.Console.Write("\n" + inputMsg);

        while (success == false)
        {
            input = System.Console.ReadLine();
            success = System.Int32.TryParse(input, out output);
            if (success == true)
                break;
            System.Console.Write("\nPlease Enter Valid Integer!");
            System.Console.Write("\n" + inputMsg);
        }
        return output;
    }

    public static void Pause()
    {
        System.Console.Write("\nPress any key to continue...");
        System.Console.ReadKey();
    }

    public static void DisplayError(string err)
    {
        System.Console.Write("\n" + err);
    }

    public static int GetInputInRange(
        int minInc, int maxInc,
        string prompt, string err)
    {
        int output;
        while (true)
        {
            output = Utility.GetInput(prompt);

            if (output <= maxInc && output >= minInc)
                break;
            Utility.DisplayError(err);
        }
        return output;
    }
}