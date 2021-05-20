using MebelBusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
	/// Логика взаимодействия для Enter.xaml
	/// </summary>
	public partial class Enter : Window
	{
        [Unity.Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly CustomerLogic logic;
        public Enter(CustomerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.Text))
            {
                MessageBox.Show("Введите имя пользователя", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Выберите пароль", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                int customerId = logic.CheckPassword(tbUserName.Text, tbPassword.Text);
                var window = Container.Resolve<MainWindow>();
                window._customerId = customerId;
                window.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WelcomeWindow>();
            window.Show();
            Close();
        }
    }
}
