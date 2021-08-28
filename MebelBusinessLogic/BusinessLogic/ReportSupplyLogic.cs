using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.HelperModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System.Collections.Generic;

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

        public List<ReportSupplyViewModel> GetGarnitureRecepts(List<GarnitureViewModel> garnitures)
        {
            var materials = _materialStorage.GetFullList();
            var supplys = _supplyStorage.GetFullList();
            var list = new List<ReportSupplyViewModel>();

            foreach (var garniture in garnitures)
            {
                foreach (var material in materials)
                {

                    if (garniture.GarnitureMaterials.ContainsKey(material.Id))
                    {
                        foreach (var supply in supplys)
                        {
                            if (supply.SupplyMaterials.ContainsKey(material.Id))
                            {

                                list.Add(new ReportSupplyViewModel
                                {
                                    GarnitureName = garniture.Name,
                                    Date = supply.Date,
                                });
                            }
                        }
                    }
                }

            }
            return list;
        }

        public void SaveToWordFile(string fileName, List<GarnitureViewModel> garnitures)
        {
            SaveToWord.CreateDoc(new ExcelWordInfoForProvider
            {
                FileName = fileName,
                Title = "Список поступлений по процедурам",
                Supplys = GetGarnitureRecepts(garnitures)
            });
        }

        public void SaveToExcelFile(string fileName, List<GarnitureViewModel> garnitures)
        {
            SaveToExcel.CreateDoc(new ExcelWordInfoForProvider
            {
                FileName = fileName,
                Title = "Список поступлений по процедурам",
                Supplys = GetGarnitureRecepts(garnitures)
            });
        }
    }
}
