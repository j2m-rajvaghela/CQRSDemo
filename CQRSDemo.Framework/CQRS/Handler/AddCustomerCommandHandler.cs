using CQRSDemo.Data;
using CQRSDemo.Framework.CQRS.Command;
using CQRSDemo.Framework.Factory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework.CQRS.Handler
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, long>
    {
        private readonly CustomerContext _customerContext;

        public AddCustomerCommandHandler(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<long> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEmailIsExists = await _customerContext.Customers.AnyAsync(c => c.Email == request.AddCustomer.Email);
            if (customerEmailIsExists)
            {
                throw new Exception("Customer already exists with this email");
            }

            var customerPhoneIsExists = await _customerContext.Customers.AnyAsync(c => c.Phone == request.AddCustomer.Phone);
            if (customerPhoneIsExists)
            {
                throw new Exception("Customer already exists with this phone");
            }

            var customer = CustomerFactory.MapToAddCustomerRequest(request.AddCustomer);
            if (customer == null)
            {
                return 0;
            }
            try
            {
                var addedCustomer = await _customerContext.Customers.AddAsync(customer);
                var response = await _customerContext.SaveChangesAsync();

                if (response >= 1)
                {
                    return customer.CustomerID;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
