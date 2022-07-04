using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Library.Model
{
    public class AccountModel
    {
        public long ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string TelNo { get; set; }
        public string MobileNo { get; set; }
        public char Nationality { get; set; }
        public string SpouseName { get; set; }
        public string Tin { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string BusinessNature { get; set; }
        public string EmployerName { get; set; }
        public string BusinessAddress { get; set; }
        public string TCCode { get; set; }
        public string TraderID { get; set; }
        public string ClientCode { get; set; }
        public string PdtcSubAccount { get; set; }
        public string AccountOwnership { get; set; }
        public string AccountType { get; set; }
        public decimal BrokerCommission { get; set; }
        public decimal MinumumCommission { get; set; }
        public int Status { get; set; }
        public char CivilStatus { get; set; }
    }
}
