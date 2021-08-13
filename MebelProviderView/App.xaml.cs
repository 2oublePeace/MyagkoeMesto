using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.Interfaces;
using MebelDatabaseImplement.Implements;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace MebelProviderView
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IProviderStorage, ProviderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProviderLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IMaterialStorage, MaterialStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MaterialLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IModuleStorage, ModuleStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ModuleLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = BuildUnityContainer();
            var welcomeWindow = container.Resolve<EntryWindow>();
            welcomeWindow.Show();
        }
    }
}
