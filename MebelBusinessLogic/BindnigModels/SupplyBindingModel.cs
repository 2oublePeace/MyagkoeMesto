using MebelBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindingModels
{
	/// <summary>
	/// Заказ
	/// </summary>
	public class SupplyBindingModel
	{
		public int? Id { get; set; }
		public int MaterialId { get; set; }
		public int Count { get; set; }
		public decimal Sum { get; set; }
		public SupplyStatus Status { get; set; }
		public DateTime DateCreate { get; set; }
		public DateTime? DateImplement { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }

	}
}
