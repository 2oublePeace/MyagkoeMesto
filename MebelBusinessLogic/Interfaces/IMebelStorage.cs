using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.ViewModels;
using System.Collections.Generic;

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
