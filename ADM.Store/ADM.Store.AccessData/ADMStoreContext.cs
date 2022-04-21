using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData
{
    public class ADMStoreContext: DbContext
    {
        public ADMStoreContext()
        {

        }
        public ADMStoreContext(DbContextOptions<ADMStoreContext> options): base(options)
        {

        }
    }
}
