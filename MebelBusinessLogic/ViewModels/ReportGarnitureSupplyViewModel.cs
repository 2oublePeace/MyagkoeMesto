using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportGarnitureSupplyViewModel
	{
        [DisplayName("Название гарнитура")]
        public string GarnitureName { get; set; }
        [DisplayName("Название материала")]
        public string MaterialName { get; set; }
        [DisplayName("Дата поступления")]
        public DateTime Date { get; set; }
    }
}
