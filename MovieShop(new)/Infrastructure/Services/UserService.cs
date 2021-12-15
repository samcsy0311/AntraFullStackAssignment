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
     public class UserService : IUserService
     {
          private readonly IUserRepository _userRepository;
          public UserService (IUserRepository userRepository)
          {
               _userRepository = userRepository;
          }
          public Task<bool> EditUserProfile(UserDetailsModel user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailsModel> GetUserDetails(int id)
        {
            throw new NotImplementedException();
        }

          public async Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id)
          {
               var movie = await _userRepository.GetFavoritedMovies(id);

               var movieCards = new List<MovieCardResponseModel>();

               foreach (var item in movie)
               {
                    movieCards.Add(new MovieCardResponseModel
                    { Id = item.Id, PosterUrl = item.PosterUrl, Title = item.Title });
               }

               return movieCards;
          }

          public async Task<List<PurchaseMovieResponseModel>> GetUserPurchasedMovies(int id)
          {
               var movie = await _userRepository.GetPurchasedMovies(id);

               var movieCards = new List<PurchaseMovieResponseModel>();

               foreach(var item in movie)
               {
                    var purchase = item.Purchases[0];
                    movieCards.Add(new PurchaseMovieResponseModel
                    {
                         Id = item.Id,
                         PosterUrl = item.PosterUrl,
                         Title = item.Title,
                         Price = item.Price,
                         Purchases = new PurchaseResponseModel
                         {
                              Id = purchase.Id,
                              PurchaseNumber = purchase.PurchaseNumber,
                              PurchaseDateTime = purchase.PurchaseDateTime
                         }
                    });
               }

               return movieCards;
          }
     }
}
