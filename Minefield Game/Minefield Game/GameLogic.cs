namespace Minefield_Game
{
    public class GameLogic
    {
        private GameBoard _gameBoard;

        private int _playerRow;
        private int _playerColumn;
        private int _remainingLives;
        private int _movesTaken;

        public int CurrentLives => _remainingLives;

        /// <summary>
        /// Initilise the game logic.
        /// </summary>
        /// <param name="boardSize">The board size</param>
        /// <param name="initialLives">Amount of initial lives</param>
        /// <param name="numberofMines">Number of mines within the board</param>
        public GameLogic(int boardSize, int initialLives, int numberofMines)
        {
            Console.ForegroundColor = ConsoleColor.White;

            _gameBoard = new GameBoard(boardSize, boardSize);
            _gameBoard.AddMines(numberofMines);

            _remainingLives = initialLives;
            _movesTaken = 0;

            _playerRow = 0;
            _playerColumn = 0;
        }

        /// <summary>
        /// Moves the player based on user console input. 
        /// </summary>
        /// <param name="direction">User inputted direction.</param>
        public void MovePlayer(string direction)
        {
            if (string.IsNullOrEmpty(direction))
                return;

            var newRow = _playerRow;
            var newColumn = _playerColumn;

            // Update the new position based on the chosen direction
            switch (direction.ToLower())
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "left":
                    newColumn--;
                    break;
                case "right":
                    newColumn++;
                    break;
                default:
                    Helpers.Instance.SendColouredMessage("Invalid direction", ConsoleColor.Red);
                    return;
            }

            // Check if the new position is valid
            if (IsValidMove(newRow, newColumn))
            {
                _playerRow = newRow;
                _playerColumn = newColumn;
                _movesTaken++;

                // Check if the player has hit a mine
                if (_gameBoard.HasMine(_playerRow, _playerColumn))
                {
                    _remainingLives--;
                    _gameBoard.DeactivateMine(_playerRow, _playerColumn);
                    Helpers.Instance.SendColouredMessage($"You hit a mine! Remaining lives: {_remainingLives}", ConsoleColor.Red);
                }
            }
            else
            {
                Console.WriteLine("Invalid move. Out of bounds.");
            }
        }

        /// <summary>
        /// Checks if game is over based on current position or remaining lives.
        /// </summary>
        public bool IsGameOver()
        {
            return (_playerRow == _gameBoard.Rows - 1 && _playerColumn == _gameBoard.Columns - 1) 
                || _remainingLives == 0;
        }

        /// <summary>
        /// Prints the current game state to console.
        /// </summary>
        public void PrintGameState()
        {
            if (IsGameOver())
            { 
                if (_remainingLives == 0)
                {
                    Helpers.Instance.SendColouredMessage("Game Over", ConsoleColor.Red);
                    Helpers.Instance.SendColouredMessage("You failed to make it across the MineField... Better luck next time!", ConsoleColor.Red);
                }
                else
                {
                    Helpers.Instance.SendColouredMessage($"You managed to make it across the MineField, congratulations", ConsoleColor.Green);
                    Helpers.Instance.SendColouredMessage($"Remaining Lives: {_remainingLives}", ConsoleColor.Green);
                    Helpers.Instance.SendColouredMessage($"Final Score: {_movesTaken}", ConsoleColor.Green);
                }
            }
            else
            {
                if (Helpers.Instance.HardModeEnabled)
                {
                    Console.WriteLine($"Current Position: {FormatPosition(_playerRow, _playerColumn)}");
                }
                else
                {
                    Console.WriteLine($"Current Position: {FormatPosition(_playerRow, _playerColumn)}");
                    Console.WriteLine($"Remaining Lives: {_remainingLives}");
                    Console.WriteLine($"Moves Taken: {_movesTaken}");
                }
            }
        }

        /// <summary>
        /// Checks that the cell you're trying to move to is a valid position.
        /// </summary>
        /// <param name="row">The row you're trying to move to</param>
        /// <param name="column">The column you're trying to move to</param>
        private bool IsValidMove(int row, int column)
        {
            return row >= 0 && row < _gameBoard.Rows && column >= 0 && column < _gameBoard.Columns;
        }

        /// <summary>
        /// Formats the player position to chess style formatting by utilising C#'s numeric chars.
        /// </summary>
        /// <param name="row">Current player row</param>
        /// <param name="column">Current player column</param>
        private string FormatPosition(int row, int column)
        {
            var columnChar = (char)('A' + column);
            return columnChar + (row + 1).ToString();
        }
    }
}
