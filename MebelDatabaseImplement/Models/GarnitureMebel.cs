using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MebelDatabaseImplement.Models
{
	public class GarnitureMebel
	{
		public int Id { get; set; }
		public int GarnitureId { get; set; }
		public int MebelId { get; set; }
		[Required]
		public int Count { get; set; }
		public virtual Mebel Mebel { get; set; }
		public virtual Garniture Garniture { get; set; }
	}
}
