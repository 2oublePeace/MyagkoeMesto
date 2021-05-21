using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.Interfaces
{
	public interface IMebelStorage
	{
        List<MebelViewModel> GetFullList();
        List<MebelViewModel> GetFilteredList(MebelBindingModel model);
        MebelViewModel GetElement(MebelBindingModel model);
        void Insert(MebelBindingModel model);
        void Update(MebelBindingModel model);
        void Delete(MebelBindingModel model);
    }
}
