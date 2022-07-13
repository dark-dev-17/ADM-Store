using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Service.Exceptions
{
    public class ExistsException: Exception
    {
        public ExistsException() { }

        public ExistsException(string message): base(message) { }
    }
}
