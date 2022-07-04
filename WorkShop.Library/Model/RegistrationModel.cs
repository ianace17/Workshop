using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Library.Model
{
    public class RegistrationModel
    {
        public int Type { get; set; }
        public AccountModel AccountDetails { get; set; } = new AccountModel();
        public List<UserModel> Users { get; set; } = new List<UserModel>();
        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();
        public List<BankModel> Banks { get; set; } = new List<BankModel>();
    }
}
