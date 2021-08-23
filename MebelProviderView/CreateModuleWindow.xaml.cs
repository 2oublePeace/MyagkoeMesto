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
	/// Логика взаимодействия для CreateModuleWindow.xaml
	/// </summary>
	public partial class CreateModuleWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        ModuleLogic _logicModule;
        MaterialLogic _logicMaterial; 
        MebelLogic _logicMebel; 
        public int Id { set { id = value; } }
        private int? id;
        private decimal sum = 0;
        private Dictionary<int, (string, int)> moduleMaterials;
        private Dictionary<int, (string, int)> moduleMebels;

        public CreateModuleWindow(ModuleLogic logicModule, MaterialLogic logicMaterial, MebelLogic logicMebel)
        {
            InitializeComponent();
            _logicModule = logicModule;
            _logicMaterial = logicMaterial;
            _logicMebel = logicMebel;
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
                moduleMebels = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
			try
			{
				if (moduleMaterials != null)
				{
                    List<ModuleMaterialViewModel> moduleMaterialList = new List<ModuleMaterialViewModel>();

                    foreach (var material in moduleMaterials)
                    {
                        moduleMaterialList.Add(new ModuleMaterialViewModel
                        {
                            Id = material.Key,
                            MaterialName = material.Value.Item1,
                            MaterialCount = material.Value.Item2
                        });
                    }

                    tbModulePrice.Text = sum.ToString();
                    dgModuleMaterials.ItemsSource = moduleMaterialList;
                    dgModuleMaterials.Columns[0].Visibility = Visibility.Hidden;
                }

                if (moduleMebels != null)
                {
                    List<ModuleMebelViewModel> moduleMebelList = new List<ModuleMebelViewModel>();

                    foreach (var mebel in moduleMebels)
                    {
                        moduleMebelList.Add(new ModuleMebelViewModel
                        {
                            Id = mebel.Key,
                            MebelName = mebel.Value.Item1,
                            MebelCount = mebel.Value.Item2
                        });
                    }

                    //tbModulePrice.Text = sum.ToString();
                    dgModuleMebels.ItemsSource = moduleMebelList;
                    dgModuleMebels.Columns[0].Visibility = Visibility.Hidden;
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
					ModuleMaterials = moduleMaterials,
                    ModuleMebels = moduleMebels
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
			if (dgModuleMaterials.SelectedIndex != -1)
			{
				MessageBoxResult result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

				if (result == MessageBoxResult.Yes)
				{
					ModuleMaterialViewModel material = (ModuleMaterialViewModel)dgModuleMaterials.SelectedCells[0].Item;
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

        private void btnAddMebel_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<AddMebelWindow>();
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                if (!moduleMebels.ContainsKey(window.Id))
                {
                    moduleMebels.Add(window.Id, (window.MebelName, window.MebelCount));
                }

                //sum += _logicMebel.Read(new MebelBindingModel { Id = window.Id })[0].Price * window.MaterialCount;
            }
            LoadData();
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
