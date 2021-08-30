using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportShipmentSupplysViewModel
	{
        int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Материалы")]
        public Dictionary<int, (string, int)> Materials { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
    }
}

