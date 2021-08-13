using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace MebelBusinessLogic.Interfaces
{
	public interface IProviderStorage
	{
        List<ProviderViewModel> GetFullList();
        List<ProviderViewModel> GetFilteredList(ProviderBindingModel model);
        ProviderViewModel GetElement(ProviderBindingModel model);
        void Insert(ProviderBindingModel model);
        void Update(ProviderBindingModel model);
        void Delete(ProviderBindingModel model);
    }
}
