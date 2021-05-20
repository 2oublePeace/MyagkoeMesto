using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportModuleMaterialViewModel
	{
		public string ModuleName { get; set; }
		public int TotalCount { get; set; }
		public List<Tuple<string, int>> Materials { get; set; }
	}
}

