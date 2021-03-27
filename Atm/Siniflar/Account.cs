using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm.Siniflar
{
    public class Account
    {
        public  int Id { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
        public decimal AccountMoney { get; set; }
        public string AccountNumber { get; set; }
        public string AccountPassword { get; set; }
    }
}
