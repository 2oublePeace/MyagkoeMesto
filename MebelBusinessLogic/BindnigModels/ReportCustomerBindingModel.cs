using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindnigModels
{
	public class ReportCustomerBindingModel
	{
		public string FileName { get; set; }
		public int SupplierId { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
	}
}
