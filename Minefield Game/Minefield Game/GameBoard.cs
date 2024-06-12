using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield_Game
{
    public class GameBoard
    {
        private int _rows;
        private int _columns;
        private bool[,] _cells;

        public int Rows => _rows;
        public int Columns => _columns;

        /// <summary>
        /// Initilise the gameboard with the amount of rows and columns to populate the amount of cells.
        /// </summary>
        /// <param name="rows">Amount of rows in the grid</param>
        /// <param name="columns">Amount of colunms in the grid</param>
        public GameBoard(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _cells = new bool[rows, columns];
        }

        /// <summary>
        /// Checks if the current cell has a mine, determined by the row and column.
        /// </summary>
        /// <param name="row">Currently selected row</param>
        /// <param name="column">Currently selected column</param>
        public bool HasMine(int row, int column)
        {
            if (IsValidCell(row, column))
            {
                return _cells[row, column];
            }
            else
            {
                throw new ArgumentException("Invalid cell coordinates.");
            }
        }

        /// <summary>
        /// Deactive a mine once a player hits it.
        /// </summary>
        /// <param name="row">Players current row</param>
        /// <param name="column">Players current column</param>
        public void DeactivateMine(int row, int column)
        {
            if (IsValidCell(row, column))
            {
                _cells[row, column] = false;
            }
        }

        /// <summary>
        /// Adds mines to random columns and rows based on the amount of mines the user wishes to add..
        /// </summary>
        /// <param name="numberOfMines">Number of mines to add</param>
        public void AddMines(int numberOfMines)
        {
            Random random = new Random();
            
            for (int i = 0; i < numberOfMines; i++)
            {
                var randomRow = random.Next(0, _rows);
                var randomColumn = random.Next(0, _columns);

                // This will make sure that the same cells never get selected and there are always the specified amount of bombs.
                while (_cells[randomRow, randomColumn] == true)
                {
                    randomRow = random.Next(0, _rows);
                    randomColumn = random.Next(0, _columns);
                }

                if (IsValidCell(randomRow, randomColumn))
                {
                    _cells[randomRow, randomColumn] = true;
                }
            }
        }

        /// <summary>
        /// Checks if the cell is a valid cell.
        /// </summary>
        /// <param name="row">Current row</param>
        /// <param name="column">Current column</param>
        private bool IsValidCell(int row, int column)
        {
            return row >= 0 && row < _rows && column >= 0 && column < _columns;
        }
    }
}
