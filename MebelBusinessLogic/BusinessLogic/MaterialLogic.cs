using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogics
{
	public class MaterialLogic
	{
		private readonly IMaterialStorage _materialStorage;
		public MaterialLogic(IMaterialStorage materialStorage)
		{
			_materialStorage = materialStorage;
		}
		public List<MaterialViewModel> Read(MaterialBindingModel model)
		{
			if (model == null)
			{
				return _materialStorage.GetFullList();
			}
			if (model.Id.HasValue)
			{
				return new List<MaterialViewModel> { _materialStorage.GetElement(model) };
			}
			return _materialStorage.GetFilteredList(model);
		}
		public void CreateOrUpdate(MaterialBindingModel model)
		{
			var element = _materialStorage.GetElement(new MaterialBindingModel
			{
				Name = model.Name
			});
			if (element != null && element.Id != model.Id)
			{
				throw new Exception("Уже есть компонент с таким названием");
			}
			if (model.Id.HasValue)
			{
				_materialStorage.Update(model);
			}
			else
			{
				_materialStorage.Insert(model);
			}
		}
		public void Delete(MaterialBindingModel model)
		{
			var element = _materialStorage.GetElement(new MaterialBindingModel { Id = model.Id });
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			_materialStorage.Delete(model);
		}
	}
}
