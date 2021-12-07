using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
     public interface IGenreService
     {
          public List<GenreModel> GetAllGenres();
     }
}
