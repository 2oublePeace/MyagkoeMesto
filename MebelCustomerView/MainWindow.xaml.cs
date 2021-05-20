using MebelDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;

namespace MebelCustomerView
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
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
            /*var window = Container.Resolve<Treatments>();
            window.Show();*/
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
