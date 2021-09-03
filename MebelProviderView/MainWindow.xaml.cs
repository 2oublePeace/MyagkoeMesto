using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace MebelProviderView
{
	public partial class MainWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int _customerId { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMaterials_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<MaterialsWindow>();
            window.Show();
        }

        private void btnReportShipmentList_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<ShipmentListWindow>();
            window.Show();
        }

        private void btnReportSupplys_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<ReportSupplysWindow>();
            window.Show();
        }

        private void btnModules_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<ModulesWindow>();
            window.Show();
        }

        private void btnSupplys_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<SupplysWindow>();
            window.Show();
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<ChartWindow>();
            window.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<MainWindow>();
            MessageBoxResult result = MessageBox.Show("Выйти из учетной записи?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                window.Show();
                Close();
            }
        }
    }
}
