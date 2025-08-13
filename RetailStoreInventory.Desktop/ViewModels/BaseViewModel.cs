using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace RetailStoreInventory.Desktop.ViewModels
{
    /// <summary>
    /// Base class for all ViewModels in the application.
    /// Implements INotifyPropertyChanged to enable data binding between ViewModels and Views.
    /// This is a fundamental part of the MVVM (Model-View-ViewModel) pattern.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that is raised when a property value changes.
        /// WPF uses this to automatically update the UI when data changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event to notify the UI that a property has changed.
        /// Uses CallerMemberName attribute to automatically get the property name.
        /// </summary>
        /// <param name="propertyName">Name of the property that changed (auto-filled by compiler)</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            // Safely invoke the event if there are subscribers
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Helper method to set a property value and automatically raise PropertyChanged.
        /// Only raises the event if the value actually changed (performance optimization).
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="field">Reference to the backing field</param>
        /// <param name="value">New value to set</param>
        /// <param name="propertyName">Name of the property (auto-filled by compiler)</param>
        /// <returns>True if the value changed, false if it was the same</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            // Check if the value is actually different to avoid unnecessary UI updates
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            // Set the new value
            field = value;

            // Notify the UI that this property changed
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
