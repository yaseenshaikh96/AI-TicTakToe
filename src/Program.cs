class Program
{
    public static void Main()
    {

        Display.TitleScreen();
        Utility.Pause();
        Display.Clear();

        int numOfPlayer = Utility.GetInputInRange(
            2, Game.MAX_NUM_PLAYER,
            "Enter Num of Players: ",
            "# of Players must be between 2 and 4!");

        Game game = Game.GetInstance(numOfPlayer);
        Display display = new Display(game);

        while (!game.IsOver())
        {
            display.GameScreen();

            int play = Utility.GetInputInRange(
                0, game.MAX_TURNS,
                "Enter Play: ",
                "Enter Valid board Index");
            // int play = Utility.GetInput("Enter Play: ");

            bool playSuccess = game.Play(play);

            if (game.CheckWin())
            {
                game.winner = game.currentPlayer;
                break;
            }
            if (playSuccess)
                game.IncrementTurn();
        }

        display.GameOver();
        Utility.Pause();
    }
}