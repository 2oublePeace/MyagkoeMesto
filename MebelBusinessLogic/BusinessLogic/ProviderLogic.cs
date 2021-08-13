using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogics
{
	public class ProviderLogic
	{
        private readonly IProviderStorage _customerStorage;

        public ProviderLogic(IProviderStorage customerStorage)
        {
            _customerStorage = customerStorage;
        }

        public List<ProviderViewModel> Read(ProviderBindingModel model)
        {
            if (model == null)
            {
                return _customerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProviderViewModel> { _customerStorage.GetElement(model) };
            }
            return _customerStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ProviderBindingModel model)
        {
            var customer = _customerStorage.GetElement(new ProviderBindingModel
            {
                FullName = model.FullName
            });
            if (customer != null && customer.Id != model.Id)
            {
                throw new Exception("Уже есть такой пользователь");
            }
            if (model.Id.HasValue)
            {
                _customerStorage.Update(model);
            }
            else
            {
                _customerStorage.Insert(model);
            }
        }

        public void Delete(ProviderBindingModel model)

        {
            var customer = _customerStorage.GetElement(new ProviderBindingModel
            {
                Id = model.Id
            });
            if (customer == null)
            {
                throw new Exception("Поставщик не найден");
            }
            _customerStorage.Delete(model);
        }

        public int CheckPassword(string userName, string password)
        {
            var customer = _customerStorage.GetElement(new ProviderBindingModel
            {
                FullName = userName
            });
            if (customer == null)
            {
                throw new Exception("Нет такого пользователя");
            }
            if (customer.Password != password)
            {
                throw new Exception("Неверный пароль");
            }
            return customer.Id;
        }
    }
}
