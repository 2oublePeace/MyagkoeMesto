using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.BusinessLogics;
using System;
using System.Windows;
using Unity;

namespace MebelCustomerView
{
	/// <summary>
	/// Логика взаимодействия для AddMebel.xaml
	/// </summary>
	public partial class CreateMebelWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        MebelLogic _logic;
        public int Id { set { id = value; } }
        private int? id;
        public CreateMebelWindow(MebelLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new MebelBindingModel
                {
                    Id = id,
                    Name = tbName.Text,
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }
    }
}
