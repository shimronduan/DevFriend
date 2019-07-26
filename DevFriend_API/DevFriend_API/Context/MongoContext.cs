using DevFriend_API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DevFriend_API.Context
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        private readonly List<Func<Task>> _commands;
        public MongoContext(IConfiguration configuration,IOptions<Settings> settings)
        {
            // Set Guid to CSharp style (with dash -)
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();

            RegisterConventions();
            // Configure mongo (You can inject the config, just to simplify)
            //var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("MONGOCONNECTION") ?? configuration.GetSection("MongoSettings").GetSection("Connection").Value);

            //Database = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("DATABASENAME") ?? configuration.GetSection("MongoSettings").GetSection("DatabaseName").Value);


            //var mongoClient = new MongoClient(settings.Value.ConnectionString);

            //------------------------------------------
            MongoClientSettings mongosettings = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
            mongosettings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12,
                ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    foreach (var element in chain.ChainElements)
                    {
                        // Gets the error status of the current X.509 certificate in a chain.
                        foreach (var status in element.ChainElementStatus)
                        {
                            Console.WriteLine($"certificate subject: {element.Certificate.Subject},ChainStatus: {status.StatusInformation}");
                        }
                    }
                    return true; //just for dev, it would bypass certificate errors
                }
            };
            var mongoClient = new MongoClient(mongosettings);
            //

            Database = mongoClient.GetDatabase(settings.Value.Database);

        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }

        public async Task<int> SaveChanges()
        {
            var commandTasks = _commands.Select(c => c());

            await Task.WhenAll(commandTasks);

            return _commands.Count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }

}
