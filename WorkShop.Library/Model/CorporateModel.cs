using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Library.Model
{
    public class CorporateModel
    {
        public long AccountId { get; set; }
        public string CompanyName { get; set; }
        public string SecRegistrationNumber { get; set; }
        public string Tin { get; set; }
        public string OfficeAddress { get; set; }
        public string BusinessNature { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public int YearsInOperation { get; set; }
        public string FaxNo { get; set; }
    }
}
