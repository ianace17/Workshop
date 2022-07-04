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
    public class RegistrationCommand : IRegistrationCommand
    {

        public string _errorMessage = string.Empty;

        private IAppConfig _appConfig;
        private IAccountCommand _accountCommand;
        private IUserCommand _userCommand;
        private IAddressCommand _addressCommand;
        private IBankCommand _bankCommand;
        private ICorporateCommand _corporateCommand;

        public RegistrationCommand(IAppConfig appConfig, IAccountCommand accountCommand, IUserCommand userCommand, 
            IAddressCommand addressCommand, IBankCommand bankCommand, ICorporateCommand corporateCommand)
        {
            this._appConfig = appConfig;
            this._accountCommand = accountCommand;
            this._userCommand = userCommand;
            this._addressCommand = addressCommand;
            this._bankCommand = bankCommand;
            this._corporateCommand = corporateCommand;
        }

        public async Task<bool> CreateCorporate(CorporateRegistrationModel corporateRegistrationModel)
        {
            bool result = false;
            try
            {

                if (corporateRegistrationModel.CorporateDetails == null)
                {
                    this._errorMessage = "No Corporate Details";
                    return result;
                }

                if (corporateRegistrationModel.Users.Count == 0)
                {
                    this._errorMessage = "Invalid Number of Corporate User";
                    return result;
                }

                if (await this._userCommand.ValidateUser(corporateRegistrationModel.Users) == false)
                {
                    this._errorMessage = "Invalid User Details";
                    return result;
                }

                if (await this._corporateCommand.Validate(corporateRegistrationModel.CorporateDetails) == false)
                {
                    this._errorMessage = "Invalid Corporate Details";
                    return result;
                }

                using (MySqlConnection cnn = new MySqlConnection(this._appConfig.Db))
                {
                    cnn.Open();
                    using (MySqlTransaction transaction = cnn.BeginTransaction())
                    {
                        result = await this._accountCommand.Add(corporateRegistrationModel.AccountDetails, cnn);

                        if(result)
                        {
                            corporateRegistrationModel.Addresses.ForEach(c => c.AccountId = corporateRegistrationModel.AccountDetails.ID);
                            corporateRegistrationModel.Users.ForEach(c => c.AccountId = corporateRegistrationModel.AccountDetails.ID);
                            corporateRegistrationModel.Banks.ForEach(c => c.AccountId = corporateRegistrationModel.AccountDetails.ID);
                            corporateRegistrationModel.CorporateDetails.AccountId = corporateRegistrationModel.AccountDetails.ID;


                            if(await this._corporateCommand.Add(corporateRegistrationModel.CorporateDetails, cnn) &&
                               await this._userCommand.Add(corporateRegistrationModel.Users, cnn) &&
                               await this._addressCommand.Add(corporateRegistrationModel.Addresses, cnn) &&
                               await this._bankCommand.Add(corporateRegistrationModel.Banks, cnn))
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return result;
        }

        public async Task<bool> CreateIndividual(RegistrationModel registrationModel)
        {
            bool result = false;
            try
            {
                if(registrationModel.Users.Count != 1)
                {
                    this._errorMessage = "Invalid User";
                    return result;
                }

                if (await this._userCommand.ValidateUser(registrationModel.Users) == false)
                {
                    this._errorMessage = "Invalid User Details";
                    return result;
                }
                using (MySqlConnection cnn = new MySqlConnection(this._appConfig.Db))
                {
                    cnn.Open();
                    using (MySqlTransaction transaction = cnn.BeginTransaction())
                    {
                        result = await this._accountCommand.Add(registrationModel.AccountDetails, cnn);

                        if (result)
                        {
                            registrationModel.Addresses.ForEach(c => c.AccountId = registrationModel.AccountDetails.ID);
                            registrationModel.Users.ForEach(c => c.AccountId = registrationModel.AccountDetails.ID);
                            registrationModel.Banks.ForEach(c => c.AccountId = registrationModel.AccountDetails.ID);


                            if (await this._userCommand.Add(registrationModel.Users, cnn) &&
                               await this._addressCommand.Add(registrationModel.Addresses, cnn) &&
                               await this._bankCommand.Add(registrationModel.Banks, cnn))
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return result;
        }

        public string GetErrorMessage() => _errorMessage;
        
    }
}
