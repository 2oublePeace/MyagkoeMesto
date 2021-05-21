using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MebelBusinessLogic.ViewModels
{
	public class MebelViewModel
	{
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
    }
}
