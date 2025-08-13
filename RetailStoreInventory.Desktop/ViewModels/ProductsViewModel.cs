using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailStoreInventory.Desktop.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace RetailStoreInventory.Desktop.ViewModels
{
    /// <summary>
    /// ViewModel for managing the Products view.
    /// This ViewModel handles all the business logic for displaying, adding, editing, and deleting products.
    /// It acts as the bridge between the Products view and the Product model.
    /// 
    /// Key responsibilities:
    /// - Managing the collection of products
    /// - Handling product CRUD operations (Create, Read, Update, Delete)
    /// - Providing commands for UI interactions
    /// - Maintaining product data state
    /// </summary>
    public class ProductsViewModel : BaseViewModel
    {
        /// <summary>
        /// Collection of products that is bound to the DataGrid in the UI.
        /// ObservableCollection automatically notifies the UI when items are added/removed.
        /// This enables real-time updates in the DataGrid.
        /// </summary>
        public ObservableCollection<Product> Products { get; set; }
        
        /// <summary>
        /// Command for adding new products to the collection.
        /// Bound to the "Add Product" button in the UI.
        /// </summary>
        public ICommand AddProductCommand { get; }
        
        /// <summary>
        /// Command for editing existing products.
        /// Bound to the "Edit" button in each DataGrid row.
        /// </summary>
        public ICommand EditProductCommand { get; }
        
        /// <summary>
        /// Command for deleting products from the collection.
        /// Bound to the "Delete" button in each DataGrid row.
        /// </summary>
        public ICommand DeleteProductCommand { get; }

        /// <summary>
        /// Counter for generating unique IDs for new products.
        /// In a real application, this would typically come from a database.
        /// </summary>
        private int _nextId = 3;

        /// <summary>
        /// Initializes the ProductsViewModel.
        /// Sets up the product collection with sample data and initializes all commands.
        /// </summary>
        public ProductsViewModel()
        {
            // Initialize the products collection with some sample data
            Products = new ObservableCollection<Product>
            {
                new Product { Id = 1, Name = "Coke 237ml", Quantity = 10, Price = 15.00m },
                new Product { Id = 2, Name = "Hansel", Quantity = 20, Price = 6.00m },
            };

            // Initialize all the commands with their respective methods
            AddProductCommand = new RelayCommand(AddProduct);
            EditProductCommand = new RelayCommand(EditProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
        }

        /// <summary>
        /// Adds a new product to the collection.
        /// This method is called when the AddProductCommand is executed.
        /// </summary>
        /// <param name="parameter">Not used in this implementation</param>
        private void AddProduct(object? parameter)
        {
            // Create a new product with auto-generated ID and default values
            var newProduct = new Product 
            { 
                Id = _nextId++, // Generate unique ID and increment for next use
                Name = $"New Product {_nextId - 1}", // Give it a temporary name
                Quantity = 0, // Start with zero quantity
                Price = 0.00m // Start with zero price
            };
            
            // Add the new product to the collection (UI automatically updates)
            Products.Add(newProduct);
        }

        /// <summary>
        /// Handles editing a product.
        /// Currently shows a message box, but in a real app this would open an edit dialog.
        /// This method is called when the EditProductCommand is executed.
        /// </summary>
        /// <param name="parameter">The Product object to edit (passed from the UI)</param>
        private void EditProduct(object? parameter)
        {
            // Check if the parameter is actually a Product
            if (parameter is Product product)
            {
                // Show a simple message for now
                MessageBox.Show($"Editing product: {product.Name}", "Edit Product");
                
                // TODO: In a real application, you would:
                // 1. Open an edit dialog/window
                // 2. Allow user to modify product properties
                // 3. Save changes back to the collection
            }
        }

        /// <summary>
        /// Handles deleting a product from the collection.
        /// Shows a confirmation dialog before actually deleting.
        /// This method is called when the DeleteProductCommand is executed.
        /// </summary>
        /// <param name="parameter">The Product object to delete (passed from the UI)</param>
        private void DeleteProduct(object? parameter)
        {
            // Check if the parameter is actually a Product
            if (parameter is Product product)
            {
                // Show confirmation dialog to prevent accidental deletions
                var result = MessageBox.Show(
                    $"Are you sure you want to delete {product.Name}?", 
                    "Confirm Delete", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);
                
                // Only delete if user confirms
                if (result == MessageBoxResult.Yes)
                {
                    // Remove the product from the collection (UI automatically updates)
                    Products.Remove(product);
                }
            }
        }
    }
}
