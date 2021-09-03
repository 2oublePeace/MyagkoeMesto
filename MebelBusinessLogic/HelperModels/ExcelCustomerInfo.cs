using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.HelperModels
{
	public class ExcelCustomerInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<ReportSupplyGarnituresViewModel> Supplys { get; set; }
	}
}
