[assembly: WebActivator.PostApplicationStartMethod(typeof(UnitOfWork.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace UnitOfWork.App_Start
{
    using Microsoft.EntityFrameworkCore;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Configuration;
    using System.Reflection;
    using System.Web.Mvc;
    using UnitOfWork.Models;
    using UnitOfWork.Services;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {

            // For instance: 
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            string connectionString = ConfigurationManager.ConnectionStrings["PresupuestoConnectionString"].ConnectionString;

            container.Register(() => new PresupuestoContext(new DbContextOptionsBuilder<PresupuestoContext>().UseSqlServer(connectionString).Options), Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}