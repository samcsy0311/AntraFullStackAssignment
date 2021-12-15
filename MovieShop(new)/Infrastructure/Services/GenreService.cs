using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
     public class GenreService : IGenreService
     {
          private readonly IGenreRepository _genreRepository;

          public GenreService (IGenreRepository genreRepository)
          {
               _genreRepository = genreRepository;
          }
          public async Task<List<GenreModel>> GetAllGenres()
          {
               var genres = await _genreRepository.GetAll();
               var genreModel = new List<GenreModel>();
               foreach (var genre in genres)
               {
                    genreModel.Add(new GenreModel { Id = genre.Id, Name = genre.Name });
                    
               }
               return genreModel;
          }

          public async Task<List<MovieCardResponseModel>> GetMovieOfGenre(int Id)
          {
               var movie = await _genreRepository.GetGenreMovies(Id);

               var movieCards = new List<MovieCardResponseModel>();
               foreach (var item in movie)
               {
                    movieCards.Add(new MovieCardResponseModel { Id = item.Id, PosterUrl = item.PosterUrl, Title = item.Title });
               }
               return movieCards;
          }
    }
}
