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
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerResponse>>
    {
        private readonly CustomerContext _customerContext;

        public GetAllCustomerQueryHandler(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public async Task<List<CustomerResponse>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _customerContext.Customers.ToListAsync();
                if (customers == null)
                {
                    return null;
                }
                return CustomerFactory.MapToCustomerResponseCollection(customers);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
