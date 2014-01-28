using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SaleClassLibrary
{
    [ServiceContract]
    interface ISaleService
    {
        [OperationContract]
        bool InsertCustomer(Customer obj);

        [OperationContract]
        List<Customer> GetAllCustomer();

        [OperationContract]
        bool DeleteCustomer(int cid);

        [OperationContract]
        bool UpdateCustomer(Customer obj);

        [OperationContract]
        string GetRottenTomatoesMovieInfo(string queryString);
    }

    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
