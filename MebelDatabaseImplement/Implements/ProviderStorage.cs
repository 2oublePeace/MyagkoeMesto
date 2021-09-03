using System;
using System.Collections.Generic;
using System.Linq;
using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using MebelDatabaseImplement.Models;

namespace MebelDatabaseImplement.Implements
{
	public class ProviderStorage : IProviderStorage
    {
        public List<ProviderViewModel> GetFullList()
        {
            using (var context = new MebelDatabase())
            {
                return context.Providers
                .Select(CreateModel).ToList();
            }
        }

        public List<ProviderViewModel> GetFilteredList(ProviderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                return context.Providers
                    .Where(rec => rec.FullName.Contains(model.FullName))
                    .Select(CreateModel).ToList();
            }
        }

        public ProviderViewModel GetElement(ProviderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                var provider = context.Providers
                .FirstOrDefault(rec => rec.Id == model.Id || rec.FullName == model.FullName);
                return provider != null ?
                CreateModel(provider) : null;
            }
        }

        public void Insert(ProviderBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                context.Providers.Add(CreateModel(model, new Provider()));
                context.SaveChanges();
            }
        }

        public void Update(ProviderBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                var element = context.Providers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Поставщик не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ProviderBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                Provider element = context.Providers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Providers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Поставщик не найден");
                }
            }
        }

        private Provider CreateModel(ProviderBindingModel model, Provider provider)
        {
            provider.FullName = model.FullName;
            provider.Password = model.Password;
            return provider;
        }

        private ProviderViewModel CreateModel(Provider provider)
        {
            return new ProviderViewModel
            {
                Id = provider.Id,
                FullName = provider.FullName,
                Password = provider.Password
            };
        }
    }
}