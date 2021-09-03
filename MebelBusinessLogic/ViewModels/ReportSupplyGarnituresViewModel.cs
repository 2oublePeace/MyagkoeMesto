using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportSupplyGarnituresViewModel
	{
        int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Гарнитуры")]
        public Dictionary<int, (string, int)> Garnitures { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
    }
}
