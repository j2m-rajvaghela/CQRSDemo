using CQRSDemo.Framework.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework.CQRS.Command
{
    public class UpdateCustomerCommand : IRequest<long>
    {
        public UpdateCustomerCommand(UpdateCustomerRequest updateCustomer)
        {
            UpdateCustomer = updateCustomer;
        }

        public UpdateCustomerRequest UpdateCustomer { get; }
    }
}
