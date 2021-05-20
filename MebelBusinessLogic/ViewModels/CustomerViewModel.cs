using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class CustomerViewModel
	{
        public int Id { get; set; }
        [DisplayName("Имя доктора")]
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}
