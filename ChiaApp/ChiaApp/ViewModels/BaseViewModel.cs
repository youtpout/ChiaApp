using ChiaApp.Models;
using ChiaApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ChiaApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private bool loading;

        public bool Loading
        {
            get { return loading; }
            set { SetProperty(ref loading, value); }
        }

        private decimal progress;

        public decimal Progress
        {
            get { return progress; }
            set { SetProperty(ref progress, value); }
        }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                SetProperty(ref error, value);
                ShowError = !string.IsNullOrEmpty(value);
            }
        }

        private bool showError;
        public bool ShowError
        {
            get { return showError; }
            set { SetProperty(ref showError, value); ; }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
