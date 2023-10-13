using CQRSDemo.Data.Entitie;
using CQRSDemo.Framework.Request;
using CQRSDemo.Framework.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework.Factory
{
    public class CustomerFactory
    {
        public static List<CustomerResponse> MapToCustomerResponseCollection(IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                return null;
            }
            ICollection<CustomerResponse> response = new List<CustomerResponse>();
            foreach (var customer in customers)
            {
                response.Add(MapToCustomerResponse(customer));
            }
            return response.ToList();
        }

        public static CustomerResponse MapToCustomerResponse(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }
            CustomerResponse response = new CustomerResponse();
            response.CustomerId = customer.CustomerId;
            response.Name = customer.Name;
            response.Email = customer.Email;
            response.Phone = customer.Phone;
            return response;
        }

        public static Customer MapToAddCustomerRequest(AddCustomerRequest addCustomer)
        {
            if (addCustomer == null)
            {
                return null;
            }
            Customer customer = new Customer();
            customer.Name = addCustomer.Name;
            customer.Email = addCustomer.Email;
            customer.Phone = addCustomer.Phone;
            return customer;
        }

        public static CustomerByIdResponse MapToCustomerByIdResponse(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }
            CustomerByIdResponse response = new CustomerByIdResponse();
            response.CustomerId = customer.CustomerId;
            response.Name = customer.Name;
            response.Email = customer.Email;
            response.Phone = customer.Phone;
            return response;
        }
    }
}
