using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MebelDatabaseImplement.Models
{
	/// <summary>
	/// Компонент, требуемый для изготовления изделия
	/// </summary>
	public class Material
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public decimal Price { get; set; }

		[ForeignKey("MaterialId")]
		public virtual List<ModuleMaterial> ModuleMaterials { get; set; }

		[ForeignKey("MaterialId")]
		public virtual List<SupplyMaterial> SupplyMaterials { get; set; }
	}
}