using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogic
{
	public class ShipmentLogic
	{
		private readonly IShipmentStorage _supplyStorage;

		public ShipmentLogic(IShipmentStorage supplyStorage)
		{
			_supplyStorage = supplyStorage;
		}

        public List<ShipmentViewModel> Read(ShipmentBindingModel model)
        {
            if (model == null)
            {
                return _supplyStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ShipmentViewModel> { _supplyStorage.GetElement(model) };
            }
            return _supplyStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ShipmentBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _supplyStorage.Update(model);
            }
            else
            {
                _supplyStorage.Insert(model);
            }
        }
        public void Delete(ShipmentBindingModel model)
        {
            var shipment = _supplyStorage.GetElement(new ShipmentBindingModel
            {
                Id = model.Id
            });
            if (shipment == null)
            {
                throw new Exception("Поступление не найдено");
            }
            _supplyStorage.Delete(model);
        }
	}
}
