using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Infra.Messaging
{
    public interface IMessageBusService
    {
        void Publish(object data,string routingKey);
    }
}
