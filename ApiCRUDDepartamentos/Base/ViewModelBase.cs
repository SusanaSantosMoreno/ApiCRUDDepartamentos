using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ApiCRUDDepartamentos.Base {
    public class ViewModelBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

