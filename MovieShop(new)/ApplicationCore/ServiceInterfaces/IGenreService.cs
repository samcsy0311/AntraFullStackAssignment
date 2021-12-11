using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
     public interface IGenreService
     {
          Task<List<GenreModel>> GetAllGenres();
     }
}
