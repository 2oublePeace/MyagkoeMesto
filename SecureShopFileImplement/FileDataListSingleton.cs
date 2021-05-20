using SecureShopBusinessLogic.Enums;
using SecureShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SecureShopFileImplement
{
	public class FileDataListSingleton
	{
		private static FileDataListSingleton instance;

		private readonly string DeviceFileName = "Device.xml"; 
		private readonly string OrderFileName = "Order.xml";
		private readonly string EquipmentFileName = "Equipment.xml";
		public List<Device> Devices { get; set; }
		public List<Order> Orders { get; set; }
		public List<Equipment> Equipments { get; set; }
		private FileDataListSingleton()
		{
			Devices = LoadDevices(); 
			Orders = LoadOrders(); 
			Equipments = LoadEquipments();
		}

		public static FileDataListSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new FileDataListSingleton();
			}

			return instance;
		}

		~FileDataListSingleton()
		{
			SaveDevices(); 
			SaveOrders();
			SaveEquipments();
		}

		private List<Device> LoadDevices()
		{
			var list = new List<Device>();

			if (File.Exists(DeviceFileName))
			{
				XDocument xDocument = XDocument.Load(DeviceFileName);
				var xElements = xDocument.Root.Elements("Device").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Device
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						DeviceName = elem.Element("DeviceName").Value
					});
				}
			}
			return list;
		}
		private List<Order> LoadOrders()
		{
			var list = new List<Order>();
			if (File.Exists(OrderFileName))
			{
				XDocument xDocument = XDocument.Load(OrderFileName);
				var xElements = xDocument.Root.Elements("Order").ToList();
				foreach (var elem in xElements)
				{
					OrderStatus status = (OrderStatus)0;
					switch ((elem.Element("Status").Value))
					{
						case "Принят":
							status = (OrderStatus)0;
							break;
						case "Выполняется":
							status = (OrderStatus)1;
							break;
						case "Готов":
							status = (OrderStatus)2;
							break;
						case "Оплачен":
							status = (OrderStatus)3;
							break;

					}
					if (string.IsNullOrEmpty(elem.Element("DateImplement").Value))
					{
						list.Add(new Order
						{
							Id = Convert.ToInt32(elem.Attribute("Id").Value),
							EquipmentId = Convert.ToInt32(elem.Element("EquipmentId").Value),
							Count = Convert.ToInt32(elem.Element("Count").Value),
							Sum = Convert.ToDecimal(elem.Element("Sum").Value),
							Status = status,
							DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value)
						});
					}
					else
					{
						list.Add(new Order
						{
							Id = Convert.ToInt32(elem.Attribute("Id").Value),
							EquipmentId = Convert.ToInt32(elem.Element("EquipmentId").Value),
							Count = Convert.ToInt32(elem.Element("Count").Value),
							Sum = Convert.ToDecimal(elem.Element("Sum").Value),
							Status = status,
							DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
							DateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value)
						});
					}

				}
			}
			return list;
		}

		private List<Equipment> LoadEquipments()
		{
			var list = new List<Equipment>();

			if (File.Exists(EquipmentFileName))
			{
				XDocument xDocument = XDocument.Load(EquipmentFileName);
				var xElements = xDocument.Root.Elements("Equipment").ToList(); foreach (var elem in xElements)
				{
					var equipDev = new Dictionary<int, int>(); foreach (var device in
					elem.Element("EquipmentDevices").Elements("EquipmentDevice").ToList())
					{
						equipDev.Add(Convert.ToInt32(device.Element("Key").Value), Convert.ToInt32(device.Element("Value").Value));
					}
					list.Add(new Equipment
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						EquipmentName = elem.Element("EquipmentName").Value,
						Price = Convert.ToDecimal(elem.Element("Price").Value),
						EquipmentDevices = equipDev
					});
				}
			}
			return list;
		}

		private void SaveDevices()
		{
			if (Devices != null)
			{
				var xElement = new XElement("Devices");

				foreach (var device in Devices)
				{
					xElement.Add(new XElement("Device", new XAttribute("Id", device.Id),
					new XElement("DeviceName", device.DeviceName)));
				}

				XDocument xDocument = new XDocument(xElement); xDocument.Save(DeviceFileName);
			}
		}

		private void SaveOrders()
		{
			if (Orders != null)
			{
				var xElement = new XElement("Orders");
				foreach (var order in Orders)
				{
					xElement.Add(new XElement("Order",
				 new XAttribute("Id", order.Id),
				 new XElement("EquipmentId", order.EquipmentId),
				 new XElement("Count", order.Count),
				 new XElement("Sum", order.Sum),
				 new XElement("Status", order.Status),
				 new XElement("DateCreate", order.DateCreate),
				 new XElement("DateImplement", order.DateImplement)
				 ));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(OrderFileName);
			}
		}

		private void SaveEquipments()
		{
			if (Equipments != null)
			{
				var xElement = new XElement("Equipments");

				foreach (var equipment in Equipments)
				{
					var compElement = new XElement("EquipmentDevices"); foreach (var device in equipment.EquipmentDevices)
					{
						compElement.Add(new XElement("EquipmentDevice", new XElement("Key", device.Key),
						new XElement("Value", device.Value)));
					}
					xElement.Add(new XElement("Equipment", new XAttribute("Id", equipment.Id),
					new XElement("EquipmentName", equipment.EquipmentName), new XElement("Price", equipment.Price), compElement));
				}

				XDocument xDocument = new XDocument(xElement); xDocument.Save(EquipmentFileName);
			}
		}
	}
}

