using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework.CQRS.Command
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public DeleteCustomerCommand(long customerID)
        {
            CustomerID = customerID;
        }

        public long CustomerID { get; }
    }
}
