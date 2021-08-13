using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BusinessLogic;
using MebelBusinessLogic.HelperModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MebelBusinessLogic.BusinessLogics
{
	public class ReportLogic
	{
		private readonly IMaterialStorage _materialStorage; private readonly IModuleStorage _moduleStorage; private readonly ISupplyStorage _orderStorage;
		public ReportLogic(IModuleStorage moduleStorage, IMaterialStorage materialStorage, ISupplyStorage orderStorage)
		{
			_moduleStorage = moduleStorage;
			_materialStorage = materialStorage;
			_orderStorage = orderStorage;
		}
		/// <summary>
		/// Получение списка компонент с указанием, в каких изделиях используются
		/// </summary>
		/// <returns></returns>
		public List<ReportModuleMaterialViewModel> GetModuleMaterial()
		{
			var materials = _materialStorage.GetFullList();
			var modules = _moduleStorage.GetFullList();
			var list = new List<ReportModuleMaterialViewModel>();

			foreach (var module in modules)
			{
				var record = new ReportModuleMaterialViewModel
				{
					ModuleName = module.Name,
					Materials = new List<Tuple<string, int>>(),
					TotalCount = 0
				};
				foreach (var material in materials)
				{
					if (module.ModuleMaterials.ContainsKey(material.Id))
					{
						record.Materials.Add(new Tuple<string, int>(material.Name, module.ModuleMaterials[material.Id].Item2));
						record.TotalCount += module.ModuleMaterials[material.Id].Item2;
					}
				}

				list.Add(record);
			}

			return list;
		}
		/// <summary>
		/// Получение списка заказов за определенный период
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
		{
			return _orderStorage.GetFilteredList(new SupplyBindingModel
			{
				DateFrom = model.DateFrom,
				DateTo = model.DateTo
			})
			.Select(x => new ReportOrdersViewModel
			{
				DateCreate = x.DateCreate,
				ModuleName = x.ModuleName,
				Count = x.Count,
				Sum = x.Sum,
				Status = x.Status
			})
			.ToList();
		}
		/// <summary>
		/// Сохранение компонент в файл-Word
		/// </summary>
		/// <param name="model"></param>
		public void SaveMaterialsToWordFile(ReportBindingModel model)
		{
			SaveToWord.CreateDoc(new WordInfo
			{
				FileName = model.FileName,
				Title = "Список устройств",
				Modules = _moduleStorage.GetFullList()
			});
		}
		/// <summary>
		/// Сохранение компонент с указаеним продуктов в файл-Excel
		/// </summary>
		/// <param name="model"></param>
		public void SaveModuleMaterialToExcelFile(ReportBindingModel model)
		{
			SaveToExcel.CreateDoc(new ExcelInfo
			{
				FileName = model.FileName,
				Title = "Список устройств-комплектаций",
				ModuleMaterials = GetModuleMaterial()
			});
		}

		/// <summary>
		/// Сохранение заказов в файл-Pdf
		/// </summary>
		/// <param name="model"></param>
		public void SaveOrdersToPdfFile(ReportBindingModel model)
		{
			SaveToPdf.CreateDoc(new PdfInfo
			{
				FileName = model.FileName,
				Title = "Список заказов",
				DateFrom = model.DateFrom.Value,
				DateTo = model.DateTo.Value,
				Orders = GetOrders(model)
			});
		}
	}
}
