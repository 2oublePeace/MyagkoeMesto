using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace MebelBusinessLogic.Interfaces
{
    public interface IGarnitureStorage
	{
        List<GarnitureViewModel> GetFullList();
        List<GarnitureViewModel> GetFilteredList(GarnitureBindingModel model);
        GarnitureViewModel GetElement(GarnitureBindingModel model);
        void Insert(GarnitureBindingModel model);
        void Update(GarnitureBindingModel model);
        void Delete(GarnitureBindingModel model);
    }
}
