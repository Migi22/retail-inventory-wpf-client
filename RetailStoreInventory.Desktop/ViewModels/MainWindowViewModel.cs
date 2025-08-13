using System.Windows.Controls;
using System.Windows.Input;

namespace RetailStoreInventory.Desktop.ViewModels
{
    /// <summary>
    /// Main ViewModel for the application window.
    /// This ViewModel handles navigation between different views (Dashboard, Products, Reports).
    /// It acts as the "shell" that manages which view is currently displayed.
    /// 
    /// Key responsibilities:
    /// - Navigation between different application sections
    /// - Managing the currently active view
    /// - Providing navigation commands to the UI
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// Backing field for the currently displayed view.
        /// This is what gets shown in the main content area of the window.
        /// </summary>
        private UserControl _currentView;
        
        /// <summary>
        /// Gets or sets the currently displayed view.
        /// When this changes, the UI automatically updates to show the new view.
        /// The OnPropertyChanged() call ensures the UI is notified of the change.
        /// </summary>
        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                // Notify the UI that this property changed so it can update
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Command that handles navigation between different views.
        /// This is bound to the navigation buttons in the sidebar.
        /// </summary>
        public ICommand NavigateCommand { get; }

        /// <summary>
        /// Initializes the MainWindowViewModel.
        /// Sets up the navigation command and displays the Products view by default.
        /// </summary>
        public MainWindowViewModel()
        {
            // Create the navigation command that will handle view switching
            NavigateCommand = new RelayCommand(NavigateTo);
            
            // Set the default view to Products when the application starts
            CurrentView = new Views.ProductsView();
        }

        /// <summary>
        /// Handles navigation requests from the UI.
        /// This method is called when the NavigateCommand is executed.
        /// </summary>
        /// <param name="parameter">The name of the view to navigate to (e.g., "Dashboard", "Products", "Reports")</param>
        public void NavigateTo(object? parameter)
        {
            // Check if the parameter is a string (view name)
            if (parameter is string viewName)
            {
                // Switch to the appropriate view based on the parameter
                switch (viewName)
                {
                    case "Dashboard":
                        CurrentView = new Views.DashboardView();
                        break;
                    case "Products":
                        CurrentView = new Views.ProductsView();
                        break;
                    case "Reports":
                        CurrentView = new Views.ReportsView();
                        break;
                }
            }
        }
    }
}
