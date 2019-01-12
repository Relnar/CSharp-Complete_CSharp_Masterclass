using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace HelloWorld
{
  class Program
  {
    // Starting point of our program
    static void Main(string[] args)
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.BackgroundColor = ConsoleColor.DarkGray;
      Console.Clear();
      Console.WriteLine("Hello world");
      Console.ResetColor();

      GreetFriend("John");
      GreetFriend("Robert");
      Console.WriteLine("");

      // Loops and inputs
      Console.WriteLine("Loops and inputs\n-----------");
      double[] adValues = { 0.0, 0.0 };
      for (int nIndex = 0; nIndex < adValues.Length; ++nIndex)
      {
        do
        {
          Console.WriteLine("Enter number {0}: ", nIndex + 1);
        }
        while (!ValidateInput(Console.ReadLine(), out adValues[nIndex]));
      }
      Console.WriteLine("Sum is " + (adValues[0] + adValues[1]));
      Console.WriteLine("");

      // Jagged arrays
      Console.WriteLine("Jagged arrays\n-----------");
      int[][] jaggedArray = new int[][]
      {
        new int[] { 2, 3 ,4, 5, 6 },
        new int[] { 7, 8, 9}
      };
      for (int i = 0; i < jaggedArray.Length; ++i)
      {
        for (int j = 0; j < jaggedArray[i].Length; ++j)
        {
          Console.Write(jaggedArray[i][j] + " ");
        }
        Console.WriteLine("");
      }
      Console.WriteLine("");

      // ArrayList
      Console.WriteLine("ArrayList\n-----------");
      ArrayList myArrayList = new ArrayList(5);
      myArrayList.Add(12);
      myArrayList.Add("Test");
      myArrayList.Add(2.3);
      foreach (object obj in myArrayList)
      {
        Console.WriteLine(Convert.ToString(obj));
      }
      Console.WriteLine("");
    }

    private static bool ValidateInput(string szInput, out double rdResult)
    {
      if (!Double.TryParse(szInput, out rdResult))
      {
        rdResult = 0.0;
        return false;
      }
      return true;
    }

    private static void GreetFriend(string friend)
    {
      Console.WriteLine("Hello friend " + friend);
    }
    /* test
     * Multiline
     * comment
     * 
     * /
     */
  }
}
