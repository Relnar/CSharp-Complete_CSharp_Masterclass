using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
  class Program
  {
    static void Main(string[] args)
    {
      TicTacToe board = new TicTacToe();
      board.DisplayBoard();
 
      while (!board.GameWon && !board.GameIsADraw)
      {
        int nNumber = 0;
        do
        {
          Console.Write("Player {0}, choose number: ", board.PlayerTurn);
        }
        while (!ValidateInput(Console.ReadLine(), out nNumber));

        if (board.ChooseNumber(nNumber))
        {
          board.DisplayBoard();
        }
      }
      if (board.GameIsADraw)
      {
        Console.WriteLine("Game is a draw");
      }
      else
      {
        Console.WriteLine("Player {0} won !", board.PlayerTurn);
      }
    }

    private static bool ValidateInput(string szInput, out int rnResult)
    {
      if (!int.TryParse(szInput, out rnResult))
      {
        rnResult = 0;
        return false;
      }
      return true;
    }
  }
}
