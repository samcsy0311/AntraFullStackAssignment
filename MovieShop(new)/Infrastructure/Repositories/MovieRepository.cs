using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
     public class MovieRepository : Repository<Movie>, IMovieRepository
     {
          public MovieRepository (MovieShopDbContext dbContext):base(dbContext)
          {

          }
          
          public IEnumerable<Movie> Get30HighestGrossingMovie()
          {
               // we need to go to database and get the movies using Dapper or EF Core
               
               //access the dbContext object and dbset of movies object to query the movies table

               var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
               return movies;
          }
     }
}
