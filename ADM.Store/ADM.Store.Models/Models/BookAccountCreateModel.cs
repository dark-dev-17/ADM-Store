using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models
{
    public class BookAccountCreateModel
    {
        public Guid idClient { get; set; }
        public int typeAccount { get; set; }
    }
}
