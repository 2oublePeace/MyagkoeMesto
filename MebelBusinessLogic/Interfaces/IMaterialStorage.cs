using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace MebelBusinessLogic.Interfaces
{
	public interface IMaterialStorage
	{
		List<MaterialViewModel> GetFullList();
		List<MaterialViewModel> GetFilteredList(MaterialBindingModel model);
		MaterialViewModel GetElement(MaterialBindingModel model);
		void Insert(MaterialBindingModel model);
		void Update(MaterialBindingModel model);
		void Delete(MaterialBindingModel model);
	}
}
