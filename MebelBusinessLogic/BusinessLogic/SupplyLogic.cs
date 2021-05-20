using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Enums;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogics
{
	public class SupplyLogic
	{
		private readonly ISupplyStorage _orderStorage;
		public SupplyLogic(ISupplyStorage orderStorage)
		{
			_orderStorage = orderStorage;
		}
		public List<SupplyViewModel> Read(SupplyBindingModel model)
		{
			if (model == null)
			{
				return _orderStorage.GetFullList();
			}
			if (model.Id.HasValue)
			{
				return new List<SupplyViewModel> { _orderStorage.GetElement(model) };
			}
			return _orderStorage.GetFilteredList(model);
		}
		public void CreateOrder(CreateSupplyBindingModel model)
		{
			_orderStorage.Insert(new SupplyBindingModel
			{
				MaterialId = model.MaterialId,
				Count = model.Count,
				Sum = model.Sum,
				DateCreate = DateTime.Now,
				Status = SupplyStatus.Принят
			});
		}
		public void TakeOrderInWork(ChangeStatusBindingModel model)
		{
			var supply = _orderStorage.GetElement(new SupplyBindingModel
			{
				Id =
		   model.OrderId
			});
			if (supply == null)
			{
				throw new Exception("Не найден заказ");
			}
			if (supply.Status != SupplyStatus.Принят)
			{
				throw new Exception("Заказ не в статусе \"Принят\"");
			}
			_orderStorage.Update(new SupplyBindingModel
			{
				Id = supply.Id,
				MaterialId = supply.MaterialId,
				Count = supply.Count,
				Sum = supply.Sum,
				DateCreate = supply.DateCreate,
				DateImplement = DateTime.Now,
				Status = SupplyStatus.Выполняется
			});
		}
		public void FinishOrder(ChangeStatusBindingModel model)
		{
			var supply = _orderStorage.GetElement(new SupplyBindingModel { Id = model.OrderId });
			if (supply == null)
			{
				throw new Exception("Не найден заказ");
			}
			if (supply.Status != SupplyStatus.Выполняется)
			{
				throw new Exception("Заказ не в статусе \"Выполняется\"");
			}
			_orderStorage.Update(new SupplyBindingModel
			{
				Id = supply.Id,
				MaterialId = supply.MaterialId,
				Count = supply.Count,
				Sum = supply.Sum,
				DateCreate = supply.DateCreate,
				DateImplement = supply.DateImplement,
				Status = SupplyStatus.Готов
			});
		}
		public void PayOrder(ChangeStatusBindingModel model)
		{
			var supply = _orderStorage.GetElement(new SupplyBindingModel
			{
				Id = model.OrderId
			});
			if (supply == null)
			{
				throw new Exception("Не найден заказ");
			}
			if (supply.Status != SupplyStatus.Готов)
			{
				throw new Exception("Заказ не в статусе \"Готов\"");
			}
			_orderStorage.Update(new SupplyBindingModel
			{
				Id = supply.Id,
				MaterialId = supply.MaterialId,
				Count = supply.Count,
				Sum = supply.Sum,
				DateCreate = supply.DateCreate,
				DateImplement = supply.DateImplement,
				Status = SupplyStatus.Оплачен
			});
		}
	}
}
