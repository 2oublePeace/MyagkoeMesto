using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.HelperModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace MebelBusinessLogic.BusinessLogic
{
	public class ReportGarnitureSupplyLogic
	{
        private readonly IMaterialStorage _materialStorage;
        private readonly IGarnitureStorage _garnitureStorage;
        private readonly ISupplyStorage _supplyStorage;

        public ReportGarnitureSupplyLogic(IGarnitureStorage garnitureStorage, IMaterialStorage materialStorage, ISupplyStorage supplyStorage)
        {
            _garnitureStorage = garnitureStorage;
            _materialStorage = materialStorage;
            _supplyStorage = supplyStorage;
        }

		public List<ReportGarnitureSupplyViewModel> GetProcedureReceipt(ReportGarnitureSupplyBindingModel model)
		{
			var supplys = _supplyStorage.GetFilteredList(new SupplyBindingModel
			{
				DateFrom = model.DateFrom,
				DateTo = model.DateTo
			});
			var materials = _materialStorage.GetFullList();
			var garnitures = _garnitureStorage.GetFullList();

			var list = new List<ReportGarnitureSupplyViewModel>();

			foreach (var supply in supplys)
			{

				foreach (var material in materials)
				{
					if (supply.SupplyMaterials.ContainsKey(material.Id))
					{
						foreach (var garniture in garnitures)
						{
							if (garniture.GarnitureMaterials.ContainsKey(material.Id))
							{
								list.Add(new ReportGarnitureSupplyViewModel
								{
									Date = supply.Date,
									MaterialName = material.Name,
									GarnitureName = garniture.Name
								});
							}
						}
					}
				}
			}
			return list;
		}

		public void SaveToPdfFile(ReportGarnitureSupplyBindingModel model)
		{
			SaveToPdf.CreateDoc(new PdfInfoForProvider 
			{
				FileName = model.FileName,
				Title = "Список пациентов и поступлений",
				DateFrom = model.DateFrom.Value,
				DateTo = model.DateTo.Value,
				Supplys = GetProcedureReceipt(model)
			});
		}
	}
}
