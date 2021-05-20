using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ModuleViewModel
	{
		public int Id { get; set; }
		[DisplayName("Название изделия")]
		public string ModuleName { get; set; }
		[DisplayName("Цена")]
		public decimal Price { get; set; }
		[DisplayName("Источник")]
		public Dictionary<int, (string, int)> ModuleMaterials { get; set; }
	}
}
