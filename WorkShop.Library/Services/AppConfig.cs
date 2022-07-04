using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Library.IServices;

namespace WorkShop.Library.Services
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;
        public AppConfig(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Db
        {
            get
            {
                return this._configuration["ConnectionStrings:Db"];
            }
        }
    }
}
