using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.ViewModels;
using System.Collections.Generic;


namespace MebelBusinessLogic.Interfaces
{
	public interface ICustomerStorage
	{
        List<CustomerViewModel> GetFullList();
        List<CustomerViewModel> GetFilteredList(CustomerBindingModel model);
        CustomerViewModel GetElement(CustomerBindingModel model);
        void Insert(CustomerBindingModel model);
        void Update(CustomerBindingModel model);
        void Delete(CustomerBindingModel model);
    }
}
