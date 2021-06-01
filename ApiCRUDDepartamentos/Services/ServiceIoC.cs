using System;
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
            this.container = builder.Build();
        }
    }
}
