﻿using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
	/// Логика взаимодействия для CreateModuleWindow.xaml
	/// </summary>
	public partial class CreateModuleWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        ModuleLogic _logicModule;
        MaterialLogic _logicMaterial; 
        public int Id { set { id = value; } }
        private int? id;
        private decimal sum = 0;
        private Dictionary<int, (string, int)> moduleMaterials;

        public CreateModuleWindow(ModuleLogic logicModule, MaterialLogic medicineLogic)
        {
            InitializeComponent();
            _logicModule = logicModule;
            _logicMaterial = medicineLogic;
        }

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ModuleViewModel view = _logicModule.Read(new ModuleBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        sum = view.Price;
                        tbModuleName.Text = view.Name;
                        moduleMaterials = view.ModuleMaterials;
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
                moduleMaterials = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
			try
			{
				if (moduleMaterials != null)
				{
					List<ModuleMaterialViewModel> list = new List<ModuleMaterialViewModel>();

					foreach (var material in moduleMaterials)
					{
						list.Add(new ModuleMaterialViewModel { Id = material.Key, MaterialName = material.Value.Item1, MaterialCount = material.Value.Item2 });
                    }

                    tbModulePrice.Text = sum.ToString();
                    dgReceiptMedicine.ItemsSource = list;
					dgReceiptMedicine.Columns[0].Visibility = Visibility.Hidden;
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
				_logicModule.CreateOrUpdate(new ModuleBindingModel
				{
					Id = id,
					Name = tbModuleName.Text,
                    Price = Convert.ToDecimal(tbModulePrice.Text),
					ModuleMaterials = moduleMaterials
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
                if (!moduleMaterials.ContainsKey(window.Id))
                {
                    moduleMaterials.Add(window.Id, (window.MaterialName, window.MaterialCount));
                }

                sum += _logicMaterial.Read(new MaterialBindingModel { Id = window.Id })[0].Price * window.MaterialCount;
			}
			LoadData();
		}


        private void btnDeleteMaterial_Click(object sender, RoutedEventArgs e)
        {
			if (dgReceiptMedicine.SelectedIndex != -1)
			{
				MessageBoxResult result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

				if (result == MessageBoxResult.Yes)
				{
					ModuleMaterialViewModel material = (ModuleMaterialViewModel)dgReceiptMedicine.SelectedCells[0].Item;
					try
					{
                        moduleMaterials.Remove(material.Id);
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
