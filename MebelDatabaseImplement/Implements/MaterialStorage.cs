using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using MebelDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MebelDatabaseImplement.Implements
{
    public class MaterialStorage : IMaterialStorage
    {
        public List<MaterialViewModel> GetFullList()
        {
            using (var context = new MebelDatabase())
            {
                return context.Materials
                .Select(rec => new MaterialViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Price = rec.Price
                })
               .ToList();
            }
        }
        public List<MaterialViewModel> GetFilteredList(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                return context.Materials
                .Where(rec => rec.Name.Contains(model.Name))
               .Select(rec => new MaterialViewModel
               {
                   Id = rec.Id,
                   Name = rec.Name,
                   Price = rec.Price
               })
                .ToList();
            }
        }
        public MaterialViewModel GetElement(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                var component = context.Materials
                .FirstOrDefault(rec => rec.Name == model.Name ||
               rec.Id == model.Id);
                return component != null ?
                new MaterialViewModel
                {
                    Id = component.Id,
                    Name = component.Name,
                    Price = component.Price
                } :
               null;
            }
        }
        public void Insert(MaterialBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                context.Materials.Add(CreateModel(model, new Material()));
                context.SaveChanges();
            }
        }
        public void Update(MaterialBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                var element = context.Materials.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
            {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(MaterialBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                Material element = context.Materials.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Materials.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Material CreateModel(MaterialBindingModel model, Material material)
        {
            material.Name = model.Name;
            material.Price = model.Price;
            return material;
        }
    }
}