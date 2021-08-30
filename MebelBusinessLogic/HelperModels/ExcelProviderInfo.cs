using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.HelperModels
{
	class ExcelProviderInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<ReportShipmentSupplysViewModel> Shipments { get; set; }
	}
}
