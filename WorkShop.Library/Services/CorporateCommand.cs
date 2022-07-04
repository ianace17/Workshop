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
    public class CorporateCommand : ICorporateCommand
    {
        private IAppConfig _appConfig;


        public CorporateCommand(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
        }

        public async Task<bool> Add(CorporateModel coporateModel, MySqlConnection? connection = null)
        {
            bool result = false;
            try
            {
                if(connection == null)
                {
                    using var conn = new MySqlConnection(_appConfig.Db);
                    connection = conn;
                }
                string query = "insert into  `corporate` ( account_id, company_name, sec_registration_no, tin, office_address, business_nature, yrs_in_operation, tel_no, fax_no, email) " +
                    "values " +
                    "(@account_id, @company_name, @sec_registration_no, @tin, @office_address, @business_nature, @yrs_in_operation, @tel_no, @fax_no, @email)" +
                    "select last_insert_id(); ";

                var data = await connection.ExecuteAsync(query, new
                {
                    account_id = coporateModel.AccountId,
                    company_name = coporateModel.CompanyName,
                    sec_registration_no = coporateModel.SecRegistrationNumber,
                    tin = coporateModel.Tin,
                    office_address = coporateModel.OfficeAddress,
                    business_nature = coporateModel.BusinessNature,
                    yrs_in_operation = coporateModel.YearsInOperation,
                    tel_no = coporateModel.TelNo,
                    fax_no = coporateModel.FaxNo,
                    email = coporateModel.Email

                });

                if (data > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return result;
        }

        public Task<bool> Add(List<CorporateModel> values, MySqlConnection? connection = null)
        {
            throw new NotImplementedException();
        }
        

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Validate(CorporateModel coporateModel)
        {
            try
            {
                using(MySqlConnection connection = new MySqlConnection(this._appConfig.Db))
                {
                    string query = "select email from `corporate` where email = @email";

                    var data = await connection.QueryAsync(query, new { email = coporateModel.Email });

                    if (data.Count() > 0)
                        return true;
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
