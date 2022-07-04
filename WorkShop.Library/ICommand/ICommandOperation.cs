using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Library.ICommand
{
    public interface ICommandOperation<T> : IDisposable
    {
        Task<bool> Add(T obj, MySqlConnection? connection = null);
        Task<bool> Add(List<T> values, MySqlConnection? connection = null);

    }
}
