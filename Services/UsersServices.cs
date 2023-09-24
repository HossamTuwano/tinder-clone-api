using UserStoreApi.Models;
using MongoDB.Driver;

namespace UserProfileApi.Services;

public class UsersServices {
    private readonly IMongoCollection<User> _usersCollection;


}