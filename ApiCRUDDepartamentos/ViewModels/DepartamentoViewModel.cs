using ApiCRUDDepartamentos.Base;
using ApiCRUDDepartamentos.Models;
using ApiCRUDDepartamentos.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ApiCRUDDepartamentos.ViewModels {
    public class DepartamentoViewModel: ViewModelBase {

        ServiceDepartamentos service;

        public DepartamentoViewModel(ServiceDepartamentos serviceDepartamentos) {
            this.service = serviceDepartamentos;
            if(this.Departamento == null) {
                this.Departamento = new Departamento();
            }
        }

        private Departamento _Departamento;

        public Departamento Departamento {
            get { return this._Departamento; }
            set {
                this._Departamento = value;
                OnPropertyChanged("Departamento");
            }
        }


        public Command EliminarDepartamento {
            get { 
                return new Command(async () => {
                    await this.service.DeleteDepartamentoAsync(this.Departamento.IdDepartamento);

                    MessagingCenter.Send(App.ServiceLocator.DepartamentosViewModel, "Reload");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }); 
            }
        }

        public Command EditarDepartamento {
            get { 
                return new Command(async () => {
                    await this.service.UpdateDepartamentoAsync
                        (this.Departamento.IdDepartamento, this.Departamento.Nombre, 
                        this.Departamento.Localidad);

                    MessagingCenter.Send(App.ServiceLocator.DepartamentosViewModel, "Reload");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }); 
            }
        }

        public Command InsertarDepartamento {
            get { 
                return new Command(async () => {
                    await this.service.InsertDepartamentoAsync
                        (this.Departamento.IdDepartamento, this.Departamento.Nombre, 
                        this.Departamento.Localidad);
                    MessagingCenter.Send(App.ServiceLocator.DepartamentosViewModel, "Reload");
                    await Application.Current.MainPage.DisplayAlert("Alert", 
                        "Departamento " + this.Departamento.Nombre+ " insertado", "OK");
                }); 
            }
        }
    }
}
