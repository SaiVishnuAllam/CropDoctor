using CropDoctor.Services.Core.Data.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CropDoctor.Services.Core.Data
{
    public class MongoDbContext
    {
        //private readonly IMongoDatabase _database;
        private static readonly Lazy<MongoDbContext> _instance = new Lazy<MongoDbContext>(() => new MongoDbContext());
        private readonly IMongoDatabase? database = null;

        public MongoDbContext()
        {
            IConfiguration configuration = GetConfig();
            MongoDbSettings settings = new()
            {
                ConnectionString = configuration["MongoDbSettings:ConnectionString"],
                DatabaseName = configuration["MongoDbSettings:DatabaseName"]
            };

            var clientSettings = MongoClientSettings.FromConnectionString(settings.ConnectionString);

            clientSettings.MinConnectionPoolSize = 0;

            clientSettings.MaxConnectionPoolSize = 150;

            var client = new MongoClient(clientSettings);

            database = client.GetDatabase(settings.DatabaseName);
        }

        private static IConfiguration GetConfig()
        {
            // Create a ConfigurationBuilder
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path for appsettings.json
                .AddJsonFile("appsettings.json"); // Add the appsettings.json file



            // Build the IConfiguration
            IConfiguration configuration = builder.Build();
            return configuration;
        }

        public static MongoDbContext Instance => _instance.Value;

        public IMongoCollection<EntryModel> Collection => database?.GetCollection<EntryModel>("Response") ?? throw new InvalidOperationException("Database is not initialized");
        public IMongoCollection<UniversityModel> University => database?.GetCollection<UniversityModel>("UniversityList") ?? throw new InvalidOperationException("Database is not intialized");
        public IMongoCollection<CollegeModel> College => database?.GetCollection<CollegeModel>("CollegeList") ?? throw new InvalidOperationException("Database is not intialized");
        public IMongoCollection<UserModel> User => database?.GetCollection<UserModel>("UserList") ?? throw new InvalidOperationException("Database is not intialized");
    } 
}

