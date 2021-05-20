using SecureShopBusinessLogic.BindingModels;
using SecureShopBusinessLogic.Interfaces;
using SecureShopBusinessLogic.ViewModels;
using SecureShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecureShopFileImplement.Implements
{
	public class DeviceStorage : IDeviceStorage
	{
		private readonly FileDataListSingleton source;

		public DeviceStorage()
		{
			source = FileDataListSingleton.GetInstance();
		}

		public List<DeviceViewModel> GetFullList()
		{
			return source.Devices
			.Select(CreateModel)
			.ToList();
		}

		public List<DeviceViewModel> GetFilteredList(DeviceBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			return source.Devices
			.Where(rec => rec.DeviceName.Contains(model.DeviceName))
			.Select(CreateModel)
			.ToList();
		}

		public DeviceViewModel GetElement(DeviceBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			var device = source.Devices
			.FirstOrDefault(rec => rec.DeviceName == model.DeviceName ||
			rec.Id == model.Id);

			return device != null ? CreateModel(device) : null;
		}

		public void Insert(DeviceBindingModel model)
		{
			int maxId = source.Devices.Count > 0 ? source.Devices.Max(rec => rec.Id) : 0;
			var element = new Device { Id = maxId + 1 }; source.Devices.Add(CreateModel(model, element));
		}



		public void Update(DeviceBindingModel model)
		{
			var element = source.Devices.FirstOrDefault(rec => rec.Id == model.Id); if (element == null)
			{
				throw new Exception("Элемент не найден");
			}

			CreateModel(model, element);
		}

		public void Delete(DeviceBindingModel model)
		{
			Device element = source.Devices.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				source.Devices.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}

		private Device CreateModel(DeviceBindingModel model, Device device)
		{
			device.DeviceName = model.DeviceName;

			return device;
		}

		private DeviceViewModel CreateModel(Device device)
		{
			return new DeviceViewModel
			{
				Id = device.Id,
				DeviceName = device.DeviceName
			};
		}
	}
}
