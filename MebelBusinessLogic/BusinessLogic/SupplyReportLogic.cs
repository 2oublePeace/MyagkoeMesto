using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.HelperModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogic
{
	public class SupplyReportLogic
	{
        private readonly IGarnitureStorage _procedureStorage;
        private readonly IMaterialStorage _medicineStorage;
        private readonly ISupplyStorage _receiptStorage;

        public SupplyReportLogic(IGarnitureStorage procedureStorage, IMaterialStorage medicineStorage, ISupplyStorage receiptStorage)
        {
            _procedureStorage = procedureStorage;
            _medicineStorage = medicineStorage;
            _receiptStorage = receiptStorage;
        }

        public List<ReportSupplyViewModel> GetProcedureRecepts(List<GarnitureViewModel> procedures)
        {
            var materials = _medicineStorage.GetFullList();
            var supplys = _receiptStorage.GetFullList();
            var list = new List<ReportSupplyViewModel>();

            foreach (var procedure in procedures)
            {
                foreach (var medicine in materials)
                {

                    /*if (procedure.ProcedureMedicines.ContainsKey(medicine.Id))
                    {
                        foreach (var receipt in supplys)
                        {
                            if (receipt.ReceiptMedicines.ContainsKey(medicine.Id))
                            {

                                list.Add(new ReportReceiptViewModel
                                {
                                    ProcedureName = procedure.Name,
                                    Date = receipt.Date,
                                    DeliverymanName = receipt.DeliverymanName
                                });
                            }
                        }
                    }*/
                }

            }
            return list;
        }

        public void SaveToWordFile(string fileName, List<GarnitureViewModel> procedures)
        {
            SaveToWord.CreateDoc(new ExcelWordInfoForProvider
            {
                FileName = fileName,
                Title = "Список поступлений по процедурам",
                Supplys = GetProcedureRecepts(procedures)
            });
        }

        public void SaveToExcelFile(string fileName, List<GarnitureViewModel> procedures)
        {
            SaveToExcel.CreateDoc(new ExcelWordInfoForProvider
            {
                FileName = fileName,
                Title = "Список поступлений по процедурам",
                Supplys = GetProcedureRecepts(procedures)
            });
        }
    }
}
