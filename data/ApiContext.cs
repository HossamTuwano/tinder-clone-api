using Microsoft.EntityFrameworkCore;
using UserProfileAPI.Models;

namespace UserProfileAPI.Data {
    public class ApiContext: DbContext {
        public DbSet<UserProfile> Users {get; set;}

        public ApiContext(DbContextOptions<ApiContext> options) :base(options) {

        }
    }
}