using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.HelperModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogic
{
	public class ReportSupplyGarnituresLogic
	{
        private readonly IGarnitureStorage _garnitureStorage;
        private readonly IMaterialStorage _materialStorage;
        private readonly ISupplyStorage _supplyStorage;

        public ReportSupplyGarnituresLogic(IGarnitureStorage garnitureStorage, IMaterialStorage materialStorage, ISupplyStorage supplyStorage)
        {
            _garnitureStorage = garnitureStorage;
            _materialStorage = materialStorage;
            _supplyStorage = supplyStorage;
        }

        public List<ReportSupplyGarnituresViewModel> GetSupplyGarnitures(List<GarnitureViewModel> garnitures)
        {
            var materials = _materialStorage.GetFullList();
            var supplys = _supplyStorage.GetFullList();
            var list = new List<ReportSupplyGarnituresViewModel>();
            var cache = new List<string>();

            foreach (var garniture in garnitures)
            {
                foreach (var material in materials)
                {
                    if (garniture.GarnitureMaterials.ContainsKey(material.Id))
                    {
                        foreach (var supply in supplys)
                        {
                            if (supply.SupplyMaterials.ContainsKey(material.Id) && !cache.Contains(supply.Name))
                            {
                                var dict = new Dictionary<int, (string, int)>();
                                foreach (var elem in garnitures) { 
                                    if(elem.GarnitureMaterials.ContainsKey(material.Id))
									{
                                        dict.Add(elem.Id, (elem.Name, (int)elem.Price));
									}
                                }

                                list.Add(new ReportSupplyGarnituresViewModel
                                {
                                    Name = supply.Name,
                                    Price = supply.Price,
                                    Date = supply.Date,
                                    Garnitures = dict
                                });
                                cache.Add(supply.Name);
                            }
                        }
                    }
                }

            }
            return list;
        }

        public void SaveToWordFile(string fileName, List<GarnitureViewModel> garnitures)
        {
            SaveToWord.CreateDoc(new WordCustomerInfo
            {
                FileName = fileName,
                Title = "Список поставок по гарнитурам",
                Supplys = GetSupplyGarnitures(garnitures)
            });
        }

        public void SaveToExcelFile(string fileName, List<GarnitureViewModel> garnitures)
        {
            SaveToExcel.CreateDoc(new ExcelCustomerInfo
            {
                FileName = fileName,
                Title = "Список поставок по гарнитурам",
                Supplys = GetSupplyGarnitures(garnitures)
            });
        }

    }
}
