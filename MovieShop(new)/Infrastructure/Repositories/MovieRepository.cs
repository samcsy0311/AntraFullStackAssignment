using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

          public override Movie GetById(int id)
          {
              // call the Movie dbset and also include the navigation properties such as 
              // Genres, Trailers, cast 
              // Include method in EF will help us navigate to related tables and get data
               var movieDetails = _dbContext.Movies.Include(m=> m.MoviesCasts).ThenInclude(m=> m.Cast)
                    .Include(m=> m.GenresOfMovie).ThenInclude(m=> m.Genre).Include(m=> m.Trailers)
                    .FirstOrDefault(m=> m.Id == id);

               if (movieDetails == null) return null;

               var rating = _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                    .Average(r => r == null ? 0 : r.Rating);
               movieDetails.Rating = rating;
               return movieDetails;
          }
     }
}
