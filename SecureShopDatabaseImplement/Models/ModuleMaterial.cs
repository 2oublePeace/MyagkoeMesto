using System.ComponentModel.DataAnnotations;

namespace SecureShopDatabaseImplement.Models
{
	/// <summary>
	/// Сколько компонентов, требуется при изготовлении изделия
	/// </summary>
	public class ModuleMaterial
	{
		public int Id { get; set; }

		public int ModuleId { get; set; }
		public int MaterialId { get; set; }
		[Required]
		public int Count { get; set; }
		public virtual Material Material { get; set; }
		public virtual Module Module { get; set; }
	}
}