using Microsoft.Extensions.DependencyInjection;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Repasitories
{
    public static class Installer
    {
        public static void AddNHibernate(this IServiceCollection container, string connectionString)
        {
            container.AddSingleton(typeof(NHibernateConfigurator.ISessionFactory), new NHibernateConfigurator.NHibernateConfiguration(connectionString));
            container.AddScoped<ISessionStorage, SessionStorage>();
            container.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
