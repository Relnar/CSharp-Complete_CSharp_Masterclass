using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTopics
{
  class Program
  {
    public delegate int SomeMath(double i);

    struct Game
    {
      public string name;
      public string developer;
      public float rating;
      public string releaseDate;

      public void DisplayInfo()
      {
        Console.WriteLine(name + " by " + developer + " rated " + rating + " in " + releaseDate);
      }

      // Struct can't have default constructor or inheritance
      public Game(string name, string developer, float rating, string releaseDate)
      {
        this.name = name;
        this.developer = developer;
        this.rating = rating;
        this.releaseDate = releaseDate;
      }
    }

    enum Day
    {
      Mo,
      Tu,
      We,
      Th,
      Fr,
      Sa,
      Su
    }

    static void Main(string[] args)
    {
      // Delegate
      Console.WriteLine("Delegate");
      SomeMath math = new SomeMath(Square);
      Console.WriteLine("math(8.8) = {0}  (Real answer = {1})", math(8.8), 8.8 * 8.8);

      // Delegate as an argument
      Console.WriteLine("\nDelegate as an method argument to find even numbers");
      List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
      List<int> listEven = list.FindAll(delegate (int i)
      {
        return (i % 2) == 0;
      });
      foreach (int val in listEven)
      {
        Console.Write(val + " ");
      }
      Console.WriteLine("");

      // Lambda expression
      Console.WriteLine("\nLambda expression to find odd numbers");
      List<int> listOdd = list.FindAll(i => (i % 2 == 1));
      // Can be combined like this listOdd.ForEach(val => Console.Write(val + " "));
      listOdd.ForEach(val =>
      {
        Console.Write(val);
        Console.Write(" ");
      });
      Console.WriteLine("");

      // Delegage/Lambda expression with 2 parameters
      Console.WriteLine("\nLambda expression to scale elements by 2");
      Compare comp = (val, scale) => val < scale;
      Console.WriteLine("2 < 4 = {0}", comp(2, 4));
      Console.WriteLine("5 < 1 = {0}", comp(5, 1));
      Console.WriteLine("");

      // ArrayList
      ArrayList arrayList = new ArrayList
      {
        1,
        2.3,
        "Test"
      };
      Console.WriteLine("ArrayList example");
      foreach (var obj in arrayList)
      {
        Console.Write(obj.ToString() + " ");
      }
      Console.WriteLine("");

      // Struct (value type)
      Console.WriteLine("\nStruct example");
      Game game1;
      game1.name = "Pokemon Go";
      game1.developer = "Niantic";
      game1.rating = 3.5f;
      game1.releaseDate = "01.07.2016";
      game1.DisplayInfo();

      // Enum
      Console.WriteLine("\nEnum examples");
      Day fr = Day.Fr;
      Day b = Day.Fr;
      Console.WriteLine("Day.Fr " + fr + " " + (int)fr);
      Console.WriteLine("Day.b " + b + " " + (int)b);

      // Nullable
      Console.WriteLine("\nNullable");
      int? a = null;
      Console.WriteLine("int? a = \"{0}\"", a);
      a = 12;
      Console.WriteLine("a = 12 => {0}", a);
      int? a2 = null;
      a2 = a;
      Console.WriteLine("b = a => {0}", a2);
    }

    private delegate bool Compare(int i, int j);

    private static int Square(double i)
    {
      return (int)(i * i);
    }
  }
}
