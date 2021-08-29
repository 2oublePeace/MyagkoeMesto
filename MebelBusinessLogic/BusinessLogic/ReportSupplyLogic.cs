using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.HelperModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogic
{
	public class ReportSupplyLogic
	{
        private readonly IGarnitureStorage _garnitureStorage;
        private readonly IMaterialStorage _materialStorage;
        private readonly ISupplyStorage _supplyStorage;

        public ReportSupplyLogic(IGarnitureStorage garnitureStorage, IMaterialStorage materialStorage, ISupplyStorage supplyStorage)
        {
            _garnitureStorage = garnitureStorage;
            _materialStorage = materialStorage;
            _supplyStorage = supplyStorage;
        }

        public List<ReportSupplyViewModel> GetGarnitureSupply(ReportProviderBindingModel model)
        {
            var supplys = _supplyStorage.GetFilteredList(new SupplyBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var materials = _materialStorage.GetFullList();
            var garnitures = _garnitureStorage.GetFullList();

            var list = new List<ReportSupplyViewModel>();

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
                                list.Add(new ReportSupplyViewModel
                                {
                                    Date = supply.Date,
                                    SupplyName = supply.Name,
                                    SupplyPrice = supply.Price.ToString(),
                                    GarnitureName = garniture.Name
                                });
                            }
                        }
                    }
                }
            }
            return list;
        }

        public void SaveToPdfFile(ReportProviderBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfProviderInfo
            {
                FileName = model.FileName,
                Title = "Список пациентов и поступлений",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Supplys = GetGarnitureSupply(model)
            });
        }
    }
}
