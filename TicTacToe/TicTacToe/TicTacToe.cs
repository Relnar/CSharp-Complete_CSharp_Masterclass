using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
  class TicTacToe
  {
    private char[,] aszBoard;
    private bool player1Turn;
    private int numberOfTurns;

    public TicTacToe()
    {
      ResetGame();
    }

    public int PlayerTurn { get => player1Turn ? 1 : 2; }
    public bool GameWon { get; private set; }
    public bool GameIsADraw { get => numberOfTurns <= 0; }

    public void ResetGame()
    {
      player1Turn = true;
      GameWon = false;

      aszBoard = new char[3, 3];
      for (int i = 0; i < aszBoard.GetLength(0); ++i)
      {
        for (int j = 0; j < aszBoard.GetLength(0); ++j)
        {
          aszBoard[i, j] = (i * aszBoard.GetLength(0) + j + 1).ToString().ToCharArray()[0];
        }
      }

      this.numberOfTurns = aszBoard.Length;
    }

    public void DisplayBoard()
    {
      Console.Clear();
      for (int i = 0; i < aszBoard.GetLength(0); ++i)
      {
        Console.WriteLine("   |   |");
        Console.WriteLine(" {0} | {1} | {2}", aszBoard[i, 0], aszBoard[i, 1], aszBoard[i, 2]);
        Console.WriteLine("   |   |");
        if (i < aszBoard.GetLength(0) - 1)
        {
          Console.WriteLine("-----------");
        }
      }
    }

    public bool ChooseNumber(int number)
    {
      if (number > 0 && number <= aszBoard.Length &&
          !GameIsADraw && !GameWon)
      {
        char boardValue = GetBoardValue(number - 1);
        if (!boardValue.Equals('O') && !boardValue.Equals('X'))
        {
          SetBoardValue(number - 1);
          GameWon = CheckGameWon(number - 1);
          if (GameWon)
          {
            return true;
          }
          numberOfTurns--;
          player1Turn = !player1Turn;
          return true;
        }
      }
      return false;
    }

    private bool CheckGameWon(int number)
    {
      // 1  2  3
      // 4  5  6
      // 7  8  9
      int nRow = number / 3;
      int nCol = number % 3;

      char playerVal = PlayerValue;

      // Horizontal match
      if (aszBoard[(nRow + 1) % 3, nCol] == playerVal &&
          aszBoard[(nRow + 2) % 3, nCol] == playerVal)
      {
        return true;
      }
      // Vertical match
      else if (aszBoard[nRow, (nCol + 1) % 3] == playerVal &&
               aszBoard[nRow, (nCol + 2) % 3] == playerVal)
      {
        return true;
      }
      // Elements on a diagonal are always odd
      else if (((number + 1) % 2) != 0)
      {
        switch (number + 1)
        {
          case 1:
            return playerVal == aszBoard[1, 1] && playerVal == aszBoard[2, 2];
          case 3:
            return playerVal == aszBoard[1, 1] && playerVal == aszBoard[2, 0];
          case 5:
            return ((playerVal == aszBoard[0, 0] && playerVal == aszBoard[2, 2]) ||
                    (playerVal == aszBoard[2, 0] && playerVal == aszBoard[0, 2]));
          case 7:
            return playerVal == aszBoard[1, 1] && playerVal == aszBoard[0, 2];
          case 9:
            return playerVal == aszBoard[1, 1] && playerVal == aszBoard[0, 0];
        }
      }

      return false;
    }

    // Private methods
    private char GetBoardValue(int nIndex) { return aszBoard[nIndex / 3, nIndex % 3]; }
    private void SetBoardValue(int nIndex) { aszBoard[nIndex / 3, nIndex % 3] = PlayerValue; }
    private char PlayerValue { get => player1Turn ? 'X' : 'O'; }
  }
}
