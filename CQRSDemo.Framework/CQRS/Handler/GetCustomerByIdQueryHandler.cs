using CQRSDemo.Data;
using CQRSDemo.Framework.CQRS.Query;
using CQRSDemo.Framework.Factory;
using CQRSDemo.Framework.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework.CQRS.Handler
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerByIdResponse>
    {
        private readonly CustomerContext _customerContext;

        public GetCustomerByIdQueryHandler(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<CustomerByIdResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerContext.Customers.FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID);
                if (customer == null)
                {
                    return null;
                }
                return CustomerFactory.MapToCustomerByIdResponse(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
