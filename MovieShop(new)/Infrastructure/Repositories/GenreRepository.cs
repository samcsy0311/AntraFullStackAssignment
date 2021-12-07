using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.data;

namespace Infrastructure.Repositories
{
     public class GenreRepository : Repository<Genre>, IGenreRepository 
     {
          public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
          {

          }
     }
}
