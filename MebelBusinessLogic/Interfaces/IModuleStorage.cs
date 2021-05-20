using System;
using System.Collections.Generic;
using System.Text;
using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.ViewModels;

namespace MebelBusinessLogic.Interfaces
{
	public interface IModuleStorage
	{
		List<ModuleViewModel> GetFullList();
		List<ModuleViewModel> GetFilteredList(ModuleBindingModel model);
		ModuleViewModel GetElement(ModuleBindingModel model);
		void Insert(ModuleBindingModel model);
		void Update(ModuleBindingModel model);
		void Delete(ModuleBindingModel model);
	}
}
