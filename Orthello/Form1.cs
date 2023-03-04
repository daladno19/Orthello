namespace Orthello
{
    // GUI
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    // class to store state of all cells
    public class CellState
    {
        public const int Empty = 0;
        public const int White = 1;
        public const int Black = 2;
    }

    // class to store gameboard state
    public class Gameboard
    {
        private int[,] cells;

        //          0 0 0 0 0 0 0 0
        //          0 0 0 0 0 0 0 0
        //          0 0 0 0 0 0 0 0
        //          0 0 0 1 2 0 0 0
        //          0 0 0 2 1 0 0 0
        //          0 0 0 0 0 0 0 0
        //          0 0 0 0 0 0 0 0
        //          0 0 0 0 0 0 0 0

        public Gameboard()
        { 
            cells = new int[8,8];
            cells[3, 3] = CellState.White;
            cells[4, 4] = CellState.White;
            cells[3, 4] = CellState.Black;
            cells[4, 3] = CellState.Black;
        }

        public int GetCellState(int row, int col)
        { 
            return cells[row, col];
        }

        public bool IsValidMove(int row, int col, int color)
        {
            return true; // TODO
        }

        public void MakeMove(int row, int col, int color)
        { 
            // TODO
        }
    }

    // Player class, used to make moves
    public class Player
    {
        private int color;

        public Player(int color)
        { 
            this.color = color;
        }

        public void MakeMove(int row, int col, Gameboard board)
        {
            if (board.IsValidMove(row, col, color))
            { 
                board.MakeMove(row, col, color);
            }
        }
    }

    // Class to manage game sequence
    public class GameManager
    { 
        private Gameboard board;
        private Player blackPlayer;
        private Player whitePlayer;
        private int currentPlayer;

        public GameManager()
        { 
            board = new Gameboard();
            blackPlayer = new Player(CellState.Black);
            whitePlayer = new Player(CellState.White);
            currentPlayer = CellState.Black;
        }

        public void HandleCellClick(int row, int col)
        {
            if (currentPlayer == CellState.Black)
            {
                blackPlayer.MakeMove(row, col, board);
                currentPlayer = CellState.White;
            }
            else 
            {
                whitePlayer.MakeMove(row, col, board);
                currentPlayer = CellState.Black;
            }

            // TODO update gui state
        }
    }
}