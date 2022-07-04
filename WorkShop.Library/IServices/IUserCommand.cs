using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WorkShop.Library.ICommand;
using WorkShop.Library.Model;

namespace WorkShop.Library.IServices
{
    public interface IUserCommand : ICommandOperation<UserModel>
    {

        Task<bool> ValidateUser(List<UserModel> userModels);


    }
}
