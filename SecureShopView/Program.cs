using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.Interfaces;
using SecureShopDatabaseImplement.Implements;
using Unity.Lifetime;

namespace SecureShopView
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var container = BuildUnityContainer();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.Resolve<FormMain>());
		}

		private static IUnityContainer BuildUnityContainer()
		{
			var currentContainer = new UnityContainer();
			currentContainer.RegisterType<IMaterialStorage, MaterialStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ISupplyStorage, SupplyStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IModuleStorage, ModuleStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<MaterialLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<SupplyLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ModuleLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
			return currentContainer;
		}
	}
}
