using SecureShopBusinessLogic.BindingModels;
using SecureShopBusinessLogic.Interfaces;
using SecureShopBusinessLogic.ViewModels;
using SecureShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecureShopFileImplement.Implements
{
	public class EquipmentStorage : IEquipmentStorage
	{
		private readonly FileDataListSingleton source;

		public EquipmentStorage()
		{
			source = FileDataListSingleton.GetInstance();
		}

		public List<EquipmentViewModel> GetFullList()
		{
			return source.Equipments
			.Select(CreateModel)
			.ToList();
		}

		public List<EquipmentViewModel> GetFilteredList(EquipmentBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			return source.Equipments
			.Where(rec => rec.EquipmentName.Contains(model.EquipmentName))
			.Select(CreateModel)
			.ToList();
		}

		public EquipmentViewModel GetElement(EquipmentBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			var equipment = source.Equipments
			.FirstOrDefault(rec => rec.EquipmentName == model.EquipmentName || rec.Id
			== model.Id);

			return equipment != null ? CreateModel(equipment) : null;
		}

		public void Insert(EquipmentBindingModel model)
		{
			int maxId = source.Equipments.Count > 0 ? source.Devices.Max(rec => rec.Id) : 0;

			var element = new Equipment
			{
				Id = maxId + 1,
				EquipmentDevices = new

			Dictionary<int, int>()
			};
			source.Equipments.Add(CreateModel(model, element));
		}

		public void Update(EquipmentBindingModel model)
		{
			var element = source.Equipments.FirstOrDefault(rec => rec.Id == model.Id); if (element == null)
			{
				throw new Exception("Элемент не найден");
			}

			CreateModel(model, element);
		}

		public void Delete(EquipmentBindingModel model)
		{
			Equipment element = source.Equipments.FirstOrDefault(rec => rec.Id == model.Id); if (element != null)
			{
				source.Equipments.Remove(element);
			}
			else
			{

				throw new Exception("Элемент не найден");
			}
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
					equipment.EquipmentDevices[device.Key] = model.EquipmentDevices[device.Key].Item2;
				}
				else
				{
					equipment.EquipmentDevices.Add(device.Key, model.EquipmentDevices[device.Key].Item2);
				}
			}

			return equipment;
		}

		private EquipmentViewModel CreateModel(Equipment equipment)
		{
			return new EquipmentViewModel
			{
				Id = equipment.Id,
				EquipmentName = equipment.EquipmentName,
				Price = equipment.Price,
				EquipmentDevices = equipment.EquipmentDevices
					.ToDictionary(recPC => recPC.Key, recPC => (source.Devices
						.FirstOrDefault(recC => recC.Id ==recPC.Key)?.DeviceName, recPC.Value))
			};
		}
	}
}

