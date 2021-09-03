using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.HelperModels
{
	public class PdfCustomerInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		public List<ReportShipmentViewModel> Shipments { get; set; }
	}
}
