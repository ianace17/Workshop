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
            var result = true;
            try
            {
                if(connection == null)
                {
                    using var conn = new MySqlConnection(_appConfig.Db);
                    connection = conn;
                }
                var query = "insert into user(account_id,last_name,middle_name,first_name,email,birthdate,gender,password,status) " +
                            "values(@account_id,@last_name,@middle_name,@first_name,@email,@birthdate,@gender,@password,@status)";
                foreach(var item in userModels)
                {
                    var data = await connection.ExecuteAsync(query, new
                    {
                        account_id=item.AccountId,
                        last_name = item.Lastname,
                        middle_name = item.Middlename,
                        first_name = item.Firstname,
                        email = item.Email,
                        birthdate = item.Birthdate,
                        gender = item.Gender,
                        password = item.Password,
                        status = item.Status,
                    });
                    if(data == 0)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
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

                    string query = "select email from `user` where email = @email ";

                    foreach (var item in userModels)
                    {
                        var data = await connection.QueryAsync(query, new { email = item.Email });

                        if (data.Count() > 0)
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return true;
        }
    }
}
