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
using System.Windows.Forms;
using Unity;

namespace MebelCustomerView
{
	/// <summary>
	/// Логика взаимодействия для SupplyListView.xaml
	/// </summary>
	public partial class SupplyListWindow : Window
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		GarnitureLogic logicGarnitures;
		ReportSupplyGarnituresLogic logicP;
		List<GarnitureViewModel> list = new List<GarnitureViewModel>();

		public SupplyListWindow(ReportSupplyGarnituresLogic _logicP, GarnitureLogic _logicM)
		{
			InitializeComponent();
			logicGarnitures = _logicM;
			logicP = _logicP;
		}

		private void LoadData()
		{
			try
			{
				if (list != null)
				{
					DataGridView.ItemsSource = list;
					DataGridView.Items.Refresh();
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadData();
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			var window = Container.Resolve<AddGarnitureWindow>();
			window.ShowDialog();
			if (window.DialogResult == true)
			{
				if (!list.Contains(logicGarnitures.Read(new GarnitureBindingModel { Id = window.Id })[0]))
				{
					list.Add(logicGarnitures.Read(new GarnitureBindingModel { Id = window.Id })[0]);
					LoadData();
				}
			}
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			if (DataGridView.SelectedIndex != -1)
			{
				MessageBoxResult result = System.Windows.MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

				if (result == MessageBoxResult.Yes)
				{
					GarnitureViewModel material = (GarnitureViewModel)DataGridView.SelectedCells[0].Item;
					try
					{
						list.Remove(material);
					}
					catch (Exception ex)
					{
						System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
					}
					LoadData();
				}
			}
		}

		private void SaveToWord_Click(object sender, RoutedEventArgs e)
		{
			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{
				if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						logicP.SaveToWordFile(dialog.FileName, list);
						System.Windows.MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK,
							MessageBoxImage.Information);
					}
					catch (Exception ex)
					{
						System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
			}
		}

		private void SaveToExcel_Click(object sender, RoutedEventArgs e)
		{
			using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
			{
				if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						logicP.SaveToExcelFile(dialog.FileName, list);
						System.Windows.MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK,
						MessageBoxImage.Information);
					}
					catch (Exception ex)
					{
						System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
					   MessageBoxImage.Error);
					}
				}
			}
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
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
