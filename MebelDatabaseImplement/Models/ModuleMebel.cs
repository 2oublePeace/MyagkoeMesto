using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MebelDatabaseImplement.Models
{
	public class ModuleMebel
	{
		public int Id { get; set; }
		public int ModuleId { get; set; }
		public int MebelId { get; set; }
		[Required]
		public int Count { get; set; }
		public virtual Mebel Mebel { get; set; }
		public virtual Module Module { get; set; }
	}
}
