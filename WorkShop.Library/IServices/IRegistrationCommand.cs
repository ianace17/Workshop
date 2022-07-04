using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Library.Model;

namespace WorkShop.Library.IServices
{
    public interface IRegistrationCommand
    {
        Task<bool> CreateIndividual(RegistrationModel registrationModel);

        Task<bool> CreateCorporate(CorporateRegistrationModel corporateRegistrationModel);

    }
}
