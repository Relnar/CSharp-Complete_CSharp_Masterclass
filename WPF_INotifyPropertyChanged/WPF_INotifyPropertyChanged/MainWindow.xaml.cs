using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WPF_INotifyPropertyChanged
{
  public class Sum : INotifyPropertyChanged
  {
    private string num1;
    private string num2;
    private string result;

    private void ValidateValue(string value, string propertyName, ref string num)
    {
      int number;
      bool result = int.TryParse(value, out number);
      if (result)
      {
        num = value;
        OnPropertyChanged(propertyName);
        OnPropertyChanged("Result");
      }
    }

    public string Num1
    {
      get { return num1; }
      set { ValidateValue(value, "Num1", ref num1); }
    }
    public string Num2
    {
      get { return num2; }
      set { ValidateValue(value, "Num2", ref num2); }
    }
    public string Result
    {
      get
      {
        int res = int.Parse(num1) + int.Parse(num2);
        return res.ToString();
      }
      set
      {
        int res = int.Parse(num1) + int.Parse(num2);
        result = res.ToString();
        OnPropertyChanged("Result");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string property)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(property));
      }
    }
  }

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public Sum SumObj { get; set; }

    public MainWindow()
    {
      InitializeComponent();

      SumObj = new Sum { Num1 = "1", Num2 = "3" };
      this.DataContext = SumObj;
    }
  }
}
