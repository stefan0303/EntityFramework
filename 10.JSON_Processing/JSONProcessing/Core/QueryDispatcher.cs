using JSONProcessing.Core.Queries;
using System;

namespace JSONProcessing.Core
{
    public class QueryDispatcher : IDispatcher
    {
        public string Dispatch(string[] data)
        {
            byte issueId;
            var result = string.Empty;
            Query query = null;
            var defaultError = "Invalid query option selected! "
                               + "Available queries from 1 to 10 inclusive.";
            try
            {
                issueId = Convert.ToByte(data[0]);
            }
            catch
            {
                throw new ArgumentException(defaultError);
            }

            switch (issueId)
            {
                case 1:
                    query = new QueryProductsInRange();
                    break;
                case 2:
                    query = new QuerySuccessfullySoldProducts();
                    break;
                case 3:
                    query = new QueryCategoriesByProductsCount();
                    break;
                case 4:
                    query = new QueryUsersAndProducts();
                    break;
                case 5:
                    query = new QueryOrderedCustomers();
                    break;
                case 6:
                    query = new QueryCarsFromMakeToyota();
                    break;
                case 7:
                    query = new QueryLocalSuppliers();
                    break;
                case 8:
                    query = new QueryCarsWithTheirListOfParts();
                    break;
                case 9:
                    query = new QueryTotalSalesByCustomer();
                    break;
                case 10:
                    query = new QuerySalesWithAppliedDiscount();
                    break;
                default:
                    throw new ArgumentException(defaultError);
            }
            result = query.Execute();

            Console.WriteLine("Do you want to export the results from the query? Y/N");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                query.Export();
                Console.WriteLine("Export successful! " +
                                  "You can find the exported file in App_Data/Exports " +
                                  "folder in the Projects' directory.\n" +
                                  "Let me show you what I have exported! (push any button to proceed)");
                Console.ReadKey(true);
            }

            return result;
        }
    }
}
