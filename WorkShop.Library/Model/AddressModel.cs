using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Library.Model
{
    public class AddressModel
    {
        public long ID { get; set; }
        public long AccountId { get; set; }
        public string HouseNo { get; set; }
        public string Streetname { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public int Status { get; set; }
    }
}
