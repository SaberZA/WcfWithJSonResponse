using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesServiceHost.Common;

namespace SaleClassLibrary
{
    public class SaleService : ISaleService
    {
        private static List<Customer> CustomerList = new List<Customer>()
            {
                new Customer {CustomerId = 1, CustomerName = "Steven", Address = "PMB", Email = "test@gmail.com"},
                new Customer {CustomerId = 2, CustomerName = "Rudi", Address = "PMB", Email = "test@gmail.com"},
                new Customer {CustomerId = 3, CustomerName = "Paul", Address = "PMB", Email = "test@gmail.com"}
            };

        public string JsonResponse { get; set; }

        public bool InsertCustomer(Customer obj)
        {
            CustomerList.Add(obj);
            return true;
        }

        public List<Customer> GetAllCustomer()
        {
            return CustomerList;
        }

        public bool DeleteCustomer(int cid)
        {
            var item = CustomerList.FirstOrDefault(customer => customer.CustomerId == cid);
            if (item != null)
            {
                CustomerList.Remove(item);
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer obj)
        {
            CustomerList
                .Where(cust => cust.CustomerId == obj.CustomerId)
                .Update(cust => cust.CustomerName = obj.CustomerName);
            return true;
        }

        public string GetRottenTomatoesMovieInfo(string queryString)
        {
            RtWebClient client = new RtWebClient(false);

            JsonResponse = client.DownloadString(queryString);
            //"http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey=8rnf67ztabgzkyfgekzptazj&q=Toy+Story+3"
            return JsonResponse;
        }
    }

    public static class LinqUpdates
    {
        public static void Update<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
