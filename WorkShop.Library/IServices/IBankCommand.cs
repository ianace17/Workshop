using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Library.ICommand;
using WorkShop.Library.Model;

namespace WorkShop.Library.IServices
{
    public interface IBankCommand : ICommandOperation<BankModel>
    {
    }
}
