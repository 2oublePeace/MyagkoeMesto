using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecureShopBusinessLogic.BindingModels;
using SecureShopBusinessLogic.Interfaces;
using SecureShopBusinessLogic.ViewModels;
using SecureShopListImplement.Models;

namespace SecureShopListImplement.Implements
{
	public class EquipmentStorage : IEquipmentStorage
	{
		private readonly DataListSingleton source;
		public EquipmentStorage()
		{
			source = DataListSingleton.GetInstance();
		}
		public List<EquipmentViewModel> GetFullList()
		{
			List<EquipmentViewModel> result = new List<EquipmentViewModel>();
			foreach (var device in source.Equipments)
			{
				result.Add(CreateModel(device));
			}
			return result;
		}
		public List<EquipmentViewModel> GetFilteredList(EquipmentBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			List<EquipmentViewModel> result = new List<EquipmentViewModel>();
			foreach (var equipment in source.Equipments)
			{
				if (equipment.EquipmentName.Contains(model.EquipmentName))
				{
					result.Add(CreateModel(equipment));
				}
			}
			return result;
		}
		public EquipmentViewModel GetElement(EquipmentBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			foreach (var equipment in source.Equipments)
			{
				if (equipment.Id == model.Id || equipment.EquipmentName ==
				model.EquipmentName)
				{
					return CreateModel(equipment);
				}
			}
			return null;
		}
		public void Insert(EquipmentBindingModel model)
		{
			Equipment tempEquipment = new Equipment
			{
				Id = 1,
				EquipmentDevices = new
			Dictionary<int, int>()
			};
			foreach (var equipment in source.Equipments)
			{
				if (equipment.Id >= tempEquipment.Id)
				{
					tempEquipment.Id = equipment.Id + 1;
				}
			}
			source.Equipments.Add(CreateModel(model, tempEquipment));
		}
		public void Update(EquipmentBindingModel model)
		{
			Equipment tempEquipment = null;
			foreach (var equipment in source.Equipments)
			{
				if (equipment.Id == model.Id)
				{
					tempEquipment = equipment;
				}
			}
			if (tempEquipment == null)
			{
				throw new Exception("Элемент не найден");
			}
			CreateModel(model, tempEquipment);
		}
		public void Delete(EquipmentBindingModel model)
		{
			for (int i = 0; i < source.Equipments.Count; ++i)
			{
				if (source.Equipments[i].Id == model.Id)
				{
					source.Equipments.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		private Equipment CreateModel(EquipmentBindingModel model, Equipment equipment)
		{
			equipment.EquipmentName = model.EquipmentName;
			equipment.Price = model.Price;
			// удаляем убранные
			foreach (var key in equipment.EquipmentDevices.Keys.ToList())
			{
				if (!model.EquipmentDevices.ContainsKey(key))
				{
					equipment.EquipmentDevices.Remove(key);
				}
			}
			// обновляем существуюущие и добавляем новые
			foreach (var device in model.EquipmentDevices)
			{
				if (equipment.EquipmentDevices.ContainsKey(device.Key))
				{
					equipment.EquipmentDevices[device.Key] =
					model.EquipmentDevices[device.Key].Item2;
				}
				else
				{
					equipment.EquipmentDevices.Add(device.Key,
					model.EquipmentDevices[device.Key].Item2);
				}
			}
			return equipment;
		}
		private EquipmentViewModel CreateModel(Equipment equipment)
		{
			// требуется дополнительно получить список компонентов для изделия с названиями и их количество
			Dictionary<int, (string, int)> equipmentDevices = new Dictionary<int, (string, int)>();
			foreach (var eq in equipment.EquipmentDevices)
			{
				string deviceName = string.Empty;
				foreach (var device in source.Devices)
				{
					if (eq.Key == device.Id)
					{
						deviceName = device.DeviceName;
						break;
					}
				}
				equipmentDevices.Add(eq.Key, (deviceName, eq.Value));
			}
			return new EquipmentViewModel
			{
				Id = equipment.Id,
				EquipmentName = equipment.EquipmentName,
				Price = equipment.Price,
				EquipmentDevices = equipmentDevices
			};
		}
	}
}
