using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BindnigModels
{
	public class ReportProviderBindingModel
	{
		public string FileName { get; set; }
		public int ProviderId { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
	}
}
