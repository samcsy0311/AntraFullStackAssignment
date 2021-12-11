using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
          Task<User> GetUserByEmail(string email);
     }
}
