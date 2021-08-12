using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using MebelDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MebelDatabaseImplement.Implements
{
	public class GarnitureStorage : IGarnitureStorage
	{
        public List<GarnitureViewModel> GetFullList()
        {
            using (var context = new MebelDatabase())
            {
                return context.Garniture
                .Select(rec => new GarnitureViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                })
               .ToList();
            }
        }
        public List<GarnitureViewModel> GetFilteredList(GarnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                return context.Garniture
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(rec => new GarnitureViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                })
                .ToList();
            }
        }
        public GarnitureViewModel GetElement(GarnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                var component = context.Garniture
                .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
                return component != null ?
                new GarnitureViewModel
                {
                    Id = component.Id,
                    Name = component.Name
                } :
                null;
            }
        }
        public void Insert(GarnitureBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                context.Garniture.Add(CreateModel(model, new Garniture()));
                context.SaveChanges();
            }
        }
        public void Update(GarnitureBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                var element = context.Garniture.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(GarnitureBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                Garniture element = context.Garniture.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Garniture.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Garniture CreateModel(GarnitureBindingModel model, Garniture garniture)
        {
            garniture.Name = model.Name;
            return garniture;
        }
	}
}
