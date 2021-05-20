using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.HelperModels
{
	class ExcelInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<ReportModuleMaterialViewModel> ModuleMaterials { get; set; }
	}
}

