using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WorkShop.Library.Model;

namespace WorkShop.Library.IServices
{
    public interface IAccountCommand
    {
        Task<bool> CreateAccount(AccountModel accountModel, MySqlConnection connection);

        Task<bool> ApprovedAccount(AccountModel accountModel);
    }
}
