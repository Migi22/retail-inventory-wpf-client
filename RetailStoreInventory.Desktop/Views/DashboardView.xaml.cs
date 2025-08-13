using System.Windows.Controls;

namespace RetailStoreInventory.Desktop.Views
{
    /// <summary>
    /// Code-behind file for DashboardView.xaml
    /// 
    /// This file contains the minimal code needed to support the dashboard view.
    /// The dashboard displays overview information and doesn't require complex logic.
    /// 
    /// In MVVM architecture, this is a simple view that could potentially
    /// be enhanced with a ViewModel if dynamic data binding is needed later.
    /// </summary>
    public partial class DashboardView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the DashboardView.
        /// Sets up the XAML-defined UI elements.
        /// </summary>
        public DashboardView()
        {
            // Initialize the XAML-defined controls
            InitializeComponent();
        }
    }
}
