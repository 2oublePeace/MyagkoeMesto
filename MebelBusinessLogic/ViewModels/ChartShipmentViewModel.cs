using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ChartShipmentViewModel
	{
		[DisplayName("Отгрузка")]
		public string ShipmentName { get; set; }
		[DisplayName("Количество гарнитуров")]
		public int GarnitureCount { get; set; }
	}
}
