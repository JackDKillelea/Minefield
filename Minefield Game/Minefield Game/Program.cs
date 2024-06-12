namespace Minefield_Game
{
    class Program
    {
        private static int _boardSize;
        private static int _numberOfLives;
        private static int _numberOfMines;

        private static void Main(string[] args)
        {
            GetBoardSize();
            GetNumberOfLives();
            GetNumberOfMines();
            EnableHardMode();

            GameState gameState = new GameState(_boardSize, _numberOfLives, _numberOfMines);
            gameState.StartGame();
        }

        /// <summary>
        /// Gets the board size the player wishes to play on.
        /// </summary>
        private static void GetBoardSize()
        {
            Console.Write("Please select board size (Enter only numerical values): ");
            while (!int.TryParse(Console.ReadLine(), out _boardSize))
            {
                Console.Write("Invalid input. Please enter a valid number for board size: ");
            }
        }

        /// <summary>
        /// Gets the number of lives a player wishes to have.
        /// </summary>
        private static void GetNumberOfLives()
        {
            Console.Write("Please select number of lives you wish to have (Enter only numerical values): ");
            while (!int.TryParse(Console.ReadLine(), out _numberOfLives))
            {
                Console.Write("Invalid input. Please enter a valid number for number of lives: ");
            }
        }

        /// <summary>
        /// Gets the number of mines the player wishes to deal with.
        /// </summary>
        private static void GetNumberOfMines()
        {
            Console.Write("Please select number of mines on the field (Enter only numerical values): ");
            while (!int.TryParse(Console.ReadLine(), out _numberOfMines))
            {
                Console.Write("Invalid input. Please enter a valid number for number of mines: ");
            }

            if (!IsValidMineNumber(_boardSize, _numberOfMines))
            {
                Console.WriteLine("Number of mines can not be greater than or equal to board size.");
                GetNumberOfMines();
            }
        }

        /// <summary>
        /// Checks that the number of mines entered is not greater than or equal to the current board size.
        /// </summary>
        /// <param name="boardSize">The board size the player has entered</param>
        /// <param name="numberOfMines">The number of mines the player has entered</param>
        private static bool IsValidMineNumber(int boardSize, int numberOfMines)
        {
            return !(numberOfMines >= boardSize * boardSize);
        }

        /// <summary>
        /// Puts the user into hard mode if they wish to play in hard mode.
        /// </summary>
        private static void EnableHardMode()
        {
            Console.Write("Do you want to play in hard mode? (Y/N): ");
            string hardModeInput = Console.ReadLine();

            Helpers.Instance.HardModeEnabled = (hardModeInput.Trim().ToUpper() == "Y");
        }
    }
}
