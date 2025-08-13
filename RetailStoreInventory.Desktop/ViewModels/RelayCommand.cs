using System;
using System.Windows.Input;

namespace RetailStoreInventory.Desktop.ViewModels
{
    /// <summary>
    /// Implementation of ICommand that allows binding UI controls (like buttons) to ViewModel methods.
    /// This is a crucial part of MVVM pattern - it bridges the gap between UI actions and business logic.
    /// 
    /// Usage example:
    /// public ICommand SaveCommand { get; } = new RelayCommand(SaveData, CanSaveData);
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The action to execute when the command is invoked (e.g., button click)
        /// </summary>
        private readonly Action<object?> _execute;
        
        /// <summary>
        /// Optional predicate that determines if the command can execute (e.g., button enabled/disabled)
        /// </summary>
        private readonly Predicate<object?>? _canExecute;

        /// <summary>
        /// Creates a new RelayCommand instance.
        /// </summary>
        /// <param name="execute">The method to call when the command executes</param>
        /// <param name="canExecute">Optional method to determine if command can execute (null = always can execute)</param>
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            // Ensure we have a valid execute method
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Event that WPF raises to check if the command can execute.
        /// This enables/disables UI controls automatically.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            // Subscribe to WPF's global requery suggestion system
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Determines if the command can execute based on the canExecute predicate.
        /// </summary>
        /// <param name="parameter">Command parameter (e.g., selected item)</param>
        /// <returns>True if command can execute, false otherwise</returns>
        public bool CanExecute(object? parameter)
        {
            // If no canExecute predicate is provided, always allow execution
            // Otherwise, call the predicate to determine if execution is allowed
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Executes the command by calling the execute action.
        /// </summary>
        /// <param name="parameter">Command parameter (e.g., selected item)</param>
        public void Execute(object? parameter)
        {
            // Call the actual method that handles the command logic
            _execute(parameter);
        }
    }
}
