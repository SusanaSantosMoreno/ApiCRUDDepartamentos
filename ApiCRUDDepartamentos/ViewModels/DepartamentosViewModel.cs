using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ApiCRUDDepartamentos.Base;
using ApiCRUDDepartamentos.Models;
using ApiCRUDDepartamentos.Services;
using ApiCRUDDepartamentos.Views;
using Xamarin.Forms;

namespace ApiCRUDDepartamentos.ViewModels {
    public class DepartamentosViewModel : ViewModelBase {

        ServiceDepartamentos service;

        public DepartamentosViewModel(ServiceDepartamentos serv) {
            this.service = serv;
            Task.Run(async () => {
                await this.CargarDepartamentosAsync();
            });
            MessagingCenter.Subscribe<DepartamentosViewModel>(this, "Reload", async (sender) => {
                await this.CargarDepartamentosAsync();
            });
        }

        public ObservableCollection<Departamento> _Departamentos;
        public ObservableCollection<Departamento> Departamentos {
            get { return this._Departamentos; }
            set {
                this._Departamentos = value;
                OnPropertyChanged("Departamentos");
            }
        }

        public async Task CargarDepartamentosAsync () {
            List<Departamento> listaDepartamentos =
                await this.service.GetDepartamentosAsync();
            this.Departamentos =
                new ObservableCollection<Departamento>(listaDepartamentos);
        }

        public Command MostrarDetalles {
            get { return new Command(async(Departamento) => {
                Departamento departamento = Departamento as Departamento;
                DepartamentoViewModel viewModel =  App.ServiceLocator.DepartamentoViewModel;
                viewModel.Departamento = departamento;

                DetailsDepartamentoView view = new DetailsDepartamentoView();
                view.BindingContext = viewModel;

                await Application.Current.MainPage.Navigation.PushModalAsync(view);
            }); }
        }

        public Command EditarDepartamento {
            get { 
                return new Command(async (Departamento) => {
                    Departamento departamento = Departamento as Departamento;
                    DepartamentoViewModel viewModel = App.ServiceLocator.DepartamentoViewModel;
                    viewModel.Departamento = departamento;
                    EditDepartamentoView view = new EditDepartamentoView();
                    view.BindingContext = viewModel;

                    await Application.Current.MainPage.Navigation.PushModalAsync(view);

                }); 
            }
        }

    }

}

