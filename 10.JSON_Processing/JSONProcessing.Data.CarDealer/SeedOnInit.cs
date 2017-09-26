using JSONProcessing.Common;
using JSONProcessing.Models.CarDealer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JSONProcessing.Data.CarDealer
{
    public class SeedOnInit : CreateDatabaseIfNotExists<CarDealerContext>
    {
        protected override void Seed(CarDealerContext context)
        {
            var suppliers = Importer<Supplier>.ImportFromJSON().ToList();
            var parts = Importer<Part>.ImportFromJSON().ToList();
            var customers = Importer<Customer>.ImportFromJSON().ToList();
            var cars = Importer<Car>.ImportFromJSON().ToList();
            //var sales = Importer<Sale>.ImportFromJSON();
            var sales = new List<Sale>();
            decimal[] discounts = {
                0, 0.05m, 0.1m, 0.15m, 0.2m, 0.3m, 0.4m, 0.5m
            };
            Random rnd = new Random();

            foreach (var part in parts)
            {
                part.Supplier = suppliers[rnd.Next(suppliers.Count)];
            }

            foreach (var car in cars)
            {
                for (int i = 0; i <= rnd.Next(10, 20); i++)
                {
                    car.Parts.Add(parts[rnd.Next(parts.Count)]);
                }
            }


            for (int i = 0; i < 100; i++)
            {
                var sale = new Sale()
                {
                    Car = cars[rnd.Next(cars.Count)],
                    Customer = customers[rnd.Next(customers.Count)],
                    Discount = discounts[rnd.Next(discounts.Length)]
                };
                if (!sales.Contains(sale))
                {
                    sales.Add(sale);
                }
            }

            context.Suppliers.AddRange(suppliers);
            context.Parts.AddRange(parts);
            context.Cars.AddRange(cars);
            context.Customers.AddRange(customers);
            context.Sales.AddRange(sales);

            base.Seed(context);
        }
    }
}
