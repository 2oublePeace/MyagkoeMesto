using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class GarnitureViewModel
	{
		public int Id { get; set; }
		[DisplayName("Название гарнитура")]
		public string Name { get; set; }
	}
}
