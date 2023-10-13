using CQRSDemo.Framework.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework.CQRS.Command
{
    public class AddCustomerCommand : IRequest<long>
    {
        public AddCustomerCommand(AddCustomerRequest addCustomer)
        {
            AddCustomer = addCustomer;
        }

        public AddCustomerRequest AddCustomer { get; }
    }
}
