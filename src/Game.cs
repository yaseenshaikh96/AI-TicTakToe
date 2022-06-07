public class Game
{
    public const int MAX_NUM_PLAYER = 4;
    private static Game? instance;
    private static readonly char[] symbols = { 'x', 'o', 'a', 'b' };
    public int numOfPlayer { get; private set; }
    public Player[] players;
    private int currentPlayerIndex;
    public Player currentPlayer;
    public readonly int MAX_TURNS;
    public int currentTurn;
    public readonly int boardSize;
    public char[,] board { get; private set; }
    public Player? winner;

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
        this.boardSize = numOfPlayer + 1;
        this.board = new char[boardSize, boardSize];
        for (int i = 0; i < boardSize; i++)
            for (int j = 0; j < boardSize; j++)
                this.board[i, j] = ' ';//(char)((i * boardSize + j) + 65);

        this.players = new Player[this.numOfPlayer];
        for (int i = 0; i < numOfPlayer; i++)
            this.players[i] = new Player(symbols[i]);
        this.currentPlayerIndex = 0;
        this.currentPlayer = players[this.currentPlayerIndex];

        this.MAX_TURNS = boardSize * boardSize - 1;
        this.currentTurn = 0;
    }

    //----------------------------------------------------//

    public bool Play(int play)
    {
        int x = play / boardSize;
        int y = play % boardSize;

        if (board[x, y] != ' ')
        {
            Utility.DisplayError("That space is already taken!");
            Utility.Pause();
            return false;
        }

        board[x, y] = currentPlayer.symbol;
        return true;
    }

    public void IncrementTurn()
    {
        currentTurn++;
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        currentPlayer = players[currentPlayerIndex];
    }

    public bool CheckWin()
    {
        int matchSize = boardSize;

        //rows
        for (int row = 0; row < boardSize; row++)
        {
            int flag = 0;
            for (int col = 0; col < boardSize; col++)
            {
                if (board[row, col] == currentPlayer.symbol)
                    flag++;
            }
            if (flag == matchSize)
                return true;
        }

        //col
        for (int col = 0; col < boardSize; col++)
        {
            int flag = 0;
            for (int row = 0; row < boardSize; row++)
            {
                if (board[row, col] == currentPlayer.symbol)
                    flag++;
            }
            if (flag == matchSize)
                return true;
        }

        //dia
        int diaFlag = 0;
        for (int i = 0; i < matchSize; i++)
        {
            if (board[i, i] == currentPlayer.symbol)
                diaFlag++;
        }
        if (diaFlag == matchSize)
            return true;

        diaFlag = 0;
        int diaRow = matchSize - 1;
        int diaCol = 0;
        for (int i = 0; i < matchSize; i++)
        {
            if (board[diaRow, diaCol] == currentPlayer.symbol)
                diaFlag++;
            diaRow--;
            diaCol++;
        }
        if (diaFlag == matchSize)
            return true;

        return false;
    }

    //-------------------------------------------------//

    public bool IsOver()
    {
        return currentTurn > MAX_TURNS;
    }
}