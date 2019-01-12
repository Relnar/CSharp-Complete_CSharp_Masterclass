using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
  class Car
  {
    public Car(int hp, string color)
    {
      HP = hp;
      Color = color;
    }
    public int HP { get; set; }
    public string Color { get; set; }
    protected CarIDInfo carIDInfo = new CarIDInfo();

    public void SetCarIDInfo(int idNum, string owner)
    {
      carIDInfo.IDNum = idNum;
      carIDInfo.Owner = owner;
    }

    public void GetCardIDInfo()
    {
      Console.WriteLine("The car has the ID of {0} and is owned by {1}", carIDInfo.IDNum, carIDInfo.Owner);
    }

    public virtual void ShowDetails()
    {
      Console.WriteLine("Car HP: {0}, Color: {1}", HP, Color);
    }

    public virtual void Repair()
    {
      Console.WriteLine("Car was repaired");
    }
  }

  class BMW : Car
  {
    public BMW(string model, int hp, string color)
    : base(hp, color)
    {
      Model = model;
    }

    public string Model { get;  private set; }

    public override void ShowDetails()
    {
      Console.WriteLine("{0} HP: {1}, Color: {2}, Model: {3}", brand, HP, Color, Model);
    }

    public sealed override void Repair()
    {
      Console.WriteLine(brand + " " + Model + " was repaired");
    }

    private string brand = "BMW";
  }

  class M3 : BMW
  {
    public M3(int hp, string color)
    : base("M3", hp, color)
    {
    }

    // Can't be overriden because of the sealed keyword
//     public override void Repair()
//     {
//       base.Repair();
//     }
  }

  class Audi : Car
  {
    public Audi(string model, int hp, string color)
    : base(hp, color)
    {
      Model = model;
    }

    public string Model { get; private set; }

    public override void ShowDetails()
    {
      Console.WriteLine("{0} HP: {1}, Color: {2}, Model: {3}", brand, HP, Color, Model);
    }

    // new keyword redefine the method that would be hidden if not overriden (it's not a virtual method)
    // So, it will call the base class Car instead in this case
    public new void Repair()
    {
      Console.WriteLine(brand + " " + Model + " was repaired");
    }

    private string brand = "Audi";
  }

  class CarIDInfo
  {
    public int IDNum { get; set; } = 0;
    public string Owner { get; set; } = "No owner";
  }

  class Program
  {
    static void Main(string[] args)
    {
      var cars = new List<Car>
      {
        new Car(100, "red"),
        new BMW("i323", 200, "black"),
        new Audi("a3", 150, "blue"),
        new M3(350, "white")
      };

      cars[0].SetCarIDInfo(1234, "PLB");
      cars[1].SetCarIDInfo(6789, "Allo");

      foreach (var car in cars)
      {
        // is keyword to test if the class is of the correct type
        if (car is Car)
        {
          car.ShowDetails();
          car.Repair();
          car.GetCardIDInfo();
          Console.WriteLine("");
        }
      }

      // Reading from a file
      const string filePath = @"C:\Complete C# Masterclass\Polymorphism\Polymorphism\textfile.txt";
      const string filePath2 = @"C:\Complete C# Masterclass\Polymorphism\Polymorphism\textfile2.txt";
      const string filePath3 = @"C:\Complete C# Masterclass\Polymorphism\Polymorphism\textfile3.txt";
      string text = System.IO.File.ReadAllText(filePath);
      Console.WriteLine("File content:\n" + text);

      string[] lines = System.IO.File.ReadAllLines(filePath);
      foreach (var line in lines)
      {
        Console.WriteLine(line);
      }

      // Writing to a file
      System.IO.File.WriteAllText(filePath, text + String.Format("Added new content at {0}\n", System.DateTime.Now.ToString()));
      System.IO.File.WriteAllLines(filePath2, lines);

      // Using a stream writer
      using (StreamWriter file = new StreamWriter(filePath3))
      {
        foreach (var line in lines)
        {
          file.WriteLine(line);
        }
      }
    }
  }
}
