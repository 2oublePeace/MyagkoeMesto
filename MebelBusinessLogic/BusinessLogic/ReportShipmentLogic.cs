using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogic
{
	public class ReportShipmentLogic
	{
        /*private readonly ISupplyStorage _supplyStorage;
        private readonly IMaterialStorage _materialStorage;
        private readonly IGarnitureStorage _garnitureStorage;
        private readonly IShipmentStorage _shipmentStorage;

        public ReportShipmentLogic(ISupplyStorage supplyStorage, IMaterialStorage materialStorage, IGarnitureStorage garnitureStorage, IShipmentStorage shipmentStorage)
        {
            _supplyStorage = supplyStorage;
            _materialStorage = materialStorage;
            _garnitureStorage = garnitureStorage;
            _shipmentStorage = shipmentStorage;
        }

        public List<ReportShipmentViewModel> GetPatientReceipt(ReportCustomerBindingModel model)
        {
            var supplys = _supplyStorage.GetFilteredList(new SupplyBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var materials = _materialStorage.GetFullList();
            var garnitures = _garnitureStorage.GetFullList();
            var shipments = _shipmentStorage.GetFullList();

            var list = new List<ReportShipmentSupplysViewModel>();

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
                                foreach (var shipment in shipments)
                                {
                                    if (garniture.GarnitureMaterials.ContainsKey(material.Id))
                                    {
                                        list.Add(new ReportShipmentSupplysViewModel
                                        {
                                            Date = supply.Date,
                                           
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        public void SaveToPdfFile(ReportPatientReceiptBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfoForDoctor
            {
                FileName = model.FileName,
                Title = "Отчет по пациентам и поступлениям",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Receipts = GetPatientReceipt(model)
            });
        }*/
    }
}
