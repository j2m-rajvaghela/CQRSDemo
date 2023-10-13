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
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly CustomerContext _customerContext;

        public DeleteCustomerCommandHandler(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId);
            if (customer != null)
            {
                _customerContext.Customers.Remove(customer);
                _customerContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Customer not found");
            }
        }
    }
}
