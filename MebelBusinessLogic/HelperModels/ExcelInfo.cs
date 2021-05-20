using System;
using System.Collections.Generic;
using System.Text;
using MebelBusinessLogic.ViewModels;

namespace MebelBusinessLogic.HelperModels
{
	class ExcelInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<ReportModuleMaterialViewModel> ModuleMaterials { get; set; }
	}
}

