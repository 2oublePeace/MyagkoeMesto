using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace MebelBusinessLogic.BusinessLogics
{
	public class SupplyLogic
	{
		private readonly ISupplyStorage _supplyStorage;

		public SupplyLogic(ISupplyStorage supplyStorage)
		{
			_supplyStorage = supplyStorage;
		}

        public List<SupplyViewModel> Read(SupplyBindingModel model)
        {
            if (model == null)
            {
                return _supplyStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SupplyViewModel> { _supplyStorage.GetElement(model) };
            }
            return _supplyStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SupplyBindingModel model)
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
        public void Delete(SupplyBindingModel model)
        {
            var receipt = _supplyStorage.GetElement(new SupplyBindingModel
            {
                Id = model.Id
            });
            if (receipt == null)
            {
                throw new Exception("Поступление не найдено");
            }
            _supplyStorage.Delete(model);
        }
    }
}
