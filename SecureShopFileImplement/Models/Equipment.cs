using System;
using System.Collections.Generic;
using System.Text;

namespace SecureShopFileImplement.Models
{
	public class Equipment
	{
		public int Id { get; set; }
		public string EquipmentName { get; set; }
		public decimal Price { get; set; }
		public Dictionary<int, int> EquipmentDevices { get; set; }
	}
}
