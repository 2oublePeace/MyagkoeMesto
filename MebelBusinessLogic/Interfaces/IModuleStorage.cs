using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

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
