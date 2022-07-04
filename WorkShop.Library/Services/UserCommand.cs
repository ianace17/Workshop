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
using WorkShop.Library.ICommand;

namespace WorkShop.Library.Services
{
    public class UserCommand : IUserCommand
    {
        private IAppConfig _appConfig;


        public UserCommand(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
        }

        public Task<bool> Add(UserModel obj, MySqlConnection? connection = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Add(List<UserModel> userModels, MySqlConnection? connection = null)
        {
            var result = false;
            try
            {
                if(connection == null)
                {
                    using var conn = new MySqlConnection(_appConfig.Db);
                    connection = conn;
                }
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                var query = "insert into user(account_id,last_name,middle_name,first_name,email,birth_date,gender,password,status) " +
                            "user(@account_id,@last_name,@middle_name,@first_name,@email,@birth_date,@gender,@password,@status)";
                foreach(var item in userModels)
                {
                    var data = await connection.ExecuteAsync(query, item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public void Dispose()
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
