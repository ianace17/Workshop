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
    public class BankCommand : IBankCommand
    {
        private IAppConfig _appConfig;


        public BankCommand(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
        }
        public async Task<bool> CreateBank(List<BankModel> bankModels, MySqlConnection connection)
        {
            bool result = false;
            try
            {
                string query = "insert into `bank` (account_id, name, branch, account_no, status) " +
                    "values (@account_id, @name, @branch, @account_no, @status) ";
                foreach (var item in bankModels)
                {
                    var row = await connection.ExecuteAsync(query,
                        new
                        {
                            account_id = item.AccountId,
                            name = item.Name,
                            branch = item.Branch,
                            account_no = item.AccountNo,
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
    }
}
