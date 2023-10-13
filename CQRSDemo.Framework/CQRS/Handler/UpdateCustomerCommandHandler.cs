using CQRSDemo.Data;
using CQRSDemo.Framework.CQRS.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework.CQRS.Handler
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, long>
    {
        private readonly CustomerContext _customerContext;

        public UpdateCustomerCommandHandler(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<long> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
           var customer = await _customerContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == request.UpdateCustomer.CustomerId);
            {
                if (customer == null)
                {
                    return 0;
                }
                else
                {
                    customer.CustomerId = request.UpdateCustomer.CustomerId;
                    customer.Name = request.UpdateCustomer.Name;
                    customer.Email = request.UpdateCustomer.Email;
                    customer.Phone = request.UpdateCustomer.Phone;
                }
                try
                {
                    var response = await _customerContext.SaveChangesAsync();
                    if (response >= 1)
                    {
                        return customer.CustomerId;
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
    }
}
