using System;
using ApiCRUDDepartamentos.Services;
using ApiCRUDDepartamentos.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiCRUDDepartamentos {
    public partial class App : Application {

        public static ServiceIoC _ServiceLocator;
        public static ServiceIoC ServiceLocator {
            get { return _ServiceLocator =
                    _ServiceLocator ?? new ServiceIoC(); }
        }

        public App () {
            InitializeComponent();

            MainPage = new MainDepartamentos();
        }

        protected override void OnStart () { }

        protected override void OnSleep () { }

        protected override void OnResume () { }
    }
}
