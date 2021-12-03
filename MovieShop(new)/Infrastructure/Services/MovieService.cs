using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
     public class MovieService : IMovieService
     {
          //private MovieRepository _movieRepository;

          //public MovieService()
          //{
          //     _movieRepository = new MovieRepository();
          //}
          private readonly IMovieRepository _movieRepository;

          //Constructor Injection
          public MovieService(IMovieRepository movieRepository)
          {
               _movieRepository = movieRepository; // can be anything implementing the IMovieRepo
          }
          
          public IEnumerable<MovieCardResponseModel> GetHighestGrossingMovies()
          {
               // call my MovieRepository and get the data 
               var movies = _movieRepository.Get30HighestGrossingMovie();

               // 3rd party Automapper from 
               // manual way
               var movieCards = new List<MovieCardResponseModel>();
               foreach (var movie in movies)
               {
                    movieCards.Add (new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title});
               }

               return movieCards;
          }
     }
}
