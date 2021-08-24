using MebelBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindingModels
{
	public class SupplyBindingModel
	{
		public int? Id { get; set; }
		public decimal Price { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public Dictionary<int, (string, int)> SupplyMaterials { get; set; }
	}
}
