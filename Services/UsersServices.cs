using UserStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UserStoreApi.Services;

public class UsersService {
    private readonly IMongoCollection<User> _usersCollection;

    public UsersService(
        IOptions<UserStoreDatabaseSettings> userStoreDatabaseSettings )
    {
        var mongoClient = new MongoClient(userStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(userStoreDatabaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(userStoreDatabaseSettings.Value.UsersCollectionName);

        
    }

    public async Task<List<User>> GetAsync() => await _usersCollection.Find(_ => true).ToListAsync();

    public async Task CreateAsync(User user) => await _usersCollection.InsertOneAsync(user);




}