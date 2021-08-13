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
	/// Логика взаимодействия для AddMaterialWindow.xaml
	/// </summary>
	public partial class AddMaterialWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        MaterialLogic _logic;
        private MaterialViewModel materialViewModel;
        public int Id
        {
            get
            {
                return materialViewModel.Id;
            }
            set
            {
                cbMaterials.SelectedItem = value;
            }
        }
        public string MaterialName { get { return cbMaterials.Text; } }

        public int MaterialCount
        {
            get { return Convert.ToInt32(tbCount.Text); }
            set
            {
                tbCount.Text = value.ToString();
            }
        }

        public AddMaterialWindow(MaterialLogic logic)
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
                    cbMaterials.DisplayMemberPath = "Name";
                    cbMaterials.ItemsSource = list;
                    cbMaterials.SelectedItem = null;
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
                if (cbMaterials.SelectedValue == null)
                {
                    MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (tbCount.Text == null)
                {
                    MessageBox.Show("Введите количество материала", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                materialViewModel = (MaterialViewModel)cbMaterials.SelectionBoxItem;
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
