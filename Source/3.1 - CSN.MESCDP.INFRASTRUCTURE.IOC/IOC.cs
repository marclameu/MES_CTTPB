using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using CTTPB.MESCDP.Domain;
using CTTPB.MESCDP.Domain.Interfaces.Repositories;
using CTTPB.MESCDP.Infrastructure.Data;
using CTTPB.MESCDP.Infrastructure.Data.Repositories;

namespace CTTPB.MESCDP.Infrastructure.IOC
{
    public class IOC
    {
        public static ContainerBuilder Builder;
        public static IContainer Container;

        public static IContainer Start()
        {
            Builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

            var assemblyRepository = Assembly.GetAssembly(typeof(GenericRepository<>));
            Builder.RegisterAssemblyTypes(assemblyRepository).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            var assemblyServices = Assembly.GetAssembly(typeof(AbstractService));
            Builder.RegisterAssemblyTypes(assemblyServices).Where(t => t.Name.EndsWith("Services")).AsImplementedInterfaces().EnableClassInterceptors().InterceptedBy(typeof(TransactionInterceptor));

            //Builder.Register(context => new CustomSettings());
            Builder.Register(s => new TransactionInterceptor());
            Container = Builder.Build();
            return Container;
        }
    }
}
