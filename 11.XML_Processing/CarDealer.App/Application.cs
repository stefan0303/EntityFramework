using System.Data.Entity;
using System.Linq;
using System.Management.Instrumentation;
using System.Xml;
using System.Xml.Linq;

namespace CarDealer.App
{
    using System;

    using Data;
    using Models;

    public class Application
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //ImportSuppliers(context);
            //ImportParts(context);
            //ImportCars(context);
            //ImportCustomers(context);
            //ImportSales(context);
            //QueryCars(context);
            //QueryCarsMakeFerrari(context);
            //QueryLocalSuppliers(context);
            SalesWithAppliedDiscount(context);//ot videoto

            
        }
        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales //need reference to use Linq
                .Include(s => s.Car)
                .Include(s => s.Customer)
                .Include(s => s.Car.Parts)
                .Select(s => new
                    {
                        Car = new
                        {
                            Make = s.Car.Make,
                            Model = s.Car.Model,
                            TravelledDistance = s.Car.TravelledDistance
                        },
                        CustomerName = s.Customer.Name,
                        Discount = s.Discount,
                        Price = s.Car.Parts.Sum(p=>p.Price),
                        PriceWithDiscount =s.Car.Parts.Sum(p=>p.Price)*(1.0m -s.Discount)
                    }
                );
            XDocument salesDocument =new XDocument();
            XElement salesXml =new XElement("sales");
            foreach (var sale in sales)
            {
                XElement saleXml =new XElement("sale");
                XElement car =new XElement("car");
                car.SetAttributeValue("make",sale.Car.Make);
                car.SetAttributeValue("model", sale.Car.Model);
                car.SetAttributeValue("distance-travelled", sale.Car.TravelledDistance);

                XElement customer = new XElement("customer-name");
                customer.Value = sale.CustomerName;

                XElement discount =new XElement("discount");
                discount.Value = sale.Discount.ToString();

                XElement price =new XElement("price");
                price.Value = sale.Price.ToString();

                XElement priceWithDiscount =new XElement("price-with-discount");
                priceWithDiscount.Value = sale.PriceWithDiscount.ToString();

                saleXml.Add(car);
                saleXml.Add(customer);
                saleXml.Add(discount);
                saleXml.Add(price);
                saleXml.Add(priceWithDiscount);

                saleXml.Add(saleXml);

            }
            salesDocument.Add(salesXml);
            salesDocument.Save("../../../SalesWithAppliedDiscount.xml");
        }
        private static void QueryLocalSuppliers(CarDealerContext context)//TODO
        {   
            var suppliers = context.Suppliers.Where(s => s.IsImporter == false).Distinct();
                
            foreach (var supplier in suppliers)
            {
                Console.WriteLine(supplier.Name);
                Console.WriteLine(supplier.Parts.Count);
               break;
            
            } 

            //var xmlDocument = new XElement("carsFerrary");
            //foreach (var car in cars)
            //{
            //    var carsNode = new XElement("car");
            //    carsNode.Add(new XAttribute("model", car.Model));
            //    carsNode.Add(new XAttribute("travelled-distance", car.TravelledDistance));

            //    xmlDocument.Add(carsNode);
            //}
            //xmlDocument.Save("../../../carsFerrary.xml");
        }
        private static void QueryCarsMakeFerrari(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.Make == "Ferrari").OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance)
                .Select(car => new
                {
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                }
                );
         
            var xmlDocument = new XElement("carsFerrary");
            foreach (var car in cars)
            {
                var carsNode = new XElement("car");
                carsNode.Add(new XAttribute("model", car.Model));
                carsNode.Add(new XAttribute("travelled-distance", car.TravelledDistance));
              
                xmlDocument.Add(carsNode);
            }
            xmlDocument.Save("../../../carsFerrary.xml");
        }
        private static void QueryCars(CarDealerContext context)
        {
            var cars = context.Cars.Where(d => d.TravelledDistance > 2000000)
                .OrderBy(m => m.Make)
                .ThenBy(m => m.Model)
                .Select(car => new
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                }
                );
            // XDocument carsDocument = new XDocument();
            var xmlDocument = new XElement("cars");
            foreach (var car in cars)
            {
                var carsNode = new XElement("car");
                carsNode.Add(new XAttribute("make", car.Make));
                carsNode.Add(new XAttribute("model", car.Model));
                carsNode.Add(new XAttribute("travelled-distance", car.TravelledDistance));

                xmlDocument.Add(carsNode);

            }
            xmlDocument.Save("../../../cars.xml");
        }
        private static void ImportSales(CarDealerContext context)
        {
            int carsCount = context.Cars.Count();
            int customersCount = context.Customers.Count();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                Sale sale = new Sale()
                {
                    CarId = rnd.Next(1, carsCount + 1),
                    CustomerId = rnd.Next(1, customersCount + 1),
                    Discount = i % 2 == 0 ? 0.05M : 0.00M
                };
                context.Sales.Add(sale);
            }
            context.SaveChanges();
        }
        private static void ImportCustomers(CarDealerContext context)
        {
            XDocument customersXML = XDocument.Load("../../../Xml-files/customers.xml");
            XElement customersRoot = customersXML.Root;

            /* < customers >
   < customer name = "Emmitt Benally" >
      < birth - date > 1993 - 11 - 20T00: 00:00 </ birth - date >
                <is- young - driver > true </is- young - driver >          
              </ customer >
              */
            foreach (XElement customerElementh in customersRoot.Elements())
            {
                string name = customerElementh.Attribute("name").Value;
                DateTime date = DateTime.Parse(customerElementh.Element("birth-date").Value);
                bool isYoung = bool.Parse(customerElementh.Element("is-young-driver").Value);

                Customer customer = new Customer()
                {
                    Name = name,
                    BirthDate = date,
                    IsYoungDriver = isYoung
                };
                context.Customers.Add(customer);

            }
            context.SaveChanges();
        }
        private static void ImportSuppliers(CarDealerContext context)
        {
            XDocument suppliersXML = XDocument.Load("../../../Xml-files/suppliers.xml");
            XElement suppliersRoot = suppliersXML.Root;

            //<supplier name="3M Company" is-importer="true" />
            foreach (var supplierElementh in suppliersRoot.Elements())
            {
                string name = supplierElementh.Attribute("name")?.Value; //? make name null if there is no name
                bool isImported = bool.Parse(supplierElementh.Attribute("is-importer").Value);
                Supplier sup = new Supplier()
                {
                    Name = name,
                    IsImporter = isImported
                };
                context.Suppliers.Add(sup);
                context.SaveChanges();
                //Console.WriteLine(name + " " + isImported);
            }
        }
        private static void ImportParts(CarDealerContext context)
        {
            XDocument partsXML = XDocument.Load("../../../Xml-files/parts.xml");
            XElement partsRoot = partsXML.Root;

            //<part name="Bonnet/hood" price="1001.34" quantity="10" />
            int number = 0;
            int suppliersCount = context.Suppliers.Count();
            foreach (var partElementh in partsRoot.Elements())
            {
                string name = partElementh.Attribute("name").Value;
                decimal price = decimal.Parse(partElementh.Attribute("price").Value);
                int quantity = int.Parse(partElementh.Attribute("quantity").Value);

                Part part = new Part()
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity,
                    SupplierId = number % suppliersCount + 1 //Randome add SuppliersId
                };
                context.Parts.Add(part);
                number++;

            }
            context.SaveChanges();
        }
        private static void ImportCars(CarDealerContext context)
        {
            XDocument carsXML = XDocument.Load("../../../Xml-files/cars.xml");
            XElement carsRoot = carsXML.Root;
            /* 
           < car >
             < make > Opel </ make >
             < model > Omega </ model >
             < travelled - distance > 2147483647 </ travelled - distance >
           </ car >
           */
            foreach (XElement carElement in carsRoot.Elements())
            {
                string make = carElement.Element("make").Value;
                string model = carElement.Element("model").Value;
                // decimal price = decimal.Parse(partElementh.Attribute("price").Value);
                long distance = long.Parse(carElement.Element("travelled-distance").Value);//travel-distance without space

                Car car = new Car()
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = distance
                };
                int partsCount = context.Parts.Count();
                for (int i = 0; i < 10 + (i % 10); i++)
                {
                    Part p = context.Parts.Find(carElement.GetHashCode() % partsCount + 1 + i);
                    car.Parts.Add(p);
                }
                context.Cars.Add(car);
            }
            context.SaveChanges();
        }
    }
}

