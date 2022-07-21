using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Service.Responses
{
    public class ResTypeService<T>
    {
        public string levelError { get; set; } = null!;
        public int ErrorCode { get; set; }
        public T? Data { get; set; }
        public string ErrorMessage { get; set; } = null!;
    }
}
