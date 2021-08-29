using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportSupplyViewModel
	{
        int Id { get; set; }
        [DisplayName("Название поставки")]
        public string GarnitureName { get; set; }
        [DisplayName("Дата поставки")]
        public DateTime Date { get; set; }
    }
}
