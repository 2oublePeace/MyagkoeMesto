using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportSupplyViewModel
	{
        int Id { get; set; }
        [DisplayName("Гарнитур")]
        public string GarnitureName { get; set; }
        [DisplayName("Цена поставки")]
        public string SupplyPrice { get; set; }
        [DisplayName("Поставки")]
        public string SupplyName { get; set; }
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
    }
}
