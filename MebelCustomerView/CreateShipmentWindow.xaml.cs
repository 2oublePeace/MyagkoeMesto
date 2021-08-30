using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.BusinessLogic;
using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace MebelCustomerView
{
	/// <summary>
	/// Логика взаимодействия для CreateShipmentWindow.xaml
	/// </summary>
	public partial class CreateShipmentWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        ShipmentLogic _logicShipment;
        GarnitureLogic _logicGarniture;
        public int Id { set { id = value; } }
        private int? id;
        private decimal sum = 0;
        private Dictionary<int, (string, int)> shipmentGarnitures;

        public CreateShipmentWindow(ShipmentLogic logicShipment, GarnitureLogic logicGarniture)
        {
            InitializeComponent();
            _logicShipment = logicShipment;
            _logicGarniture = logicGarniture;
        }

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ShipmentViewModel view = _logicShipment.Read(new ShipmentBindingModel
                    {
                        Id = id.Value
                    })?[0];

                    if (view != null)
                    {
                        tbShipmentPrice.Text = view.Price.ToString();
                        sum = view.Price;
                        tbShipmentName.Text = view.Name;
                        shipmentGarnitures = view.ShipmentGarnitures;
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
                shipmentGarnitures = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (shipmentGarnitures != null)
                {
                    List<ModuleMaterialViewModel> list = new List<ModuleMaterialViewModel>();

                    foreach (var material in shipmentGarnitures)
                    {
                        list.Add(new ModuleMaterialViewModel { Id = material.Key, MaterialName = material.Value.Item1, MaterialCount = material.Value.Item2 });
                    }

                    tbShipmentPrice.Text = sum.ToString();
                    dgShipmentMaterial.ItemsSource = list;
                    dgShipmentMaterial.Columns[0].Visibility = Visibility.Hidden;
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
                _logicShipment.CreateOrUpdate(new ShipmentBindingModel
                {
                    Id = id,
                    Name = tbShipmentName.Text,
                    Date = DateTime.Now,
                    Price = Convert.ToDecimal(tbShipmentPrice.Text),
                    ShipmentGarnitures = shipmentGarnitures
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
            var window = Container.Resolve<AddGarnitureWindow>();
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                if (!shipmentGarnitures.ContainsKey(window.Id))
                {
                    shipmentGarnitures.Add(window.Id, (window.GarnitureName, window.GarnitureCount));
                }

                sum += _logicGarniture.Read(new GarnitureBindingModel { Id = window.Id })[0].Price * window.GarnitureCount;
            }
            LoadData();
        }


        private void btnDeleteMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (dgShipmentMaterial.SelectedIndex != -1)
            {
                MessageBoxResult result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ModuleMaterialViewModel material = (ModuleMaterialViewModel)dgShipmentMaterial.SelectedCells[0].Item;
                    try
                    {
                        shipmentGarnitures.Remove(material.Id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    sum -= _logicGarniture.Read(new GarnitureBindingModel { Id = material.Id })[0].Price * material.MaterialCount;
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
