using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogics
{
	public class ModuleLogic
	{
		private readonly IModuleStorage _moduleStorage;
		public ModuleLogic(IModuleStorage moduleStorage)
		{
			_moduleStorage = moduleStorage;
		}

		public List<ModuleViewModel> Read(ModuleBindingModel model)
		{
			if (model == null)
			{
				return _moduleStorage.GetFullList();
			}
			if (model.Id.HasValue)
			{
				return new List<ModuleViewModel> { _moduleStorage.GetElement(model) };
			}
			return _moduleStorage.GetFilteredList(model);
		}

		public void CreateOrUpdate(ModuleBindingModel model)
		{
			var element = _moduleStorage.GetElement(new ModuleBindingModel { Name = model.Name });
			if (element != null && element.Id != model.Id)
			{
				throw new Exception("Уже есть подарок с таким названием");
			}
			if (model.Id.HasValue)
			{
				_moduleStorage.Update(model);
			}
			else
			{
				_moduleStorage.Insert(model);
			}
		}
		public void Delete(ModuleBindingModel model)

		{
			var element = _moduleStorage.GetElement(new ModuleBindingModel { Id = model.Id });
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			_moduleStorage.Delete(model);
		}
	}
}
