using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.Interfaces
{
	public interface ISupplyStorage
	{
		List<SupplyViewModel> GetFullList();
		List<SupplyViewModel> GetFilteredList(SupplyBindingModel model);
		SupplyViewModel GetElement(SupplyBindingModel model);
		void Insert(SupplyBindingModel model);
		void Update(SupplyBindingModel model);
		void Delete(SupplyBindingModel model);
	}
}
