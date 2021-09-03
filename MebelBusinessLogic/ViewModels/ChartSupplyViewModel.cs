using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ChartSupplyViewModel
	{
		[DisplayName("Поставка")]
		public string SupplyName { get; set; }
		[DisplayName("Количество материалов")]
		public int MaterialCount { get; set; }
	}
}
