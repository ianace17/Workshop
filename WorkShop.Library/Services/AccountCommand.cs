using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Serilog;
using WorkShop.Library.IServices;
using WorkShop.Library.Model;
using Dapper;
using WorkShop.Library.ICommand;

namespace WorkShop.Library.Services
{
    public class AccountCommand : IAccountCommand
    {

        private IAppConfig _appConfig;
      

        public AccountCommand(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
        }

        public async Task<bool> Add(AccountModel accountModel, MySqlConnection? connection = null)
        {
            bool result = false;
            try
            {
                string query = "insert into  `account` (last_name, first_name, middle_name, tel_no, mobile_no, nationality, " +
                    "civil_status, spouse_name, tin, email, occupation, business_nature, employer_name, business_address) " +
                    "values " +
                    "(@last_name, @first_name, @middle_name, @tel_no, @mobile_no, @nationality, " +
                    "@civil_status, @spouse_name, @tin, @email, @occupation, @business_nature, @employer_name, @business_address);" +
                    "select last_insert_id(); ";
                if(connection == null)
                {
                    using var conn = new MySqlConnection(_appConfig.Db);
                    connection = conn;
                }
                var data = await connection.ExecuteScalarAsync<long>(query, new
                {
                    last_name = accountModel.Lastname,
                    first_name = accountModel.Firstname,
                    middle_name = accountModel.Middlename,
                    tel_no = accountModel.TelNo,
                    mobile_no = accountModel.MobileNo,
                    nationality = accountModel.Nationality,
                    civil_status = accountModel.CivilStatus,
                    spouse_name = accountModel.SpouseName,
                    tin = accountModel.Tin,
                    email = accountModel.Email,
                    occupation = accountModel.Occupation,
                    business_nature = accountModel.BusinessNature,
                    employer_name = accountModel.EmployerName,
                    business_address = accountModel.BusinessAddress,
                    tc_code = accountModel,
                    trader_id = accountModel,

                });

                if (data > 0)
                {
                    accountModel.ID = data;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return result;
        }

        public Task<bool> Add(List<AccountModel> values, MySqlConnection? connection = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ApprovedAccount(AccountModel accountModel)
        {
            var result = false;
            try
            {
                //using(var connection = new MySqlConnection(_appConfig))
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
    }
}
