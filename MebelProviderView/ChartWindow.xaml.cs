using LiveCharts;
using LiveCharts.Wpf;
using MebelBusinessLogic.BindingModels;
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
	/// Логика взаимодействия для ChartWindow.xaml
	/// </summary>
	public partial class ChartWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        SupplyLogic _logic;

        private List<ChartSupplyViewModel> _supplys = new List<ChartSupplyViewModel>();

        public ChartWindow(SupplyLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void LoadData()
        {
            _supplys.Clear();
            List<SupplyViewModel> supplys = _logic.Read(new SupplyBindingModel { DateTo = dpTo.SelectedDate, DateFrom = dpFrom.SelectedDate });
            foreach (var supply in supplys)
            {
                int count = 0;
                foreach (var material in supply.SupplyMaterials)
                {
                    count += material.Value.Item2;
                }
                _supplys.Add(new ChartSupplyViewModel { SupplyName = supply.Name, MaterialCount = count });
            }
            DataGridView.ItemsSource = _supplys;
            DataGridView.Items.Refresh();
        }

        private void BuildGraph_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату начала",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dpTo.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату окончания",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dpFrom.SelectedDate >= dpTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            LoadData();
            Build(_supplys);
        }

        private void Build(List<ChartSupplyViewModel> statistic)
        {
            SeriesCollection series = new SeriesCollection();
            List<string> supplyName = new List<string>();
            ChartValues<int> materialCount = new ChartValues<int>();

            foreach (var item in statistic)
            {
                supplyName.Add(item.SupplyName);
                materialCount.Add(item.MaterialCount);
            }

            Graph.AxisX.Clear();
            Graph.AxisX.Add(new Axis()

            {
                Title = "\nОтгрузки",
                Labels = supplyName
            });

            LineSeries materialLine = new LineSeries
            {
                Title = "Кол-во гарнитуров: ",
                Values = materialCount
            };

            series.Add(materialLine);
            Graph.Series = series;
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
