using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class MaterialViewModel
	{
		public int Id { get; set; }
		[DisplayName("Название устройства")]
		public string MaterialName { get; set; }
		[DisplayName("Цена")]
		public string Price { get; set; }
	}
}
