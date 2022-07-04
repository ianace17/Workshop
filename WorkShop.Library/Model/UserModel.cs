using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Library.Model
{
    public class UserModel
    {
        public long ID { get; set; }
        public long AccountId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public char Gender { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
    }
}
