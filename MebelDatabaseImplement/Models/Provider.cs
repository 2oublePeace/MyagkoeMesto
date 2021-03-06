using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MebelDatabaseImplement.Models
{
	public class Provider
	{
		public int Id { get; set; }
		[Required]
		public string FullName { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
