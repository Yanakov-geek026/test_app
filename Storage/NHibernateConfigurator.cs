﻿using System;
using Domain.Persons;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Storage.Mappings;

namespace Storage
{
    public class NHibernateConfigurator
    {
        /// <summary>
        /// Интерфейс SessionFactory
        /// </summary>
        public interface ISessionFactory
        {
            /// <summary>
            /// Сессия
            /// </summary>
            ISession Session { get; }
        }

        /// <summary>
        /// The nhibernate configurator.
        /// </summary>
        public class NHibernateConfiguration : ISessionFactory
        {
            /// <summary>
            /// Фабрика сессий
            /// </summary>
            private readonly NHibernate.ISessionFactory _sessionFactory;

            /// <summary>
            /// Конструктор, инициализирует объект <see cref="NHibernateConfiguration"/> класса
            /// </summary>
            public NHibernateConfiguration(string connectionString)
            {
                /*var hibernateConfig = Fluently.Configure().Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersonMap>())
                    .Database(MySQLConfiguration.Standard.Dialect<MySQL5Dialect>().ConnectionString(connectionString).ShowSql()).BuildConfiguration();

                var settings = GetSettings();
                if (!settings.TablesExist)
                {
                    var exporter = new SchemaExport(hibernateConfig);
                    exporter.Execute(true, true, false);

                    settings.TablesExist = true;
                    CreateOrUpdateSettings(settings);
                }

                _sessionFactory = hibernateConfig.BuildSessionFactory();*/


            }

            private ISessionFactory CreateSessionFactory()
            {
                return (ISessionFactory)Fluently
                    .Configure()
                        .Database(
                            PostgreSQLConfiguration.Standard
                            .ConnectionString(c =>
                                c.Host("localhost")
                                .Port(5432)
                                .Database("mydb")
                                .Username("postgres")
                                .Password("Ivan230691")))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersonMap>())
                        .ExposeConfiguration(TreatConfiguration)
                    .BuildSessionFactory();
            }

            private static void TreatConfiguration(Configuration configuration)
            {
                // dump sql file for debug
                Action<string> updateExport = x =>
                {
                    using (System.IO.FileStream file = new System.IO.FileStream(@"update.sql", System.IO.FileMode.Append))
                using (var sw = new System.IO.StreamWriter(file))
                    {
                        sw.Write(x);
                        sw.Close();
                    }
                };
                var update = new SchemaUpdate(configuration);
                update.Execute(updateExport, true);
            }

            /// <summary>
            /// Получить сессию
            /// </summary>
            public ISession Session => _sessionFactory.OpenSession();

            private SettingsModel GetSettings()
            {
                var filename = "setting.json";
                var path = $"{System.IO.Directory.GetCurrentDirectory()}/{filename}";
                
                return JsonConvert.DeserializeObject<SettingsModel>(System.IO.File.ReadAllText(path));

            }

            private void CreateOrUpdateSettings(SettingsModel model)
            {
                var filename = "setting.json";
                var path = $"{System.IO.Directory.GetCurrentDirectory()}/{filename}";
                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(model));
            }
        }

        class SettingsModel
        {
            public bool TablesExist { get; set; }
        }
    }
}
