using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ModuleMaterialViewModel
	{
		public int Id { get; set; }
		[DisplayName("Название материала")]
		public string MaterialName { get; set; }
		[DisplayName("Количество материала")]
		public int MaterialCount { get; set; }
	}
}
