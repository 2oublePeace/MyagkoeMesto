using MebelBusinessLogic.BusinessLogic;
using MebelBusinessLogic.BusinessLogics;
using System;
using System.Windows;
using Unity;

namespace MebelProviderView
{
	/// <summary>
	/// Логика взаимодействия для LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ProviderLogic logic;

        public LoginWindow(ProviderLogic logic)
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
            var window = Container.Resolve<EntryWindow>();
            window.Show();
            Close();
        }
    }
}
