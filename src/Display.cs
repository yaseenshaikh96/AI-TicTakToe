public class Display
{
    Game gameInstance;

    public Display(Game gameInstance)
    {
        this.gameInstance = gameInstance;
    }

    public void TitleScreen()
    {
        System.Console.Clear();
        System.Console.Write(
            "Welcome To\n" +
            "   TIC-TAK-TOE\n" +
            "by Yaseen"
        );
    }

    public void DisplayConsole()
    {
        System.Console.Clear();

        for (int i = 0; i < gameInstance.boardSize; i++)
        {
            PlusLine();
            NewLine();
            SpaceLine();
            NewLine();
        }
        PlusLine();
    }

    //--------------------------------------------------//

    private void PlusLine()
    {
        for (int i = 0; i < gameInstance.boardSize; i++)
            System.Console.Write("+--");
        System.Console.Write("+");
    }

    private void SpaceLine()
    {
        for (int i = 0; i < gameInstance.boardSize; i++)
            System.Console.Write("|  ");
        System.Console.Write("|");
    }

    private void NewLine()
    {
        System.Console.Write('\n');
    }
}