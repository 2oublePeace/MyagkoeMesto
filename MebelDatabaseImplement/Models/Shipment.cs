using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MebelDatabaseImplement.Models
{
	public class Shipment
	{
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("ShipmentId")]
        public virtual List<ShipmentGarniture> ShipmentGarnitures { get; set; }
    }
}
