using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindnigModels
{
	public class CustomerBindingModel
	{
		public int? Id { get; set; }
		public string FullName { get; set; }
		public string Password { get; set; }
	}
}
