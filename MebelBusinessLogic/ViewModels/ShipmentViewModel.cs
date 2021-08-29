﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class ShipmentViewModel
	{
		public int Id { get; set; }
		[DisplayName("Отгрузка")]
		public string Name { get; set; }
		[DisplayName("Цена")]
		public decimal Price { get; set; }
		[DisplayName("Дата")]
		public DateTime Date { get; set; }
		[DisplayName("Источник")]
		public Dictionary<int, (string, int)> ShipmentGarnitures { get; set; }
	}
}
