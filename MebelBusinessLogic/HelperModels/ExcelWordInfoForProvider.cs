using MebelBusinessLogic.BusinessLogic;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.HelperModels
{
	public class ExcelWordInfoForProvider
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<ReportSupplyViewModel> Supplys { get; set; }
	}
}
