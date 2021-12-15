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

          public async Task<IEnumerable<Movie>> GetPurchasedMovies (int Id)
          {
               var movies = await _dbContext.Movies.Where(
                    x => _dbContext.Purchases.Where(f => f.UserId == Id).Select(f => f.MovieId).Contains(x.Id))
                    .ToListAsync();

               foreach (var movie in movies)
               {
                    var purchase = await _dbContext.Purchases.Where(p => p.MovieId == movie.Id && p.UserId == Id)
                         .FirstOrDefaultAsync();
                    //movie.Purchases.Add(purchase);
               }
               return movies;
          }

          public async Task<IEnumerable<Movie>> GetFavoritedMovies(int Id)
          {
               var movies = await _dbContext.Movies.Where(
                    x => _dbContext.Favorites.Where(f => f.UserId == Id).Select(f => f.MovieId).Contains(x.Id))
                    .ToListAsync();
               return movies;
          }
     }
}