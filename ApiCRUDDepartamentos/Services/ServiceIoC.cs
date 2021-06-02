using System;
using ApiCRUDDepartamentos.ViewModels;
using Autofac;

namespace ApiCRUDDepartamentos.Services {
    public class ServiceIoC {

        private IContainer container;

        public ServiceIoC () {
            this.RegisterDependencies();
        }

        private void RegisterDependencies () {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ServiceDepartamentos>();
            builder.RegisterType<DepartamentosViewModel>();
            builder.RegisterType<DepartamentoViewModel>();
            this.container = builder.Build();
        }

        public DepartamentoViewModel DepartamentoViewModel {
            get { return this.container.Resolve<DepartamentoViewModel>(); }
        }

        public DepartamentosViewModel DepartamentosViewModel {
            get { return this.container.Resolve<DepartamentosViewModel>(); }
        }
    }
}
