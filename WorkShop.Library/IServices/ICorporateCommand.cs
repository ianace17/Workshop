﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WorkShop.Library.Model;

namespace WorkShop.Library.IServices
{
    public interface ICorporateCommand
    {
        Task<bool> CreateCoporate(CoporateModel coporateModel, MySqlConnection connection);

        Task<bool> Validate(CoporateModel coporateModel);
    }
}