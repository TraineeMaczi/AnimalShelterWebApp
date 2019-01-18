using Ninject;
using Repository.Abstract;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            // Initialize kernel and add bindings
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Bindings added here
            #region Repositories
            kernel.Bind<ISubscriberRepository>().To<SubscriberRepository>();
<<<<<<< HEAD
            kernel.Bind<IItemRepository>().To<ItemRepository>();
=======
>>>>>>> f432d7f93dd54f3cd3a15f28835ad2e2c02ee184
            #endregion
        }
    }
   
}