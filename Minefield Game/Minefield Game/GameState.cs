using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield_Game
{
    public class GameState
    {
        private GameLogic _gameLogic;

        private int _boardSize;
        private int _numberOfMines;

        /// <summary>
        /// Initilise the game state.
        /// </summary>
        /// <param name="boardSize">Selected board size</param>
        /// <param name="initialLives">Initial amount of lives</param>
        /// <param name="numberOfMines">Number of mines on the field</param>
        public GameState(int boardSize, int initialLives, int numberOfMines)
        {
            _gameLogic = new GameLogic(boardSize, initialLives, numberOfMines);
            _boardSize = boardSize;
            _numberOfMines = numberOfMines;
        }

        /// <summary>
        /// Starts up the game.
        /// </summary>
        public void StartGame()
        {
            Console.Clear();
            Helpers.Instance.SendColouredMessage($"Welcome to Minefield", ConsoleColor.Cyan);

            while (!_gameLogic.IsGameOver())
            {
                if (Helpers.Instance.HardModeEnabled)
                {
                    Console.Clear();
                    Helpers.Instance.SendColouredMessage($"Welcome to Minefield", ConsoleColor.Cyan);
                    Helpers.Instance.SendColouredMessage($"Gameboard Size - {_boardSize}x{_boardSize}", ConsoleColor.Cyan);
                    Helpers.Instance.SendMulticolouredMessage("Current Lives - ", _gameLogic.CurrentLives.ToString(), ConsoleColor.Cyan, ConsoleColor.Red);
                    Helpers.Instance.SendColouredMessage($"Number of Mines - {_numberOfMines}", ConsoleColor.Cyan);

                    _gameLogic.PrintGameState();
                }
                else
                {
                    Console.WriteLine("------------------------");
                    _gameLogic.PrintGameState();
                }

                Console.Write("Please enter the direction you'd like to move (up, down, left, right): ");
                var move = Console.ReadLine();

                _gameLogic.MovePlayer(move);
            }

            Console.WriteLine("------------------------");
            _gameLogic.PrintGameState();
        }
    }
}
