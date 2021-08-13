using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindingModels
{
	public class ModuleBindingModel
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public Dictionary<int, (string, int)> ModuleMaterials { get; set; }
	}
}
