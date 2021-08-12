using System.ComponentModel.DataAnnotations;

namespace MebelDatabaseImplement.Models
{
	public class Garniture
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}
