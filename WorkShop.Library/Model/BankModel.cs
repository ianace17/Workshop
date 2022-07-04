using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Library.Model
{
    public class BankModel
    {
        public long ID { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string AccountNo { get; set; }
        public int Status { get; set; }
    }
}
