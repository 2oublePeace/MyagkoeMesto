using System.Windows;
using Unity;

namespace MebelCustomerView
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

        private void btnMebel_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<MebelWindow>();
            window.Show();
        }

        private void btnGarniture_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<GarnitureWindow>();
            window.Show();
        }

        private void btnShipment_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<ShipmentsWindow>();
            window.Show();
        }

        private void btnReportShipments_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<ReportShipmentsWindow>();
            window.Show();
        }

        private void btnReportSupplyList_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<SupplyListWindow>();
            window.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WelcomeWindow>();
            MessageBoxResult result = MessageBox.Show("Выйти из учетной записи?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                window.Show();
                Close();
            }
        }
    }
}