using RetailStoreInventory.Desktop.ViewModels;
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
using System.Windows.Shapes;

namespace RetailStoreInventory.Desktop.Views
{
    /// <summary>
    /// Code-behind for MainWindow.xaml.
    /// Sets the DataContext to an instance of MainWindowViewModel to enable data binding.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Bind the ViewModel to the View
            DataContext = new MainWindowViewModel();
        }
    }
}
