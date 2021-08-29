using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace MebelProviderView
{
	/// <summary>
	/// Логика взаимодействия для CreateSupplyWindow.xaml
	/// </summary>
	public partial class CreateSupplyWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        SupplyLogic _logicSupply;
        MaterialLogic _logicMaterial;
        public int Id { set { id = value; } }
        private int? id;
        private decimal sum = 0;
        private Dictionary<int, (string, int)> supplyMaterials;

        public CreateSupplyWindow(SupplyLogic logicSupply, MaterialLogic logicMaterial)
        {
            InitializeComponent();
            _logicSupply = logicSupply;
            _logicMaterial = logicMaterial;
        }

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SupplyViewModel view = _logicSupply.Read(new SupplyBindingModel
                    {
                        Id = id.Value
                    })?[0];

					if (view != null)
					{
						tbSupplyPrice.Text = view.Price.ToString();
                        sum = view.Price;
						tbSupplyName.Text = view.Name;
						supplyMaterials = view.SupplyMaterials;
						LoadData();
					}
				}
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                supplyMaterials = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (supplyMaterials != null)
                {
                    List<ModuleMaterialViewModel> list = new List<ModuleMaterialViewModel>();

                    foreach (var material in supplyMaterials)
                    {
                        list.Add(new ModuleMaterialViewModel { Id = material.Key, MaterialName = material.Value.Item1, MaterialCount = material.Value.Item2 });
                    }

                    tbSupplyPrice.Text = sum.ToString();
                    dgSupplyMaterials.ItemsSource = list;
                    dgSupplyMaterials.Columns[0].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
				_logicSupply.CreateOrUpdate(new SupplyBindingModel
				{
					Id = id,
					Name = tbSupplyName.Text,
                    Date = DateTime.Now,
					Price = Convert.ToDecimal(tbSupplyPrice.Text),
                    SupplyMaterials = supplyMaterials
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
            Close();
        }

        private void btnAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<AddMaterialWindow>();
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                if (!supplyMaterials.ContainsKey(window.Id))
                {
                    supplyMaterials.Add(window.Id, (window.MaterialName, window.MaterialCount));
                }

                sum += _logicMaterial.Read(new MaterialBindingModel { Id = window.Id })[0].Price * window.MaterialCount;
            }
            LoadData();
        }


        private void btnDeleteMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (dgSupplyMaterials.SelectedIndex != -1)
            {
                MessageBoxResult result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ModuleMaterialViewModel material = (ModuleMaterialViewModel)dgSupplyMaterials.SelectedCells[0].Item;
                    try
                    {
                        supplyMaterials.Remove(material.Id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    sum -= _logicMaterial.Read(new MaterialBindingModel { Id = material.Id })[0].Price * material.MaterialCount;
                    LoadData();
                }
            }

        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
        }

        public static string GetPropertyDisplayName(object descriptor)
        {
            PropertyDescriptor pd = descriptor as PropertyDescriptor;
            if (pd != null)
            {
                DisplayNameAttribute displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }
            }
            else
            {
                PropertyInfo pi = descriptor as PropertyInfo;
                if (pi != null)
                {
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        DisplayNameAttribute displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }
            return null;
        }
    }
}
