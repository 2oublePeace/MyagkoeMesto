using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using SecureShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecureShopDatabaseImplement.Implements
{
    public class ModuleStorage : IModuleStorage
    {
        public List<ModuleViewModel> GetFullList()
        {
            using (var context = new MebelShopDatabase())
            {
                return context.Modules
                    .Include(rec => rec.ModuleMaterial)
                    .ThenInclude(rec => rec.Material)
                    .ToList()
                    .Select(rec => new ModuleViewModel
                    {
                        Id = rec.Id,
                        ModuleName = rec.ModuleName,
                        Price = rec.Price,
                        ModuleMaterials = rec.ModuleMaterial
                            .ToDictionary(recModuleMaterials => recModuleMaterials.MaterialId,
                            recModuleMaterials => (recModuleMaterials.Material?.MaterialName,
                            recModuleMaterials.Count))
                    })
                    .ToList();
            }
        }
        public List<ModuleViewModel> GetFilteredList(ModuleBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new MebelShopDatabase())
            {
                return context.Modules
                    .Include(rec => rec.ModuleMaterial)
                    .ThenInclude(rec => rec.Material)
                    .Where(rec => rec.ModuleName.Contains(model.ModuleName))
                    .ToList()
                    .Select(rec => new ModuleViewModel
                    {
                        Id = rec.Id,
                        ModuleName = rec.ModuleName,
                        Price = rec.Price,
                        ModuleMaterials = rec.ModuleMaterial
                            .ToDictionary(recModuleMaterials => recModuleMaterials.MaterialId,
                            recModuleMaterials => (recModuleMaterials.Material?.MaterialName,
                            recModuleMaterials.Count))
                    })
                    .ToList();
            }
        }
        public ModuleViewModel GetElement(ModuleBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new MebelShopDatabase())
            {
                var module = context.Modules
                    .Include(rec => rec.ModuleMaterial)
                    .ThenInclude(rec => rec.Material)
                    .FirstOrDefault(rec => rec.ModuleName == model.ModuleName ||
                    rec.Id == model.Id);

                return module != null ?
                    new ModuleViewModel
                    {
                        Id = module.Id,
                        ModuleName = module.ModuleName,
                        Price = module.Price,
                        ModuleMaterials = module.ModuleMaterial
                            .ToDictionary(recModuleMaterial => recModuleMaterial.MaterialId,
                            recModuleMaterial => (recModuleMaterial.Material?.MaterialName,
                            recModuleMaterial.Count))
                    } :
                    null;
            }
        }
        public void Insert(ModuleBindingModel model)
        {
            using (var context = new MebelShopDatabase())
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
            using (var context = new MebelShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var module = context.Modules.FirstOrDefault(rec => rec.Id == model.Id);

                        if (module == null)
                        {
                            throw new Exception("Подарок не найден");
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
            using (var context = new MebelShopDatabase())
            {
                var Material = context.Modules.FirstOrDefault(rec => rec.Id == model.Id);

                if (Material == null)
                {
                    throw new Exception("Материал не найден");
                }

                context.Modules.Remove(Material);
                context.SaveChanges();
            }
        }
        private Module CreateModel(ModuleBindingModel model, Module module, MebelShopDatabase context)
        {
            module.ModuleName = model.ModuleName;
            module.Price = model.Price;
            if (module.Id == 0)
            {
                context.Modules.Add(module);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var moduleMaterial = context.ModuleMaterials
                    .Where(rec => rec.ModuleId == model.Id.Value)
                    .ToList();

                context.ModuleMaterials.RemoveRange(moduleMaterial
                    .Where(rec => !model.ModuleMaterials.ContainsKey(rec.ModuleId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateMaterial in moduleMaterial)
                {
                    updateMaterial.Count = model.ModuleMaterials[updateMaterial.MaterialId].Item2;
                    model.ModuleMaterials.Remove(updateMaterial.ModuleId);
                }
                context.SaveChanges();
            }
            foreach (var moduleMaterial in model.ModuleMaterials)
            {
                context.ModuleMaterials.Add(new ModuleMaterial
                {
                    ModuleId = module.Id,
                    MaterialId = moduleMaterial.Key,
                    Count = moduleMaterial.Value.Item2
                });
                context.SaveChanges();
            }
            return module;
        }
    }
}