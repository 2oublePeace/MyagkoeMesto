using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.Interfaces;
using MebelDatabaseImplement.Implements;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace MebelCustomerView
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomerStorage, CustomerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CustomerLogic>(new HierarchicalLifetimeManager());

			currentContainer.RegisterType<IMebelStorage, MebelStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<MebelLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IGarnitureStorage, GarnitureStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<GarnitureLogic>(new HierarchicalLifetimeManager());


            return currentContainer;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = BuildUnityContainer();
            var welcomeWindow = container.Resolve<WelcomeWindow>();
            welcomeWindow.Show();
        }
    }
}