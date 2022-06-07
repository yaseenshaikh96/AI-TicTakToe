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
}