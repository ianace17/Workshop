using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WorkShop.Library.IServices;
using WorkShop.Library.Model;
using Serilog;
using Dapper;

namespace WorkShop.Library.Services
{
    public class UserCommand : IUserCommand
    {
        private IAppConfig _appConfig;


        public UserCommand(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
        }
        public Task<bool> CreateUser(List<UserModel> userModels, MySqlConnection connection)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateUser(List<UserModel> userModels)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(this._appConfig.Db))
                {

                    string query = "select email from `email` where email = @email ";

                    foreach (var item in userModels)
                    {
                        var data = await connection.QueryAsync(query, new { email = item.Email });

                        if (data.Count() > 0)
                            return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return false;
        }
    }
}
