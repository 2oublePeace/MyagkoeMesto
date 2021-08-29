using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MebelDatabaseImplement.Models
{
	public class ShipmentGarniture
	{
        public int Id { get; set; }
        public int GarnitureId { get; set; }
        public int ShipmentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual Garniture Garniture { get; set; }
    }
}
