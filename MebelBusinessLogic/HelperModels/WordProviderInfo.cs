using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.HelperModels
{
	public class WordProviderInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<ReportShipmentMaterialsViewModel> Shipments { get; set; }
	}
}
