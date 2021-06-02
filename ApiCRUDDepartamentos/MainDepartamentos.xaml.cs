using ApiCRUDDepartamentos.Code;
using ApiCRUDDepartamentos.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiCRUDDepartamentos {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDepartamentos : MasterDetailPage {
        public MainDepartamentos () {
            InitializeComponent();
            ObservableCollection<MenuPageItem> menu = new ObservableCollection<MenuPageItem>();

            MenuPageItem insertView = new MenuPageItem { Titulo = "Nuevo Departamento", Tipo = typeof(InsertDepartamentoView) };
            menu.Add(insertView);

            MenuPageItem departamentosView = new MenuPageItem { Titulo = "Departamentos", Tipo = typeof(DepartamentosView) };
            menu.Add(departamentosView);

            this.listViewMenu.ItemsSource = menu;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
            this.listViewMenu.ItemSelected += ListViewMenu_ItemSelected;
        }

        private void ListViewMenu_ItemSelected (object sender, SelectedItemChangedEventArgs e) {
            MenuPageItem item = e.SelectedItem as MenuPageItem;
            Type tipo = item.Tipo;
            Detail = new NavigationPage((Page)Activator.CreateInstance(tipo));
            IsPresented = false;
        }
    }
}