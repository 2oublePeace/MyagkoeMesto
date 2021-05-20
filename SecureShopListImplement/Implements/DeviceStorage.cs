using System;
using System.Collections.Generic;
using System.Text;
using SecureShopBusinessLogic.BindingModels;
using SecureShopBusinessLogic.Interfaces;
using SecureShopBusinessLogic.ViewModels;
using SecureShopListImplement.Models;


namespace SecureShopListImplement.Implements
{
	public class DeviceStorage : IDeviceStorage
	{
		private readonly DataListSingleton source;
		public DeviceStorage()
		{
			source = DataListSingleton.GetInstance();
		}
		public List<DeviceViewModel> GetFullList()
		{
			List<DeviceViewModel> result = new List<DeviceViewModel>();
			foreach (var device in source.Devices)
			{
				result.Add(CreateModel(device));
			}
			return result;
		}
		public List<DeviceViewModel> GetFilteredList(DeviceBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			List<DeviceViewModel> result = new List<DeviceViewModel>();
			foreach (var device in source.Devices)
			{
				if (device.DeviceName.Contains(model.DeviceName))
				{
					result.Add(CreateModel(device));
				}
			}
			return result;
		}
		public DeviceViewModel GetElement(DeviceBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			foreach (var device in source.Devices)
			{
				if (device.Id == model.Id || device.DeviceName ==
			   model.DeviceName)
				{
					return CreateModel(device);
				}
			}
			return null;
		}
		public void Insert(DeviceBindingModel model)
		{
			Device tempDevice = new Device { Id = 1 };
			foreach (var device in source.Devices)
			{
				if (device.Id >= tempDevice.Id)
				{
					tempDevice.Id = device.Id + 1;
				}
			}
			source.Devices.Add(CreateModel(model, tempDevice));
		}
		public void Update(DeviceBindingModel model)
		{
			Device tempDevice = null;
			foreach (var device in source.Devices)
			{
				if (device.Id == model.Id)
				{
					tempDevice = device;
				}
			}
			if (tempDevice == null)
			{
				throw new Exception("Элемент не найден");
			}
			CreateModel(model, tempDevice);
		}
		public void Delete(DeviceBindingModel model)
		{
			for (int i = 0; i < source.Devices.Count; ++i)
			{
				if (source.Devices[i].Id == model.Id.Value)
				{
					source.Devices.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		private Device CreateModel(DeviceBindingModel model, Device component)
		{
			component.DeviceName = model.DeviceName;
			return component;
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
