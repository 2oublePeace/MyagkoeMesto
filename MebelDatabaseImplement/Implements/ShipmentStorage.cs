using MebelBusinessLogic.BindnigModels;
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
	public class ShipmentStorage : IShipmentStorage
	{
        public List<ShipmentViewModel> GetFullList()
        {
            using (var context = new MebelDatabase())
            {
                return context.Shipments
                    .Include(rec => rec.ShipmentGarnitures)
                    .ThenInclude(rec => rec.Garniture)
                    .Select(CreateModel)
                    .ToList();
            }
        }
        public List<ShipmentViewModel> GetFilteredList(ShipmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                return context.Shipments
                    .Include(rec => rec.ShipmentGarnitures)
                    .ThenInclude(rec => rec.Garniture)
                    .Where(rec => rec.Date >= model.DateFrom && rec.Date <= model.DateTo)
                    .Select(CreateModel).ToList();
            }
        }

        public ShipmentViewModel GetElement(ShipmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new MebelDatabase())
            {
                var shipment = context.Shipments
                    .Include(rec => rec.ShipmentGarnitures)
                    .ThenInclude(rec => rec.Garniture)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return shipment != null ?
                CreateModel(shipment) : null;
            }
        }

        public void Insert(ShipmentBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Shipment(), context);
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

        public void Update(ShipmentBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var shipment = context.Shipments.FirstOrDefault(rec => rec.Id == model.Id);

                        if (shipment == null)
                        {
                            throw new Exception("Поставка не найдена");
                        }

                        CreateModel(model, shipment, context);
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

        public void Delete(ShipmentBindingModel model)
        {
            using (var context = new MebelDatabase())
            {
                Shipment element = context.Shipments.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Shipments.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Поступление не найдено");
                }
            }
        }

        private Shipment CreateModel(ShipmentBindingModel model, Shipment shipment, MebelDatabase context)
        {
            shipment.Date = model.Date;
            shipment.Name = model.Name;
            shipment.Price = model.Price;

            if (shipment.Id == 0)
            {
                context.Shipments.Add(shipment);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var shipmentGarnitures = context.ShipmentGarnitures
                     .Where(rec => rec.ShipmentId == model.Id.Value)
                     .ToList();

                context.ShipmentGarnitures.RemoveRange(shipmentGarnitures.ToList());

                context.SaveChanges();
            }

            foreach (var shipmentGarniture in model.ShipmentGarnitures)
            {
                context.ShipmentGarnitures.Add(new ShipmentGarniture
                {
                    ShipmentId = shipment.Id,
                    GarnitureId = shipmentGarniture.Key,
                    Count = shipmentGarniture.Value.Item2
                });
                context.SaveChanges();
            }
            return shipment;
        }

        private ShipmentViewModel CreateModel(Shipment shipment)
        {
            return new ShipmentViewModel
            {
                Id = shipment.Id,
                Date = shipment.Date,
                Name = shipment.Name,
                Price = shipment.Price,
                ShipmentGarnitures = shipment.ShipmentGarnitures
                            .ToDictionary(recShipmentGarnitures => recShipmentGarnitures.GarnitureId,
                            recShipmentGarnitures => (recShipmentGarnitures.Garniture?.Name, recShipmentGarnitures.Count)),
            };
        }
    }
}
