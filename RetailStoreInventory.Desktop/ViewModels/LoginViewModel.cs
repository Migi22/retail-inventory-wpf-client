using RetailStoreInventory.Desktop.Services;
using RetailStoreInventory.Desktop.Views;
using System.Windows;
using System.Windows.Input;

namespace RetailStoreInventory.Desktop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
                // Trigger command re-evaluation when username changes
                ((AsyncRelayCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                // Trigger command re-evaluation when password changes
                ((AsyncRelayCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            // use AsyncRelayCommand for async login
            LoginCommand = new AsyncRelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object parameter)
        {
            // Allow login only if both fields are not empty
            bool canExecute = !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
            return canExecute;
        }

        private async Task ExecuteLogin(object parameter)
        {
            try
            {
                var response = await AuthService.LoginAsync(Username, Password);

                if (response != null)
                {
                    // Save token and role globally
                    AuthService.Token = response.Token;
                    AuthService.UserRole = response.Role;

                    // Open MainWindow
                    var mainWindow = new MainWindow();
                    Application.Current.MainWindow = mainWindow;
                    mainWindow.Show();

                    // Close LoginWindow
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window is LoginWindow)
                        {
                            window.Close();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.",
                                    "Login Failed",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}
