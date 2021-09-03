using LiveCharts;
using LiveCharts.Wpf;
using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.BusinessLogic;
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

namespace MebelCustomerView
{
	/// <summary>
	/// Логика взаимодействия для ChartWindow.xaml
	/// </summary>
	public partial class ChartWindow : Window
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        ShipmentLogic _logic;

        private List<ChartShipmentViewModel> _shipments = new List<ChartShipmentViewModel>();

        public ChartWindow(ShipmentLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void LoadData()
        {
            _shipments.Clear();
            List<ShipmentViewModel> shipments = _logic.Read(new ShipmentBindingModel { DateTo = dpTo.SelectedDate, DateFrom = dpFrom.SelectedDate });
            foreach (var shipment in shipments)
            {
                int count = 0;
                foreach(var garniture in shipment.ShipmentGarnitures)
				{
                    count += garniture.Value.Item2;
				}
				_shipments.Add(new ChartShipmentViewModel { ShipmentName = shipment.Name, GarnitureCount = count });
            }
            DataGridView.ItemsSource = _shipments;
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
            Build(_shipments);
        }

        private void Build(List<ChartShipmentViewModel> statistic)
        {
            SeriesCollection series = new SeriesCollection();
            List<string> shipmentName = new List<string>();
            ChartValues<int> garnitureCount = new ChartValues<int>();

            foreach (var item in statistic)
            {
                shipmentName.Add(item.ShipmentName);
                garnitureCount.Add(item.GarnitureCount);
            }

            Graph.AxisX.Clear();
            Graph.AxisX.Add(new Axis()

            {
                Title = "\nОтгрузки",
                Labels = shipmentName
            });

            LineSeries garnitureLine = new LineSeries
            {
                Title = "Кол-во гарнитуров: ",
                Values = garnitureCount
            };

            series.Add(garnitureLine);
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
