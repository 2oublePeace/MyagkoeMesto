using MebelBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportOrdersViewModel
	{
		public DateTime DateCreate { get; set; }
		public string ModuleName { get; set; }
		public int Count { get; set; }
		public decimal Sum { get; set; }
		public SupplyStatus Status { get; set; }
	}
}

