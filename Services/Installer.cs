﻿using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Services
{
    public static class Installer
    {
        public static void AddBuisnessService(this IServiceCollection container)
        {
            container
                .AddScoped<IPersonService, PersonService>()
                .AddScoped<IAccountService, AccountService>();
        }
    }
}
