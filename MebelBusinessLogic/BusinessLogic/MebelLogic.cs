using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogics
{
	public class MebelLogic
	{
		private readonly IMebelStorage _mebelStorage;
        public MebelLogic(IMebelStorage mebelStorage)
        {
            _mebelStorage = mebelStorage;
        }

        public List<MebelViewModel> Read(MebelBindingModel model)
        {
            if (model == null)
            {
                return _mebelStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<MebelViewModel> { _mebelStorage.GetElement(model) };
            }
            return _mebelStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(MebelBindingModel model)
        {
            var mebel = _mebelStorage.GetElement(new MebelBindingModel
            {
                Name = model.Name
            });
            if (mebel != null && mebel.Id != model.Id)
            {
                throw new Exception("Уже есть такое лечение");
            }
            if (model.Id.HasValue)
            {
                _mebelStorage.Update(model);
            }
            else
            {
                _mebelStorage.Insert(model);
            }
        }

        public void Delete(MebelBindingModel model)

        {
            var mebel = _mebelStorage.GetElement(new MebelBindingModel
            {
                Id = model.Id
            });
            if (mebel == null)
            {
                throw new Exception("Лечение не найдено");
            }
            _mebelStorage.Delete(model);
        }
	}
}
