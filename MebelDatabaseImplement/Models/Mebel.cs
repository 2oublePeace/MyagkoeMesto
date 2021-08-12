using System.ComponentModel.DataAnnotations;

namespace MebelDatabaseImplement.Models
{
	public class Mebel
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}
