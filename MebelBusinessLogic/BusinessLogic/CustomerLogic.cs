using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MebelBusinessLogic.BusinessLogic
{
    public class CustomerLogic
    {
        private readonly ICustomerStorage _customerStorage;
        public CustomerLogic(ICustomerStorage customerStorage)
        {
            _customerStorage = customerStorage;
        }

        public List<CustomerViewModel> Read(CustomerBindingModel model)
        {
            if (model == null)
            {
                return _customerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CustomerViewModel> { _customerStorage.GetElement(model) };
            }
            return _customerStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(CustomerBindingModel model)
        {
            var customer = _customerStorage.GetElement(new CustomerBindingModel
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

        public void Delete(CustomerBindingModel model)

        {
            var customer = _customerStorage.GetElement(new CustomerBindingModel
            {
                Id = model.Id
            });
            if (customer == null)
            {
                throw new Exception("Доктор не найден");
            }
            _customerStorage.Delete(model);
        }

        public int CheckPassword(string userName, string password)
        {
            var customer = _customerStorage.GetElement(new CustomerBindingModel
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
