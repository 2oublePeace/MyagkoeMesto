using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class GarnitureViewModel
	{
		public int Id { get; set; }
		[DisplayName("Название изделия")]
		public string Name { get; set; }
		[DisplayName("Цена")]
		public decimal Price { get; set; }
		[DisplayName("Источник")]
		public Dictionary<int, (string, int)> GarnitureMaterials { get; set; }
		[DisplayName("Источник")]
		public Dictionary<int, (string, int)> GarnitureMebels { get; set; }
	}
}
