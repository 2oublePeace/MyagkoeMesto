using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MebelDatabaseImplement.Models
{
	public class Mebel
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }
		[ForeignKey("MebelId")]
		public virtual List<ModuleMebel> ModuleMebels { get; set; }
	}
}
