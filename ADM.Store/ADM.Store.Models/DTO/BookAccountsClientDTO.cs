using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.DTO
{
    public class BookAccountsClientDTO
    {
        public ClientDTO? Client { get; set; }
        public List<BookAccountDTO> Cuentas { get; set; }
    }
}
