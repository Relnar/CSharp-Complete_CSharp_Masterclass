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

namespace WPF_CheckBox
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void CbAllToppings_Checked(object sender, RoutedEventArgs e)
    {
      bool bNewValue = cbAllToppings.IsChecked == true;
      cbExtraCheese.IsChecked = bNewValue;
      cbMushroom.IsChecked = bNewValue;
      cbSalami.IsChecked = bNewValue;
    }

    private void Topping_Checked(object sender, RoutedEventArgs e)
    {
      cbAllToppings.IsChecked = null;

      CheckBox checkBox = sender as CheckBox;
      if (cbExtraCheese.IsChecked == true &&
          cbMushroom.IsChecked == true &&
          cbSalami.IsChecked == true)
      {
        cbAllToppings.IsChecked = true;
      }
      else if (cbExtraCheese.IsChecked == false &&
               cbMushroom.IsChecked == false &&
               cbSalami.IsChecked == false)
      {
        cbAllToppings.IsChecked = false;
      }
    }
  }
}
