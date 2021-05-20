using MebelBusinessLogic.BusinessLogic;
using MebelBusinessLogic.Interfaces;
using MebelDatabaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            /*лечение currentContainer.RegisterType<ITreatment, TreatmentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<TreatmentLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IProcedure, ProcedureStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProcedureLogic>(new HierarchicalLifetimeManager());
          
            currentContainer.RegisterType<IPatient, PatientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PatientLogic>(new HierarchicalLifetimeManager());
     
            currentContainer.RegisterType<IMedicine, MedicineStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MedicineLogic>(new HierarchicalLifetimeManager());
      
            currentContainer.RegisterType<IReceipt, ReceiptStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReceiptLogic>(new HierarchicalLifetimeManager());
       
            currentContainer.RegisterType<ReceiptReportLogic>(new HierarchicalLifetimeManager());*/

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
