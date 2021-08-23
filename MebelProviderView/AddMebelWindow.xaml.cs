using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.ViewModels;
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
	/// Логика взаимодействия для AddMebelWindow.xaml
	/// </summary>
	public partial class AddMebelWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        MebelLogic _logic;
        private MebelViewModel mebelViewModel;
        public int Id
        {
            get
            {
                return mebelViewModel.Id;
            }
            set
            {
                cbMebels.SelectedItem = value;
            }
        }
        public string MebelName { get { return cbMebels.Text; } }

        public int MebelCount
        {
            get { return Convert.ToInt32(tbCount.Text); }
            set
            {
                tbCount.Text = value.ToString();
            }
        }

        public AddMebelWindow(MebelLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            var list = _logic.Read(null);
            if (list.Count > 0)
            {
                try
                {
                    cbMebels.DisplayMemberPath = "Name";
                    cbMebels.ItemsSource = list;
                    cbMebels.SelectedItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbMebels.SelectedValue == null)
                {
                    MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (tbCount.Text == null)
                {
                    MessageBox.Show("Введите количество материала", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                mebelViewModel = (MebelViewModel)cbMebels.SelectionBoxItem;
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
            Close();
        }
    }
}
