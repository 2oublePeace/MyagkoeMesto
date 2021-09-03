using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportShipmentViewModel
	{
		int Id { get; set; }
		[DisplayName("Поставка")]
		public string SupplyName { get; set; }
		[DisplayName("Отгрузка")]
		public string ShipmentName { get; set; }
		[DisplayName("Дата отгрузки")]
		public DateTime ShipmentDate { get; set; }
		[DisplayName("Дата поставки")]
		public DateTime SupplyDate { get; set; }
	}
}
