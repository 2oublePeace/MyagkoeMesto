using System;
using System.Collections.Generic;
using System.Text;
using MebelBusinessLogic.ViewModels;

namespace MebelBusinessLogic.HelperModels
{
	class WordInfo
	{
		public string FileName { get; set; }
		public string Title { get; set; }
		public List<ModuleViewModel> Modules { get; set; }
	}
}
