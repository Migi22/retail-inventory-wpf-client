using RetailStoreInventory.Desktop.Services;
using System.Windows;

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

            // Attach token for all API requests
            AuthService.AttachToken();
        }
    }
}
