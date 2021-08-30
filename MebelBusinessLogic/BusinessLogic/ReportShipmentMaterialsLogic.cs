using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.HelperModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace MebelBusinessLogic.BusinessLogic
{
	public class ReportShipmentMaterialsLogic
	{
		private readonly IGarnitureStorage _garnitureStorage;
		private readonly IMaterialStorage _materialStorage;
		private readonly IShipmentStorage _shipmentStorage;

		public ReportShipmentMaterialsLogic(IGarnitureStorage garnitureStorage, IMaterialStorage materialStorage, IShipmentStorage shipmentStorage)
		{
			_garnitureStorage = garnitureStorage;
			_materialStorage = materialStorage;
			_shipmentStorage = shipmentStorage;
		}

		public List<ReportShipmentMaterialsViewModel> GetMaterialShipments(List<MaterialViewModel> materials)
		{
			var garnitures = _garnitureStorage.GetFullList();
			var shipments = _shipmentStorage.GetFullList();
			var list = new List<ReportShipmentMaterialsViewModel>();
			var cache = new List<string>();

			foreach (var material in materials)
			{
				foreach (var garniture in garnitures)
				{
					if (garniture.GarnitureMaterials.ContainsKey(material.Id))
					{
						foreach (var shipment in shipments)
						{
							if (shipment.ShipmentGarnitures.ContainsKey(garniture.Id) && !cache.Contains(shipment.Name))
							{
								list.Add(new ReportShipmentMaterialsViewModel
								{
									Name = shipment.Name,
									Date = shipment.Date,
									Price = shipment.Price,
									Materials = garniture.GarnitureMaterials
								});
								cache.Add(shipment.Name);
							}
						}
					}
				}
			}
			return list;
		}

		public void SaveToWordFile(string fileName, List<MaterialViewModel> materials)
		{
			SaveToWord.CreateDoc(new WordProviderInfo
			{
				FileName = fileName,
				Title = "Список отгрузок по материалам",
				Shipments = GetMaterialShipments(materials)
			});
		}

		public void SaveToExcelFile(string fileName, List<MaterialViewModel> materials)
		{
			SaveToExcel.CreateDoc(new ExcelProviderInfo
			{
				FileName = fileName,
				Title = "Список отгрузок по материалам",
				Shipments = GetMaterialShipments(materials)
			});
		}
	}
}
