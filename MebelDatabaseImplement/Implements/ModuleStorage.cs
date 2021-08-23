using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using MebelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MebelDatabaseImplement.Implements
{
    public class ModuleStorage : IModuleStorage
    {
        public List<ModuleViewModel> GetFullList()
        {
            using (var context = new MebelDatabase())
            {
                return context.Modules
                    .Include(rec => rec.ModuleMaterial)
                    .Include(rec => rec.ModuleMebel)
                    .Select(CreateModel)
                    .ToList();
            }
        }
        public List<ModuleViewModel> GetFilteredList(ModuleBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new MebelDatabase())
            {
                return context.Modules
                     .Include(rec => rec.ModuleMaterial)
                    .Include(rec => rec.ModuleMebel)
                    .Where(rec => rec.Id == model.Id)
                    .Select(CreateModel)
                    .ToList();
            }
        }
        public ModuleViewModel GetElement(ModuleBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new MebelDatabase())
            {
                var module = context.Modules
                    .Include(rec => rec.ModuleMaterial)
                    .ThenInclude(rec => rec.Material)
                    .Include(rec => rec.ModuleMebel)
                    .ThenInclude(rec => rec.Mebel)
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return module != null ?
                    CreateModel(module) :
                    null;
            }
        }
        public void Insert(ModuleBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Module(), context);
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
        public void Update(ModuleBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var module = context.Modules.FirstOrDefault(rec => rec.Id == model.Id);

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
        public void Delete(ModuleBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                var module = context.Modules.FirstOrDefault(rec => rec.Id == model.Id);

                if (module == null)
                {
                    throw new Exception("Рецепт не найден");
                }

                context.Modules.Remove(module);
                context.SaveChanges();
            }
        }
        private ModuleViewModel CreateModel(Module module)
        {
            return new ModuleViewModel
            {
                Id = module.Id,
                Name = module.Name,
                Price = module.Price,
               

                ModuleMebels = module.ModuleMebel
                            .ToDictionary(recModuleMebels => recModuleMebels.MebelId,
                            recModuleMebels => (recModuleMebels.Mebel?.Name, recModuleMebels.Count)),
                ModuleMaterials = module.ModuleMaterial
                            .ToDictionary(recModuleMaterials => recModuleMaterials.MaterialId,
                            recModuleMaterials => (recModuleMaterials.Material?.Name, recModuleMaterials.Count))

            };

        }

        private Module CreateModel(ModuleBindingModel model, Module module, MebelDatabase context)
        {
            module.Price = model.Price;
            module.Name = module.Name;

            if (module.Id == 0)
            {
                context.Modules.Add(module);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var moduleMebels = context.ModuleMebels
                    .Where(rec => rec.ModuleId == model.Id.Value)
                    .ToList();

                context.ModuleMebels.RemoveRange(moduleMebels.ToList());

                var moduleMaterials = context.ModuleMaterials
                    .Where(rec => rec.ModuleId == model.Id.Value)
                    .ToList();

                context.ModuleMaterials.RemoveRange(moduleMaterials.ToList());

                context.SaveChanges();
            }

            foreach (var moduleMebel in model.ModuleMebels)
            {
                context.ModuleMebels.Add(new ModuleMebel
                {
                    ModuleId = module.Id,
                    MebelId = moduleMebel.Key,
                    Count = moduleMebel.Value.Item2
                });
                context.SaveChanges();
            }

            foreach (var moduleMaterials in model.ModuleMaterials)
            {
                context.ModuleMaterials.Add(new ModuleMaterial
                {
                    ModuleId = module.Id,
                    MaterialId = moduleMaterials.Key,
                    Count = moduleMaterials.Value.Item2
                });
                context.SaveChanges();
            }
            return module;
        }
    }
}