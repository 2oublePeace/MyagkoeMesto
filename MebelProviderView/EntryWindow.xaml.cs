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

namespace MebelProviderView
{
	/// <summary>
	/// Логика взаимодействия для EntryWindow.xaml
	/// </summary>
	public partial class EntryWindow : Window
	{
        [Dependency]
        public IUnityContainer Container { get; set; }

        public EntryWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<LoginWindow>();
            window.Show();
            Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<RegistrationWindow>();
            window.Show();
            Close();
        }
    }
}
