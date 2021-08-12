using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.ViewModels;
using MebelBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MebelDatabaseImplement.Models;

namespace MebelDatabaseImplement.Implements
{
    public class CustomerStorage : ICustomerStorage
    {
        public List<CustomerViewModel> GetFullList()
        {
            using (var context = new MebelDatabase())
            {
                return context.Customers
                .Select(CreateModel).ToList();
            }
        }

        public List<CustomerViewModel> GetFilteredList(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                return context.Customers
                    .Where(rec => rec.FullName.Contains(model.FullName))
                    .Select(CreateModel).ToList();
            }
        }

        public CustomerViewModel GetElement(CustomerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                var customer = context.Customers
                .FirstOrDefault(rec => rec.Id == model.Id || rec.FullName == model.FullName);
                return customer != null ?
                CreateModel(customer) : null;
            }
        }

        public void Insert(CustomerBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                context.Customers.Add(CreateModel(model, new Customer()));
                context.SaveChanges();
            }
        }

        public void Update(CustomerBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                var element = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Заказчик не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(CustomerBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                Customer element = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Customers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказчик не найден");
                }
            }
        }

        private Customer CreateModel(CustomerBindingModel model, Customer customer)
        {
            customer.FullName = model.FullName;
            customer.Password = model.Password;
            return customer;
        }

        private CustomerViewModel CreateModel(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Password = customer.Password
            };
        }
    }
}
