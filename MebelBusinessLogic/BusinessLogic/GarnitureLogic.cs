using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace MebelBusinessLogic.BusinessLogics
{
	public class GarnitureLogic
	{
        private readonly IGarnitureStorage _garnitureStorage;

        public GarnitureLogic(IGarnitureStorage garnitureStorage)
        {
            _garnitureStorage = garnitureStorage;
        }

        public List<GarnitureViewModel> Read(GarnitureBindingModel model)
        {
            if (model == null)
            {
                return _garnitureStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GarnitureViewModel> { _garnitureStorage.GetElement(model) };
            }
            return _garnitureStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(GarnitureBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _garnitureStorage.Update(model);
            }
            else
            {
                _garnitureStorage.Insert(model);
            }
        }
        public void Delete(GarnitureBindingModel model)
        {
            var garniture = _garnitureStorage.GetElement(new GarnitureBindingModel
            {
                Id = model.Id
            });
            if (garniture == null)
            {
                throw new Exception("Гарнитур не найден");
            }
            _garnitureStorage.Delete(model);
        }
    }
}
