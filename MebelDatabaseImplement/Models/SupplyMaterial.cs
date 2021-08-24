using System.ComponentModel.DataAnnotations;

namespace MebelDatabaseImplement.Models
{
	public class SupplyMaterial
	{
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int SupplyId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Supply Supply { get; set; }
        public virtual Material Material { get; set; }
    }
}
