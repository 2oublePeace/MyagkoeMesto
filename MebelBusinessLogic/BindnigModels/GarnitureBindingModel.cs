using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindnigModels
{
	public class GarnitureBindingModel
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public Dictionary<int, (string, int)> GarnitureMaterials { get; set; }
		public Dictionary<int, (string, int)> GarnitureMebels { get; set; }
	}
}
