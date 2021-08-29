using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindnigModels
{
	public class ShipmentBindingModel
	{
		public int? Id { get; set; }
		public decimal Price { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public Dictionary<int, (string, int)> ShipmentGarnitures { get; set; }
	}
}
