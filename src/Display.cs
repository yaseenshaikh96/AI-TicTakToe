public class Display
{
    Game gameInstance;

    public Display(Game gameInstance)
    {
        this.gameInstance = gameInstance;
    }

    public static void TitleScreen()
    {
        Clear();
        System.Console.Write(
            "Welcome To\n" +
            "   TIC-TAK-TOE\n" +
            "by Yaseen"
        );
    }

    public void GameScreen()
    {
        System.Console.Clear();
        System.Console.Write(
            "# of Players: " + gameInstance.numOfPlayer + "\n" +
            "Turns: " + gameInstance.currentTurn + "/" + gameInstance.MAX_TURNS + "\n" +
            "Current Player: " + gameInstance.currentPlayer.symbol
        );

        NewLine();
        DisplayBoard();

    }

    public void GameOver()
    {
        Clear();
        DisplayBoard();
        if (gameInstance.winner == null)
            System.Console.Write("\nIt is a draw!");
        else
            System.Console.Write("\nWinner: " + gameInstance.winner.symbol);

        Utility.Pause();

    }

    private void DisplayBoard()
    {
        for (int i = 0; i < gameInstance.boardSize; i++)
        {
            PlusLine();
            NewLine();
            SpaceLine(i);
            NewLine();
        }
        PlusLine();
    }

    //--------------------------------------------------//

    public static void Clear()
    {
        System.Console.Clear();
    }

    private void PlusLine()
    {
        for (int i = 0; i < gameInstance.boardSize; i++)
            System.Console.Write("+--");
        System.Console.Write("+");
    }

    private void SpaceLine(int row)
    {
        for (int i = 0; i < gameInstance.boardSize; i++)
            System.Console.Write("|{0} ", gameInstance.board[row, i]);
        System.Console.Write("|");
    }

    private void NewLine()
    {
        System.Console.Write('\n');
    }
}