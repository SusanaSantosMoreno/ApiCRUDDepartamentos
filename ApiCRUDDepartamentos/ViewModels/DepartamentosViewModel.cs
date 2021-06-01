using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ApiCRUDDepartamentos.Base;
using ApiCRUDDepartamentos.Models;
using ApiCRUDDepartamentos.Services;
using Xamarin.Forms;

namespace ApiCRUDDepartamentos.ViewModels {
    public class DepartamentosViewModel : ViewModelBase {

        ServiceDepartamentos service;

        public DepartamentosViewModel(ServiceDepartamentos serv) {
            this.service = serv;
            Task.Run(async () => {
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
                await Application.Current.MainPage.DisplayAlert("Alert",
                    "Detalles -> " + departamento.Localidad, "OK");
            }); }
        }

        public Command ModificarDepartamento {
            get { return new Command(async (Departamento) => {
                Departamento departamento = Departamento as Departamento;
                await Application.Current.MainPage.DisplayAlert("Alert",
                    "Modificar -> " + departamento.Localidad, "OK");
            }); }
        }

    }

}

