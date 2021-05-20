using MebelBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class SupplyViewModel
	{
		public int Id { get; set; }
		public int MaterialId { get; set; }
		[DisplayName("Изделие")]
		public string ModuleName { get; set; }
		[DisplayName("Количество")]
		public int Count { get; set; }
		[DisplayName("Сумма")]
		public decimal Sum { get; set; }
		[DisplayName("Статус")]
		public SupplyStatus Status { get; set; }
		[DisplayName("Дата создания")]
		public DateTime DateCreate { get; set; }
		[DisplayName("Дата выполнения")]
		public DateTime? DateImplement { get; set; }
	}
}
