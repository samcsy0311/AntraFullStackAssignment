using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
     public class UserRepository : Repository<User>, IUserRepository
     {
          public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
          {
          }

          public async Task<User> GetUserByEmail(string email)
          {
               var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
               return user;
          }
     }
}