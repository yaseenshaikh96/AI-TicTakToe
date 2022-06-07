class Program
{
    public static void Main()
    {
        int numOfPlayer = Utility.GetInput("Enter Num of Players: ");
        System.Console.Write("NumofPlayer: " + numOfPlayer);

        Game game = Game.GetInstance(numOfPlayer);
        Display display = new Display(game);

        display.TitleScreen();

        while (game.IsOver() == false)
        {

            display.DisplayConsole();
            game.currentTurn++;
        }
    }
}