using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ModuleMebelViewModel
	{
		public int Id { get; set; }
		[DisplayName("Название мебели")]
		public string MebelName { get; set; }
		[DisplayName("Количество мебели")]
		public int MebelCount { get; set; }
	}
}
