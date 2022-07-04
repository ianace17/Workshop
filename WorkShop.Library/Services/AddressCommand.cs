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
    public class AddressCommand : IAddressCommand
    {
        private IAppConfig _appConfig;


        public AddressCommand(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
        }

        public Task<bool> Add(AddressModel obj, MySqlConnection? connection = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Add(List<AddressModel> addressModels, MySqlConnection? connection = null)
        {

            bool result = false;
            try
            {
                if(connection == null)
                {
                    using var conn = new MySqlConnection(_appConfig.Db);
                    connection = conn;
                }
                string query = "insert into address (account_id, house_no, street_name, barangary, city, province, postal_code, status) " +
                    "values (@account_id, @house_no, @street_name, @barangary, @city, @province, @postal_code, @status) ";
                foreach (var item in addressModels)
                {
                    var row = await connection.ExecuteAsync(query,
                        new
                        {
                            account_id = item.AccountId,
                            house_no = item.HouseNo,
                            street_name = item.Streetname,
                            barangary = item.Barangay,
                            city = item.City,
                            province = item.Province,
                            postal_code = item.PostalCode,
                            status = item.Status
                        });

                    if (row > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return result;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
