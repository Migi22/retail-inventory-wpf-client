using RetailStoreInventory.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStoreInventory.Desktop.ViewModels
{
    /// <summary>
    /// ViewModel for Main Window.
    /// Holds the data and commands for the main view of the retail store inventory application.
    /// </summary>
    public class MainWindowViewModel
    {
        /// <summary>
        /// A collection of products in the retail store inventory dosplayed in the MainWindow DataGrid.
        /// ObservableCollection is used to automatically update the UI when items are added or removed.
        /// </summary>
        public ObservableCollection<Product> Products { get; set; }

        /// <summary>
        /// Constructor that initialize the products collection with sample data.
        /// </summary>
        public MainWindowViewModel()
        {
            Products =
            [
                new Product { Id = 1, Name = "Coke 237ml", Quantity = 10, Price = 15.00m },
                new Product { Id = 2, Name = "Hansel", Quantity = 20, Price = 6.00m },
            ];
        }
    }
}
