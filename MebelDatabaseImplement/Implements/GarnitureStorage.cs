using MebelBusinessLogic.BindnigModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using MebelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
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
                    .Include(rec => rec.GarnitureMaterial)
                    .Include(rec => rec.GarnitureMebel)
                    .Select(CreateModel)
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
                     .Include(rec => rec.GarnitureMaterial)
                    .Include(rec => rec.GarnitureMebel)
                    .Where(rec => rec.Id == model.Id)
                    .Select(CreateModel)
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
                var module = context.Garniture
                    .Include(rec => rec.GarnitureMaterial)
                    .ThenInclude(rec => rec.Material)
                    .Include(rec => rec.GarnitureMebel)
                    .ThenInclude(rec => rec.Mebel)
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return module != null ?
                    CreateModel(module) :
                    null;
            }
        }
        public void Insert(GarnitureBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Garniture(), context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(GarnitureBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var module = context.Garniture.FirstOrDefault(rec => rec.Id == model.Id);

                        if (module == null)
                        {
                            throw new Exception("Рецепт не найден");
                        }

                        CreateModel(model, module, context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(GarnitureBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                var module = context.Garniture.FirstOrDefault(rec => rec.Id == model.Id);

                if (module == null)
                {
                    throw new Exception("Рецепт не найден");
                }

                context.Garniture.Remove(module);
                context.SaveChanges();
            }
        }
        private GarnitureViewModel CreateModel(Garniture module)
        {
            return new GarnitureViewModel
            {
                Id = module.Id,
                Name = module.Name,
                Price = module.Price,


                GarnitureMebels = module.GarnitureMebel
                            .ToDictionary(recGarnitureMebels => recGarnitureMebels.MebelId,
                            recGarnitureMebels => (recGarnitureMebels.Mebel?.Name, recGarnitureMebels.Count)),
                GarnitureMaterials = module.GarnitureMaterial
                            .ToDictionary(recGarnitureMaterials => recGarnitureMaterials.MaterialId,
                            recGarnitureMaterials => (recGarnitureMaterials.Material?.Name, recGarnitureMaterials.Count))

            };

        }

        private Garniture CreateModel(GarnitureBindingModel model, Garniture module, MebelDatabase context)
        {
            module.Price = model.Price;
            module.Name = model.Name;

            if (module.Id == 0)
            {
                context.Garniture.Add(module);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var moduleMebels = context.GarnitureMebels
                    .Where(rec => rec.GarnitureId == model.Id.Value)
                    .ToList();

                context.GarnitureMebels.RemoveRange(moduleMebels.ToList());

                var moduleMaterials = context.GarnitureMaterials
                    .Where(rec => rec.GarnitureId == model.Id.Value)
                    .ToList();

                context.GarnitureMaterials.RemoveRange(moduleMaterials.ToList());

                context.SaveChanges();
            }

            foreach (var moduleMebel in model.GarnitureMebels)
            {
                context.GarnitureMebels.Add(new GarnitureMebel
                {
                    GarnitureId = module.Id,
                    MebelId = moduleMebel.Key,
                    Count = moduleMebel.Value.Item2
                });
                context.SaveChanges();
            }

            foreach (var moduleMaterials in model.GarnitureMaterials)
            {
                context.GarnitureMaterials.Add(new GarnitureMaterial
                {
                    GarnitureId = module.Id,
                    MaterialId = moduleMaterials.Key,
                    Count = moduleMaterials.Value.Item2
                });
                context.SaveChanges();
            }
            return module;
        }
    }
}
