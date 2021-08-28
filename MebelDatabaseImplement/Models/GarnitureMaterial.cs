using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MebelDatabaseImplement.Models
{
	public class GarnitureMaterial
	{
		public int Id { get; set; }
		public int GarnitureId { get; set; }
		public int MaterialId { get; set; }
		[Required]
		public int Count { get; set; }
		public virtual Material Material { get; set; }
		public virtual Garniture Garniture { get; set; }
	}
}
