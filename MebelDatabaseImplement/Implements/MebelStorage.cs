using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using MebelDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MebelDatabaseImplement.Implements
{
	public class MebelStorage : IMebelStorage
	{
        public List<MebelViewModel> GetFullList()
        {
            using (var context = new MebelDatabase())
            {
                return context.Mebel
                .Select(rec => new MebelViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                })
               .ToList();
            }
        }
        public List<MebelViewModel> GetFilteredList(MebelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                return context.Mebel
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(rec => new MebelViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                })
                .ToList();
            }
        }
        public MebelViewModel GetElement(MebelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                var component = context.Mebel
                .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
                return component != null ?
                new MebelViewModel
                {
                    Id = component.Id,
                    Name = component.Name
                } :
                null;
            }
        }
        public void Insert(MebelBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                context.Mebel.Add(CreateModel(model, new Mebel()));
                context.SaveChanges();
            }
        }
        public void Update(MebelBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                var element = context.Mebel.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(MebelBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                Mebel element = context.Mebel.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Mebel.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Mebel CreateModel(MebelBindingModel model, Mebel Mebel)
        {
            Mebel.Name = model.Name;
            return Mebel;
        }
	}
}
