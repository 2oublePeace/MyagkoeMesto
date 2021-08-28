using MebelBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ReportSupplyViewModel
	{
        int Id { get; set; }
        [DisplayName("Название процедуры")]
        public string GarnitureName { get; set; }
        [DisplayName("Дата поступления")]
        public DateTime Date { get; set; }
    }
}

