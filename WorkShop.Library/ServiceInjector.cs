using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Library.ICommand;
using WorkShop.Library.IServices;
using WorkShop.Library.Model;
using WorkShop.Library.Services;

namespace WorkShop.Library
{
    public static class ServiceInjector
    {
        public static void AddWorkshopLibrary(this IServiceCollection services)
        {
            services.AddSingleton<IAppConfig, AppConfig>();
            services.AddScoped<IRegistrationCommand, RegistrationCommand>();
            services.AddScoped<IAccountCommand, AccountCommand>();
            services.AddScoped<IAddressCommand, AddressCommand>();
            services.AddScoped<IBankCommand, BankCommand>();
            services.AddScoped<ICorporateCommand, CorporateCommand>();
            services.AddScoped<IUserCommand, UserCommand>();
        }
    }
}
