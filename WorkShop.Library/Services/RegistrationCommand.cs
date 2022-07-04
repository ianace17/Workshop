using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WorkShop.Library.IServices;
using WorkShop.Library.Model;

namespace WorkShop.Library.Services
{
    public class RegistrationCommand : IRegistrationCommand
    {

        private IAppConfig _appConfig;
        private IAccountCommand _accountCommand;
        private IUserCommand _userCommand;
        private IAddressCommand _addressCommand;
        private IBankCommand _bankCommand;

        public RegistrationCommand(IAppConfig appConfig, IAccountCommand accountCommand, IUserCommand userCommand, 
            IAddressCommand addressCommand, IBankCommand bankCommand)
        {
            this._appConfig = appConfig;
            this._accountCommand = accountCommand;
            this._userCommand = userCommand;
            this._addressCommand = addressCommand;
            this._bankCommand = bankCommand;
        }

        public async Task<bool> CreateCorporate(CorporateRegistrationModel corporateRegistrationModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateIndividual(RegistrationModel registrationModel)
        {
            throw new NotImplementedException();
        }
    }
}
