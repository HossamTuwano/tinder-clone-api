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

    // get all docs
    public async Task<List<User>> GetAsync() => await _usersCollection.Find(_ => true).ToListAsync();

    // get one doc
      public async Task<User?> GetAsync(string id) =>
        await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    // post doc
    public async Task CreateAsync(User user) => await _usersCollection.InsertOneAsync(user);

    // update a doc
     
    public async Task UpdateAsync(string id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

    // delet user doc

      public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id);




}