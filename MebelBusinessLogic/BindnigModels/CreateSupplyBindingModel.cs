using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindingModels
{
	public class CreateSupplyBindingModel
	{
		public int MaterialId { get; set; }
		public string ModuleName { get; set; }
		public int Count { get; set; }
		public decimal Sum { get; set; }
	}
}
