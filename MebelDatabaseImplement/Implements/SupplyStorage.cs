using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using MebelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MebelDatabaseImplement.Implements
{
    public class SupplyStorage : ISupplyStorage
    {
        public List<SupplyViewModel> GetFullList()
        {
            using (var context = new MebelDatabase())
            {
                return context.Supplys
                    .Include(rec => rec.SupplyMaterials)
                    .ThenInclude(rec => rec.Material)
                    .Select(CreateModel)
                    .ToList();
            }
        }
        public List<SupplyViewModel> GetFilteredList(SupplyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                return context.Supplys
                    .Include(rec => rec.SupplyMaterials)
                    .ThenInclude(rec => rec.Material)
                    .Where(rec => rec.Date >= model.DateFrom && rec.Date <= model.DateTo)
                    .Select(CreateModel).ToList();
            }
        }

        public SupplyViewModel GetElement(SupplyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                var supply = context.Supplys
                    .Include(rec => rec.SupplyMaterials)
                    .ThenInclude(rec => rec.Material)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return supply != null ?
                CreateModel(supply) : null;
            }
        }

        public void Insert(SupplyBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Supply(), context);
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

        public void Update(SupplyBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var supply = context.Supplys.FirstOrDefault(rec => rec.Id == model.Id);

                        if (supply == null)
                        {
                            throw new Exception("Поставка не найдена");
                        }

                        CreateModel(model, supply, context);
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

        public void Delete(SupplyBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                Supply element = context.Supplys.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Supplys.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Поступление не найдено");
                }
            }
        }

        private Supply CreateModel(SupplyBindingModel model, Supply supply, MebelDatabase context)
        {
            supply.Date = model.Date;
            supply.Name = model.Name;
            supply.Price = model.Price;

            if (supply.Id == 0)
            {
                context.Supplys.Add(supply);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var supplyMaterials = context.SupplyMaterials
                     .Where(rec => rec.SupplyId == model.Id.Value)
                     .ToList();

                context.SupplyMaterials.RemoveRange(supplyMaterials.ToList());

                context.SaveChanges();
            }

            foreach (var supplyMaterial in model.SupplyMaterials)
            {
                context.SupplyMaterials.Add(new SupplyMaterial
                {
                    SupplyId = supply.Id,
                    MaterialId = supplyMaterial.Key,
                    Count = supplyMaterial.Value.Item2
                });
                context.SaveChanges();
            }
            return supply;
        }

        private SupplyViewModel CreateModel(Supply supply)
        {
            return new SupplyViewModel
            {
                Id = supply.Id,
                Date = supply.Date,
                Name = supply.Name,
                Price = supply.Price,
                SupplyMaterials = supply.SupplyMaterials
                            .ToDictionary(recSupplyMaterials => recSupplyMaterials.MaterialId,
                            recSupplyMaterials => (recSupplyMaterials.Material?.Name, recSupplyMaterials.Count)),
            };
        }
    }
}