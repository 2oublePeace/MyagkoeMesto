using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.Interfaces;
using MebelBusinessLogic.ViewModels;
using SecureShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecureShopDatabaseImplement.Implements
{
    public class SupplyStorage : ISupplyStorage
    {
        public List<SupplyViewModel> GetFullList()
        {
            using (var context = new MebelShopDatabase())
            {
                return context.Orders
                    .Select(rec => new SupplyViewModel
                    {
                        Id = rec.Id,
                        ModuleName = rec.Module.ModuleName,
                        MaterialId = rec.MaterialId,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
                    })
                    .ToList();
            }
        }
        public List<SupplyViewModel> GetFilteredList(SupplyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new MebelShopDatabase())
            {
                return context.Orders
                    .Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                .Select(rec => new SupplyViewModel
                {
                    Id = rec.Id,
                    ModuleName = rec.Module.ModuleName,
                    MaterialId = rec.MaterialId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                })
                    .ToList();
            }
        }
        public SupplyViewModel GetElement(SupplyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new MebelShopDatabase())
            {
                var supply = context.Orders
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return supply != null ?
                    new SupplyViewModel
                    {
                        Id = supply.Id,
                        ModuleName = context.Modules.FirstOrDefault(rec => rec.Id == supply.MaterialId)?.ModuleName,
                        MaterialId = supply.MaterialId,
                        Count = supply.Count,
                        Sum = supply.Sum,
                        Status = supply.Status,
                        DateCreate = supply.DateCreate,
                        DateImplement = supply.DateImplement
                    } :
                    null;
            }
        }
        public void Insert(SupplyBindingModel model)
        {
            using (var context = new MebelShopDatabase())
            {
                context.Orders.Add(CreateModel(model, new Supply()));
                context.SaveChanges();
            }
        }
        public void Update(SupplyBindingModel model)
        {
            using (var context = new MebelShopDatabase())
            {
                var supply = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (supply == null)
                {
                    throw new Exception("Заказ не найден");
                }

                CreateModel(model, supply);
                context.SaveChanges();
            }
        }
        public void Delete(SupplyBindingModel model)
        {
            using (var context = new MebelShopDatabase())
            {
                var supply = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (supply == null)
                {
                    throw new Exception("Заказ не найден");
                }

                context.Orders.Remove(supply);
                context.SaveChanges();
            }
        }
        private Supply CreateModel(SupplyBindingModel model, Supply supply)
        {
            supply.MaterialId = model.MaterialId;
            supply.Sum = model.Sum;
            supply.Count = model.Count;
            supply.Status = model.Status;
            supply.DateCreate = model.DateCreate;
            supply.DateImplement = model.DateImplement;

            return supply;
        }
    }
}