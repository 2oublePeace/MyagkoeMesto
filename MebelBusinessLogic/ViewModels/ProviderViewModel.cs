using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ProviderViewModel
	{
		public int Id { get; set; }
		[DisplayName("Имя заказчика")]
		public string FullName { get; set; }
		public string Password { get; set; }
	}
}
