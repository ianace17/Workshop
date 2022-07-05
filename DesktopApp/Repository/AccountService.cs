using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using WorkShop.Library.Services;

namespace DesktopApp.Repository
{
    public class AccountService
    {

        private readonly IConfiguration _configuration;

        public AccountService (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<dynamic>> Query(string clientCode, string email)
        {
            try
            {
                
                using (MySqlConnection connection = new MySqlConnection(this._configuration["ConnectionStrings:Db"]))
                {

                    string query = $"select * from `account` where client_code like @client_code or email like @email";
                    var data = await connection.QueryAsync(query, new
                    {
                        client_code = $"%{clientCode}%",
                        email = $"%{email}%"
                    });

                    return data.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
