public class Game
{
    private static Game? instance;
    private static readonly char[] symbols = { 'x', 'o', 'a', 'b' };
    public int numOfPlayer { get; private set; }
    public Player[] players;
    public readonly int MAX_TURNS;
    public int currentTurn;
    public readonly int boardSize;

    //---------------------------------------------//

    public static Game GetInstance(int numOfPlayer)
    {
        if (instance == null)
            instance = new Game(numOfPlayer);
        return instance;
    }

    private Game(int numOfPlayer)
    {
        this.numOfPlayer = numOfPlayer;
        this.players = new Player[this.numOfPlayer];
        for (int i = 0; i < numOfPlayer; i++)
            this.players[i] = new Player(symbols[i]);

        this.boardSize = numOfPlayer + 1;
        this.MAX_TURNS = boardSize * boardSize;
        this.currentTurn = 0;
    }

    //-------------------------------------------------//

    public bool IsOver()
    {
        return currentTurn > 9;
    }
}