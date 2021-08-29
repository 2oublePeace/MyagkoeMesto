using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.Interfaces
{
	public interface IShipmentStorage
	{
		List<ShipmentViewModel> GetFullList();
		List<ShipmentViewModel> GetFilteredList(ShipmentBindingModel model);
		ShipmentViewModel GetElement(ShipmentBindingModel model);
		void Insert(ShipmentBindingModel model);
		void Update(ShipmentBindingModel model);
		void Delete(ShipmentBindingModel model);
	}
}
